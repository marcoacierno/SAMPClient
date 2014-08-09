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
        private MetroColorStyle[] colors =
        {
            MetroColorStyle.Red,
            MetroColorStyle.Blue,
            MetroColorStyle.Green,
            MetroColorStyle.Yellow,
            MetroColorStyle.Pink,
            MetroColorStyle.Magenta,
            MetroColorStyle.Orange,
            MetroColorStyle.Lime,
        };

        /// <summary>
        /// A reference to the user settings
        /// </summary>
        private Settings settings;
        /// <summary>
        /// It contains loaded servers with a reference to their tile in the layout
        /// </summary>
        private Dictionary<Server, MetroTile> serversDictionary = new Dictionary<Server, MetroTile>();

        public static string Version = "Beta 1";

        public Main()
        {
            InitializeComponent();
            new Timer(UpdateServersInfo, null, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(10));

            settings = Settings.Read();
            Text = "SA-MP Client (" + Version + ") - " + settings.UserNickname;

            RestoreDefaultData();

            LoadNewServerList(Favourites.Read().Servers);
            DrawServerTitles(flowLayoutPanel1);
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            settings.UserNickname = nicknameTextBox.Text;
            settings.GTALocation = gtaLocationTextBox.Text;
            settings.AutoSaveRconPassword = savePasswordRcon.Checked;
            settings.AutoSaveServerPassword = saveServerPassword.Checked;

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

        public void UpdateServersInfo(object obj)
        {
            // todo: improve it
            serversDictionary.Keys.ToList().ForEach(server => server.ServerInfo.ReadData(OnServerInfoUpdate));
            
            DrawServerTitles(flowLayoutPanel1);
        }

        private void OnServerInfoUpdate(object sender, EventArgs args)
        {
            var server = (Server) sender;
            Debug.WriteLine("Server (" + server.Ip + ":" + server.Port + ") has been updated");
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
            foreach(var pair in serversDictionary)
            {
                var server = pair.Key;
                var tile = pair.Value;

                if (tile == null)
                {
                    var metroTile = new MetroTile
                    {
                        Text = server.HostName + Environment.NewLine + server.Ip + Environment.NewLine +
                               "Gamemode: " + server.ServerInfo.Gamemode + Environment.NewLine +
                               "Map: " + server.ServerInfo.MapName,
                        Size = new Size(152, 137),
                        Style = colors[new Random().Next(0, colors.Length)],
                    };
                    metroTile.Click += (sender, e) =>
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

                    serversDictionary[server] = metroTile;
                    panel.Controls.Add(metroTile);
                    return;
                }

                tile.Text = server.HostName + Environment.NewLine + server.Ip + Environment.NewLine +
                            "Gamemode: " + server.ServerInfo.Gamemode + Environment.NewLine +
                            "Map: " + server.ServerInfo.MapName;
            }
        }

        private void LoadNewServerList(List<Server> list)
        {
            serversDictionary.Clear();
            list.ForEach(server => serversDictionary.Add(server, null));
        }
    }
}
