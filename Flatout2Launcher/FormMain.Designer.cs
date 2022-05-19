namespace Flatout2Launcher
{
    partial class FormMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.buttonExit = new System.Windows.Forms.Button();
			this.buttonRun = new System.Windows.Forms.Button();
			this.mainTabControl = new System.Windows.Forms.TabControl();
			this.tabClient = new System.Windows.Forms.TabPage();
			this.textBoxClient_ServerIP = new System.Windows.Forms.TextBox();
			this.labelServerIP = new System.Windows.Forms.Label();
			this.tabServer = new System.Windows.Forms.TabPage();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.labelMyIP = new System.Windows.Forms.Label();
			this.tabPageOptions = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPageSinglePlayer = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.pictureBoxFlatOutLogo = new System.Windows.Forms.PictureBox();
			this.buttonRunSteam = new System.Windows.Forms.Button();
			this.openFileDialogGame = new System.Windows.Forms.OpenFileDialog();
			this.openFileDialogSteam = new System.Windows.Forms.OpenFileDialog();
			this.mainTabControl.SuspendLayout();
			this.tabClient.SuspendLayout();
			this.tabServer.SuspendLayout();
			this.tabPageOptions.SuspendLayout();
			this.tabPageSinglePlayer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxFlatOutLogo)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonExit
			// 
			this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonExit.Location = new System.Drawing.Point(14, 337);
			this.buttonExit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.buttonExit.Name = "buttonExit";
			this.buttonExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.buttonExit.Size = new System.Drawing.Size(88, 27);
			this.buttonExit.TabIndex = 0;
			this.buttonExit.Text = "Exit";
			this.buttonExit.UseVisualStyleBackColor = true;
			this.buttonExit.Click += new System.EventHandler(this.button1_Click);
			// 
			// buttonRun
			// 
			this.buttonRun.Location = new System.Drawing.Point(150, 337);
			this.buttonRun.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.buttonRun.Name = "buttonRun";
			this.buttonRun.Size = new System.Drawing.Size(88, 27);
			this.buttonRun.TabIndex = 1;
			this.buttonRun.Text = "Run";
			this.buttonRun.UseVisualStyleBackColor = true;
			this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
			// 
			// mainTabControl
			// 
			this.mainTabControl.Controls.Add(this.tabClient);
			this.mainTabControl.Controls.Add(this.tabServer);
			this.mainTabControl.Controls.Add(this.tabPageOptions);
			this.mainTabControl.Controls.Add(this.tabPageSinglePlayer);
			this.mainTabControl.Location = new System.Drawing.Point(14, 197);
			this.mainTabControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.mainTabControl.Name = "mainTabControl";
			this.mainTabControl.SelectedIndex = 0;
			this.mainTabControl.Size = new System.Drawing.Size(322, 133);
			this.mainTabControl.TabIndex = 2;
			// 
			// tabClient
			// 
			this.tabClient.Controls.Add(this.textBoxClient_ServerIP);
			this.tabClient.Controls.Add(this.labelServerIP);
			this.tabClient.Location = new System.Drawing.Point(4, 24);
			this.tabClient.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.tabClient.Name = "tabClient";
			this.tabClient.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.tabClient.Size = new System.Drawing.Size(314, 105);
			this.tabClient.TabIndex = 0;
			this.tabClient.Text = "Join";
			this.tabClient.UseVisualStyleBackColor = true;
			// 
			// textBoxClient_ServerIP
			// 
			this.textBoxClient_ServerIP.Location = new System.Drawing.Point(8, 42);
			this.textBoxClient_ServerIP.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.textBoxClient_ServerIP.MaxLength = 15;
			this.textBoxClient_ServerIP.Name = "textBoxClient_ServerIP";
			this.textBoxClient_ServerIP.Size = new System.Drawing.Size(298, 23);
			this.textBoxClient_ServerIP.TabIndex = 1;
			// 
			// labelServerIP
			// 
			this.labelServerIP.AutoSize = true;
			this.labelServerIP.Location = new System.Drawing.Point(8, 24);
			this.labelServerIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelServerIP.Name = "labelServerIP";
			this.labelServerIP.Size = new System.Drawing.Size(55, 15);
			this.labelServerIP.TabIndex = 0;
			this.labelServerIP.Text = "Server IP:";
			// 
			// tabServer
			// 
			this.tabServer.Controls.Add(this.comboBox1);
			this.tabServer.Controls.Add(this.labelMyIP);
			this.tabServer.Location = new System.Drawing.Point(4, 24);
			this.tabServer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.tabServer.Name = "tabServer";
			this.tabServer.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.tabServer.Size = new System.Drawing.Size(314, 105);
			this.tabServer.TabIndex = 1;
			this.tabServer.Text = "Host";
			this.tabServer.UseVisualStyleBackColor = true;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(8, 42);
			this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(298, 23);
			this.comboBox1.TabIndex = 2;
			// 
			// labelMyIP
			// 
			this.labelMyIP.AutoSize = true;
			this.labelMyIP.Location = new System.Drawing.Point(8, 24);
			this.labelMyIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelMyIP.Name = "labelMyIP";
			this.labelMyIP.Size = new System.Drawing.Size(40, 15);
			this.labelMyIP.TabIndex = 1;
			this.labelMyIP.Text = "My IP:";
			// 
			// tabPageOptions
			// 
			this.tabPageOptions.Controls.Add(this.label1);
			this.tabPageOptions.Location = new System.Drawing.Point(4, 24);
			this.tabPageOptions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.tabPageOptions.Name = "tabPageOptions";
			this.tabPageOptions.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.tabPageOptions.Size = new System.Drawing.Size(314, 105);
			this.tabPageOptions.TabIndex = 2;
			this.tabPageOptions.Text = "Options";
			this.tabPageOptions.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(25, 45);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(271, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Click on Go to change FlatOut 2 Graphics settings.";
			// 
			// tabPageSinglePlayer
			// 
			this.tabPageSinglePlayer.Controls.Add(this.label2);
			this.tabPageSinglePlayer.Location = new System.Drawing.Point(4, 24);
			this.tabPageSinglePlayer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.tabPageSinglePlayer.Name = "tabPageSinglePlayer";
			this.tabPageSinglePlayer.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.tabPageSinglePlayer.Size = new System.Drawing.Size(314, 105);
			this.tabPageSinglePlayer.TabIndex = 3;
			this.tabPageSinglePlayer.Text = "Single Player";
			this.tabPageSinglePlayer.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(81, 45);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(142, 15);
			this.label2.TabIndex = 0;
			this.label2.Text = "Click on Go to play alone.";
			// 
			// pictureBoxFlatOutLogo
			// 
			this.pictureBoxFlatOutLogo.BackgroundImage = global::Flatout2Launcher.Properties.Resources.Bitmap_130;
			this.pictureBoxFlatOutLogo.Location = new System.Drawing.Point(9, 9);
			this.pictureBoxFlatOutLogo.Margin = new System.Windows.Forms.Padding(0);
			this.pictureBoxFlatOutLogo.MaximumSize = new System.Drawing.Size(327, 168);
			this.pictureBoxFlatOutLogo.MinimumSize = new System.Drawing.Size(327, 168);
			this.pictureBoxFlatOutLogo.Name = "pictureBoxFlatOutLogo";
			this.pictureBoxFlatOutLogo.Size = new System.Drawing.Size(327, 168);
			this.pictureBoxFlatOutLogo.TabIndex = 3;
			this.pictureBoxFlatOutLogo.TabStop = false;
			// 
			// buttonRunSteam
			// 
			this.buttonRunSteam.Location = new System.Drawing.Point(246, 337);
			this.buttonRunSteam.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.buttonRunSteam.Name = "buttonRunSteam";
			this.buttonRunSteam.Size = new System.Drawing.Size(88, 27);
			this.buttonRunSteam.TabIndex = 4;
			this.buttonRunSteam.Text = "Run Steam";
			this.buttonRunSteam.UseVisualStyleBackColor = true;
			this.buttonRunSteam.Click += new System.EventHandler(this.buttonRunSteam_Click);
			// 
			// openFileDialogGame
			// 
			this.openFileDialogGame.Filter = "exe file (*.exe)|*.exe";
			this.openFileDialogGame.Title = "Flatout 2 exe location";
			// 
			// openFileDialogSteam
			// 
			this.openFileDialogSteam.Filter = "exe file (*.exe)|*.exe";
			this.openFileDialogSteam.Title = "Steam exe location";
			// 
			// FormMain
			// 
			this.AcceptButton = this.buttonRun;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.CancelButton = this.buttonExit;
			this.ClientSize = new System.Drawing.Size(347, 375);
			this.Controls.Add(this.buttonRunSteam);
			this.Controls.Add(this.pictureBoxFlatOutLogo);
			this.Controls.Add(this.mainTabControl);
			this.Controls.Add(this.buttonRun);
			this.Controls.Add(this.buttonExit);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(363, 414);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(363, 414);
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Flatout 2 Launcher";
			this.mainTabControl.ResumeLayout(false);
			this.tabClient.ResumeLayout(false);
			this.tabClient.PerformLayout();
			this.tabServer.ResumeLayout(false);
			this.tabServer.PerformLayout();
			this.tabPageOptions.ResumeLayout(false);
			this.tabPageOptions.PerformLayout();
			this.tabPageSinglePlayer.ResumeLayout(false);
			this.tabPageSinglePlayer.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxFlatOutLogo)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabClient;
        private System.Windows.Forms.TabPage tabServer;
        private System.Windows.Forms.TextBox textBoxClient_ServerIP;
        private System.Windows.Forms.Label labelServerIP;
        private System.Windows.Forms.Label labelMyIP;
        private System.Windows.Forms.TabPage tabPageOptions;
        private System.Windows.Forms.TabPage tabPageSinglePlayer;
        private System.Windows.Forms.PictureBox pictureBoxFlatOutLogo;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonRunSteam;
		private System.Windows.Forms.OpenFileDialog openFileDialogGame;
		private System.Windows.Forms.OpenFileDialog openFileDialogSteam;
	}
}

