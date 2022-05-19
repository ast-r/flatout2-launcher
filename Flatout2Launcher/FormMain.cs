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

	private string _steamLocation =
		Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "/Steam/steam.exe";

	private string _gameLocation = string.Empty;

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
		using var sr = new StreamReader(Environment.CurrentDirectory + "/filePaths.json");
		var str = sr.ReadToEnd();
		var json = JsonSerializer.Deserialize<CustomPaths>(str);
		if (json is null) return;
		_steamLocation = string.IsNullOrWhiteSpace(json.Steam) ? _steamLocation : json.Steam;
		_gameLocation = json.Game;
	}

	private void WriteCustomPaths()
	{
		using var sw = new StreamWriter(Environment.CurrentDirectory + "/filePaths.json");
		var json = new CustomPaths(_steamLocation, _gameLocation);
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

			if (!File.Exists(_steamLocation))
			{
				MessageBox.Show(
					$"Steam can not be found in {_steamLocation}\n" +
					"Provide custom location",
					string.Empty,
					MessageBoxButtons.OK,
					MessageBoxIcon.Information,
					MessageBoxDefaultButton.Button1,
					0,
					false);

				openFileDialogSteam.ShowDialog();

				_steamLocation = openFileDialogSteam.FileName;
				WriteCustomPaths();
			}

			start.FileName = _steamLocation;
		}
		else
		{
			if (!File.Exists(_gameLocation))
			{
				MessageBox.Show(
					$"Game can not be found in {_gameLocation}\n" +
					"Provide custom location",
					string.Empty,
					MessageBoxButtons.OK,
					MessageBoxIcon.Information,
					MessageBoxDefaultButton.Button1,
					0,
					false);

				openFileDialogGame.ShowDialog();

				_gameLocation = openFileDialogGame.FileName;
				WriteCustomPaths();
			}

			start.FileName = _gameLocation;
			start.WorkingDirectory = Path.GetDirectoryName(_gameLocation) ?? string.Empty;
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