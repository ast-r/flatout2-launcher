using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text.Json;
using System.Windows.Forms;

namespace Flatout2Launcher;

public partial class FormMain : Form
{
	private readonly List<string> ipList;

	private readonly string _steamLocation =
		Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\Steam\steam.exe";

	public FormMain()
	{
		InitializeComponent();

		LoadCustomPaths();

		/* Get ip's and fill combo box */
		ipList = new List<string>();
		GetIPAddresses();
	}

	private record CustomPaths(string Steam, string Game);

	private void LoadCustomPaths()
	{
		if (!File.Exists(Environment.CurrentDirectory + @"\filePaths.json"))
		{
			textBoxSteamPath.Text = _steamLocation;
			return;
		}

		using var sr = new StreamReader(Environment.CurrentDirectory + @"\filePaths.json");
		var str = sr.ReadToEnd();
		var json = JsonSerializer.Deserialize<CustomPaths>(str);
		if (json is null) return;
		textBoxSteamPath.Text = string.IsNullOrWhiteSpace(json.Steam) ? _steamLocation : json.Steam;
		textBoxGamePath.Text = json.Game;
	}

	private void WriteCustomPaths()
	{
		using var sw = new StreamWriter(Environment.CurrentDirectory + @"\filePaths.json");
		var json = new CustomPaths(textBoxSteamPath.Text, textBoxGamePath.Text);
		var str = JsonSerializer.Serialize(json, new JsonSerializerOptions {WriteIndented = true});
		sw.Write(str);
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
			foreach (var address in properties.UnicastAddresses)
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

	private readonly string _flatoutSteamId = "2990";

	private int LaunchGame(string args, bool steam = false)
	{
		var exitCode = -1;

		// Prepare the process to run
		var start = new ProcessStartInfo();

		if (steam)
		{
			args = args.Insert(0, $"-applaunch {_flatoutSteamId} ");
			start.FileName = textBoxSteamPath.Text;
		}
		else
		{
			if (string.IsNullOrWhiteSpace(textBoxGamePath.Text))
			{
				MessageBox.Show(
					"The path to the game file is not specified. Set it on the \"Paths\" tab.",
					string.Empty,
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning,
					MessageBoxDefaultButton.Button1,
					0,
					false);
				return exitCode;
			}

			start.FileName = textBoxGamePath.Text;
			start.WorkingDirectory = Path.GetDirectoryName(textBoxGamePath.Text) ?? string.Empty;
		}

		start.Arguments = args;

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
		Run();
	}

	private void buttonRunSteam_Click(object sender, EventArgs e)
	{
		Run(true);
	}

	private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
	{
		switch (mainTabControl.SelectedIndex)
		{
			case 4:
				buttonRun.Enabled = false;
				buttonRunSteam.Enabled = false;
				break;
			default:
				buttonRun.Enabled = true;
				buttonRunSteam.Enabled = true;
				break;
		}
	}

	private void buttonSetGamePath_Click(object sender, EventArgs e)
	{
		openFileDialogGame.ShowDialog();
		if (string.IsNullOrWhiteSpace(openFileDialogGame.FileName))
			return;

		textBoxGamePath.Text = openFileDialogGame.FileName;

		var filename = Path.GetFileName(textBoxGamePath.Text);
		if (filename != "FlatOut2.exe")
			MessageBox.Show(
				$"You selected \"{filename}\", but \"FlatOut2.exe\" was expected.\n" +
				"Make sure you have selected the correct file.",
				string.Empty,
				MessageBoxButtons.OK,
				MessageBoxIcon.Information,
				MessageBoxDefaultButton.Button1,
				0,
				false);
		WriteCustomPaths();
	}

	private void buttonSetSteamPath_Click(object sender, EventArgs e)
	{
		openFileDialogSteam.ShowDialog();
		if (string.IsNullOrWhiteSpace(openFileDialogSteam.FileName))
			return;

		textBoxSteamPath.Text = openFileDialogSteam.FileName;

		var filename = Path.GetFileName(textBoxSteamPath.Text);
		if (filename != "steam.exe")
			MessageBox.Show(
				$"You selected \"{filename}\", but \"steam.exe\" was expected.\n" +
				"Make sure you have selected the correct file.",
				string.Empty,
				MessageBoxButtons.OK,
				MessageBoxIcon.Information,
				MessageBoxDefaultButton.Button1,
				0,
				false);
		WriteCustomPaths();
	}

	private void Run(bool steam = false)
	{
		switch (mainTabControl.SelectedIndex)
		{
			/* Client */
			case 0:
				if (ValidateIP(textBoxClient_ServerIP.Text))
					LaunchGame("-join=" + textBoxClient_ServerIP.Text + " -lan", steam);
				else
					MessageBox.Show("Invalid IP!");
				break;

			/* Server */
			case 1:
				var ip = ipList[comboBox1.SelectedIndex];
				if (ValidateIP(ip))
					LaunchGame("-host -lan -private_addr=" + ip, steam);
				else
					MessageBox.Show("Invalid IP!");
				break;

			/* Options */
			case 2:
				LaunchGame("-setup", steam);
				break;

			/* Single Player */
			case 3:
				LaunchGame(string.Empty, steam);
				break;
		}
	}
}