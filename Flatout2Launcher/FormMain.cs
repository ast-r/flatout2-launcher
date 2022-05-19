using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Flatout2Launcher;

public partial class FormMain : Form
{
	private readonly List<string> ipList;

	public FormMain()
	{
		InitializeComponent();

		/* Get ip's and fill combo box */
		ipList = new List<string>();
		GetIPAddresses();
	}

	private void GetIPAddresses()
	{
		var numberOfIPs = 0;
		// Get a list of all network interfaces (usually one per network card, dialup, and VPN connection) 
		var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

		foreach (var network in networkInterfaces)
		{
			// Read the IP configuration for each network 
			var properties = network.GetIPProperties();

			// Each network interface may have multiple IP addresses 
			foreach (UnicastIPAddressInformation address in properties.UnicastAddresses)
			{
				// We're only interested in IPv4 addresses for now 
				if (address.Address.AddressFamily != AddressFamily.InterNetwork)
					continue;

				// Ignore loopback addresses (e.g., 127.0.0.1) 
				if (IPAddress.IsLoopback(address.Address))
					continue;

				comboBox1.Items.Add(address.Address + " (" + network.Name + ")");
				ipList.Add(address.Address.ToString());
				numberOfIPs++;
			}
		}

		if (numberOfIPs > 0) comboBox1.SelectedIndex = 0;
	}

	private int LaunchGame(string args)
	{
		var exitCode = -1;

		// Prepare the process to run
		var start = new ProcessStartInfo();

		start.Arguments = args;
		start.FileName = "flatout2.exe";

		// Run the external process & wait for it to finish
		try
		{
			using (var proc = Process.Start(start))
			{
				proc.WaitForExit();

				// Retrieve the app's exit code
				exitCode = proc.ExitCode;
			}
		}
		catch (Exception e)
		{
			MessageBox.Show(e.Message);
		}

		return exitCode;
	}

	private bool ValidateIP(string ip)
	{
		var count = 0;
		var words = ip.Split('.');

		foreach (var word in words)
		{
			count++;

			try
			{
				var temp = Convert.ToInt32(word);

				if (temp < 0 || temp > 255) return false;
			}
			catch
			{
				return false;
			}
		}

		if (count != 4) return false;

		return true;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Application.Exit();
	}

	private void buttonRun_Click(object sender, EventArgs e)
	{
		switch (mainTabControl.SelectedIndex)
		{
			/* Client */
			case 0:
				if (ValidateIP(textBoxClient_ServerIP.Text))
					LaunchGame("-join=" + textBoxClient_ServerIP.Text + " -lan");
				else
					MessageBox.Show("Invalid IP!");
				break;

			/* Server */
			case 1:
				var ip = ipList[comboBox1.SelectedIndex];
				if (ValidateIP(ip))
					LaunchGame("-host -lan -private_addr=" + ip);
				else
					MessageBox.Show("Invalid IP!");
				break;

			/* Options */
			case 2:
				LaunchGame("-setup");
				break;

			/* Single Player */
			case 3:
				LaunchGame("");
				break;
		}
	}
}