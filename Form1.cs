using MetroFramework.Forms;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace SAMPClient
{
    public partial class Main : MetroForm
    {
        private MetroTabControl mainTabs;
        private Settings settings;
        
        public Main()
        {
            InitializeComponent();

            settings = Settings.Read();
            Text = "SA-MP Client - " + settings.UserNickname;

            RestoreDefaultData();

            var favourites = Favourites.Read();
 
            favourites.Servers.ForEach(server =>
            {
                var tile = new MetroTile
                {
                    Text = server.HostName + Environment.NewLine + server.Ip,
                    Size = new Size(152, 137),
                    Style = MetroColorStyle.Yellow,
                    AllowDrop = true
                };
                tile.Click += (s, e) =>
                {
                    var result = MetroFramework.MetroMessageBox.Show(this, "Sei sicuro di voler entrare nel server " + server.HostName + " (" + server.Ip + ")?", "Ingresso", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                    if (result == DialogResult.No)
                    {
                        return;
                    }

                    var processStart = new ProcessStartInfo
                    {
                        WorkingDirectory = settings.GTABasePath,
                        FileName = "samp",
                        Arguments = server.Ip
                    };

                    Process.Start(processStart);
                };

                flowLayoutPanel1.Controls.Add(tile);
            });

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            settings.UserNickname = nicknameTextBox.Text;
            settings.GTALocation = gtaLocationTextBox.Text;
            settings.AutoSaveRconPassword = savePasswordRcon.Checked;
            settings.AutoSaveServerPassword = saveServerPassword.Checked;

            base.Text = "SA-MP Client - " + settings.UserNickname;

            settings.Save();
        }

        private void RestoreDefaultData()
        {
            nicknameTextBox.Text = settings.UserNickname;
            gtaLocationTextBox.Text = settings.GTALocation;
            savePasswordRcon.Checked = settings.AutoSaveRconPassword;
            saveServerPassword.Checked = settings.AutoSaveServerPassword;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            RestoreDefaultData();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (selectGTAPositionDialog.ShowDialog() != DialogResult.OK) return;
            
            var directory = selectGTAPositionDialog.SelectedPath;
            gtaLocationTextBox.Text = directory;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {

        }
    }
}
