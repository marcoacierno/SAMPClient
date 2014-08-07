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

        }
    }
}
