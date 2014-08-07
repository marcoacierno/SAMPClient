using System;
using System.Collections.Generic;
using System.Drawing;
using MetroFramework.Controls;
using System.Windows.Forms;
using MetroFramework.Forms;

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

            /* add test */
            var favourites = Favourites.Read();
            
            favourites.AddToFavourites(new Server("T1", "T1"));
            favourites.AddToFavourites(new Server("T2", "T1"));
            favourites.AddToFavourites(new Server("T3", "T1"));
            favourites.AddToFavourites(new Server("T4", "T1"));
            favourites.AddToFavourites(new Server("T5", "T1"));
            favourites.AddToFavourites(new Server("T6", "T1"));
            favourites.AddToFavourites(new Server("T7", "T1"));
            favourites.Save();

            favourites.Servers.ForEach(server =>
            {
                var tile = new MetroTile
                {
                    Text = server.HostName + Environment.NewLine + server.Ip,
                    Size = new Size(152, 137)
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

            Text = "SA-MP Client - " + settings.UserNickname;

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
    }
}
