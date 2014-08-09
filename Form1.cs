using System.Linq;
using System.Threading.Tasks;
using MetroFramework.Forms;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using Timer = System.Threading.Timer;

namespace SAMPClient
{
    public partial class Main : MetroForm
    {
        /// <summary>
        /// A reference to the user settings
        /// </summary>
        private Settings settings;
        /// <summary>
        /// Contains all the servers which are visible to the user
        /// </summary>
        private List<Server> servers = new List<Server>();

        public Main()
        {
            InitializeComponent();
            new Timer(UpdateServersInfo, null, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(10));

            settings = Settings.Read();
            Text = "SA-MP Client - " + settings.UserNickname;

            RestoreDefaultData();

            Favourites favourites = Favourites.Read();
            servers = favourites.Servers;
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

        public async void UpdateServersInfo(object obj)
        {
            var tasks = new List<Task>();
            servers.ForEach(server => tasks.Add(server.ServerInfo.ReadData()));

            await Task.WhenAll(tasks);

            DrawServerTitles(flowLayoutPanel1);
        }

        private void DrawServerTitles(FlowLayoutPanel panel)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)(() => UpdateServersInfo(panel)));
                return;
            }

            UpdateServersInfo(panel);
        }

        private void UpdateServersInfo(FlowLayoutPanel panel)
        {
            panel.Controls.Clear();

            servers.ForEach(server =>
            {
                var tile = new MetroTile
                {
                    Text = server.HostName + Environment.NewLine + server.Ip + Environment.NewLine +
                           "Gamemode: " + server.ServerInfo.Gamemode + Environment.NewLine +
                           "Map: " + server.ServerInfo.MapName,
                    Size = new Size(152, 137),
                    Style = MetroColorStyle.Red,
                };
                tile.Click += (sender, e) =>
                {
                    var result = MetroFramework.MetroMessageBox.Show(this,
                        "Sei sicuro di voler entrare nel server " + server.HostName + " (" + server.Ip + ")?" +
                        Environment.NewLine +
                        server.ServerInfo,
                        "Ingresso", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

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
                server.ServerInfo.ReadData();

                panel.Controls.Add(tile);
            });
        }
    }
}
