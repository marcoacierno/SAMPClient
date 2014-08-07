using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework;
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
            restoreDefaultData();
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

        private void restoreDefaultData()
        {
            nicknameTextBox.Text = settings.UserNickname;
            gtaLocationTextBox.Text = settings.GTALocation;
            savePasswordRcon.Checked = settings.AutoSaveRconPassword;
            saveServerPassword.Checked = settings.AutoSaveServerPassword;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            restoreDefaultData();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (selectGTAPositionDialog.ShowDialog() == DialogResult.OK)
            {
                string directory = selectGTAPositionDialog.SelectedPath;
                gtaLocationTextBox.Text = directory;
            }
        }
    }
}
