using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace FreeLANSimpleGUI
{
	public partial class frmMain : Form
	{
		private string cfg { get; set; }

		public frmMain()
		{
			InitializeComponent();
			Icon = Properties.Resources.oxygen_lan;
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			ListConfig();
        }

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			btnStop.PerformClick();
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(cboConfigList.Text))
				return;

			if (!bgThread.IsBusy)
			{
				cfg = cboConfigList.Text;
				bgThread.RunWorkerAsync(cfg);

				IPRoute.Modify(IPRouteMode.Add, cfg);
				rtfLog.AppendText("Applying route!\n");
			}
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			Process[] Task = Process.GetProcessesByName("freelan");
			foreach (Process P in Task)
			{
				P.Kill();
				rtfLog.AppendText("freelan terminated!\n");

				IPRoute.Modify(IPRouteMode.Delete, cfg);
				rtfLog.AppendText("route has been removed!\n");
			}
		}

		private void btnClearLog_Click(object sender, EventArgs e)
		{
			if (!bgThread.IsBusy)
				rtfLog.Clear();
		}

		private void btnConfigRefresh_Click(object sender, EventArgs e)
		{
			ListConfig();
        }

		private void ListConfig()
		{
			cboConfigList.Items.Clear();
			foreach (var item in Directory.GetFiles(Path.Combine("..", "config"), "*.cfg"))
				cboConfigList.Items.Add(item);

			cboConfigList.SelectedIndex = cboConfigList.Items.Count - 1;
		}

		private void bgThread_DoWork(object sender, DoWorkEventArgs e)
		{
			string cfgFile = e.Argument as string;
			StartProcess("freelan", $"-c {cfgFile}");
		}

		private void StartProcess(string exe, string args)
		{
			Process P = new Process();
			var SI = P.StartInfo;

			if (OS.IsWindows)
			{
				SI.FileName = "cmd";
				SI.Arguments = $"/c {exe} {args}";
            }
			else
			{
				SI.FileName = "bash";
				SI.Arguments = $"-c '{exe} {args}'";
			}

			SI.WorkingDirectory = Environment.CurrentDirectory;
            SI.CreateNoWindow = true;
			SI.UseShellExecute = false;
			SI.RedirectStandardInput = true;
			SI.RedirectStandardOutput = true;
			SI.RedirectStandardError = true;

			P.OutputDataReceived += consoleOutputHandler;
			P.ErrorDataReceived += consoleErrorHandler;

			P.Start();

			P.BeginOutputReadLine();
			P.BeginErrorReadLine();

			P.WaitForExit();

			P.Close();
		}

		private delegate void consoleOutputDelegate(string outputString);
		private delegate void consoleErrorDelegate(string errorString);

		private void consoleOutput(string outputString)
		{
			if (InvokeRequired)
			{
				consoleOutputDelegate del = new consoleOutputDelegate(consoleOutput);
				object[] args = { outputString };
				Invoke(del, args);
			}
			else
			{
				rtfLog.AppendText(string.Concat(outputString, Environment.NewLine));
			}
		}

		public void consoleOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
		{
			if (!string.IsNullOrEmpty(outLine.Data))
			{
				consoleOutput(outLine.Data);
			}
		}

		private void consoleError(string errorString)
		{
			if (InvokeRequired)
			{
				consoleErrorDelegate del = new consoleErrorDelegate(consoleError);
				object[] args = { errorString };
				Invoke(del, args);
			}
			else
			{
				rtfLog.AppendText(string.Concat(errorString, Environment.NewLine));
			}
		}

		private void consoleErrorHandler(object sendingProcess, DataReceivedEventArgs errLine)
		{
			if (!string.IsNullOrEmpty(errLine.Data))
			{
				consoleError(errLine.Data);
			}
		}

		private void bgThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{

		}
	}
}
