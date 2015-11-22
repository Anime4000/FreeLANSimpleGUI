using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace FreeLANSimpleGUI
{
	public enum IPRouteMode
	{
		Add,
		Delete,
	}

	public class IPRoute
	{
		private static string gateway { get; set; }
		private static string iface { get; set; }

        public static void Modify(IPRouteMode mode, string cfg)
		{
			if (!File.Exists("ip.route"))
				return;

			string[] hosts = File.ReadAllLines("ip.route");

			foreach (var item in File.ReadAllLines(cfg))
			{
				if (item.Length >= 2)
				{
					if (item[0] != '#' && item[1] != '!')
						if (item.Contains("ipv4_address_prefix_length"))
							iface = item.Substring(item.IndexOf('=') + 1);

					if (item[0] == '#' && item[1] == '!')
						if (item.Contains("gateway"))
							gateway = item.Substring(item.IndexOf('=') + 1);
				}
			}

			if (string.IsNullOrEmpty(gateway))
				return;

			foreach (var item in hosts)
			{
				IPNetwork ip = IPNetwork.Parse(item);
				
				if (IPRouteMode.Add == mode)
					Add($"{ip.Network}", $"{ip.Netmask}");

				if (IPRouteMode.Delete == mode)
					Delete($"{ip.Network}", $"{ip.Netmask}");
			}
		}

		private static void Add(string host, string mask)
		{
			Process P = new Process();

			if (OS.IsWindows)
			{
				P.StartInfo.FileName = "route";
				P.StartInfo.Arguments = $"add {host} mask {mask} {gateway}";
			}
			else
			{
				P.StartInfo.FileName = "route";
				P.StartInfo.Arguments = $"add -net {host} netmask {mask} gw {gateway}";
			}

			P.StartInfo.UseShellExecute = false;
			P.StartInfo.CreateNoWindow = true;

			P.Start();
		}

		private static void Delete(string host, string mask)
		{
			Process P = new Process();

			if (OS.IsWindows)
			{
				P.StartInfo.FileName = "route";
				P.StartInfo.Arguments = $"delete {host}";
			}
			else
			{
				P.StartInfo.FileName = "route";
				P.StartInfo.Arguments = $"del -net {host} netmask {mask} gw {gateway}";
			}

			P.StartInfo.UseShellExecute = false;
			P.StartInfo.CreateNoWindow = true;

			P.Start();
		}
	}
}
