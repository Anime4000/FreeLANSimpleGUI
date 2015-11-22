namespace FreeLANSimpleGUI
{
	partial class frmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblConfig = new System.Windows.Forms.Label();
			this.cboConfigList = new System.Windows.Forms.ComboBox();
			this.btnStart = new System.Windows.Forms.Button();
			this.rtfLog = new System.Windows.Forms.RichTextBox();
			this.btnStop = new System.Windows.Forms.Button();
			this.btnConfigRefresh = new System.Windows.Forms.Button();
			this.btnClearLog = new System.Windows.Forms.Button();
			this.bgThread = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// lblConfig
			// 
			this.lblConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblConfig.Location = new System.Drawing.Point(276, 12);
			this.lblConfig.Name = "lblConfig";
			this.lblConfig.Size = new System.Drawing.Size(100, 24);
			this.lblConfig.TabIndex = 3;
			this.lblConfig.Text = "Configuration:";
			this.lblConfig.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cboConfigList
			// 
			this.cboConfigList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cboConfigList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboConfigList.Font = new System.Drawing.Font("Tahoma", 10F);
			this.cboConfigList.FormattingEnabled = true;
			this.cboConfigList.Location = new System.Drawing.Point(382, 12);
			this.cboConfigList.Name = "cboConfigList";
			this.cboConfigList.Size = new System.Drawing.Size(200, 24);
			this.cboConfigList.TabIndex = 4;
			// 
			// btnStart
			// 
			this.btnStart.Font = new System.Drawing.Font("Tahoma", 8F);
			this.btnStart.Location = new System.Drawing.Point(12, 12);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(75, 24);
			this.btnStart.TabIndex = 0;
			this.btnStart.Text = "&Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// rtfLog
			// 
			this.rtfLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtfLog.BackColor = System.Drawing.Color.Black;
			this.rtfLog.Font = new System.Drawing.Font("Lucida Console", 8F);
			this.rtfLog.ForeColor = System.Drawing.Color.Silver;
			this.rtfLog.HideSelection = false;
			this.rtfLog.Location = new System.Drawing.Point(12, 42);
			this.rtfLog.Name = "rtfLog";
			this.rtfLog.ReadOnly = true;
			this.rtfLog.Size = new System.Drawing.Size(600, 388);
			this.rtfLog.TabIndex = 6;
			this.rtfLog.Text = "";
			this.rtfLog.WordWrap = false;
			// 
			// btnStop
			// 
			this.btnStop.Location = new System.Drawing.Point(93, 12);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(75, 24);
			this.btnStop.TabIndex = 1;
			this.btnStop.Text = "St&op";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// btnConfigRefresh
			// 
			this.btnConfigRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnConfigRefresh.Image = global::FreeLANSimpleGUI.Properties.Resources.arrow_refresh;
			this.btnConfigRefresh.Location = new System.Drawing.Point(588, 12);
			this.btnConfigRefresh.Name = "btnConfigRefresh";
			this.btnConfigRefresh.Size = new System.Drawing.Size(24, 24);
			this.btnConfigRefresh.TabIndex = 5;
			this.btnConfigRefresh.UseVisualStyleBackColor = true;
			this.btnConfigRefresh.Click += new System.EventHandler(this.btnConfigRefresh_Click);
			// 
			// btnClearLog
			// 
			this.btnClearLog.Location = new System.Drawing.Point(174, 12);
			this.btnClearLog.Name = "btnClearLog";
			this.btnClearLog.Size = new System.Drawing.Size(75, 24);
			this.btnClearLog.TabIndex = 2;
			this.btnClearLog.Text = "&Clear Log";
			this.btnClearLog.UseVisualStyleBackColor = true;
			this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
			// 
			// bgThread
			// 
			this.bgThread.WorkerSupportsCancellation = true;
			this.bgThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgThread_DoWork);
			this.bgThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgThread_RunWorkerCompleted);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 442);
			this.Controls.Add(this.btnClearLog);
			this.Controls.Add(this.btnConfigRefresh);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.rtfLog);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.cboConfigList);
			this.Controls.Add(this.lblConfig);
			this.Font = new System.Drawing.Font("Tahoma", 8F);
			this.Name = "frmMain";
			this.Text = "FreeLAN - LAN party over Internet!";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblConfig;
		private System.Windows.Forms.ComboBox cboConfigList;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.RichTextBox rtfLog;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Button btnConfigRefresh;
		private System.Windows.Forms.Button btnClearLog;
		private System.ComponentModel.BackgroundWorker bgThread;
	}
}

