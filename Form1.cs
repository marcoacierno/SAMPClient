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
            InitializeMetroComponents();

            settings = Settings.Read();
        }

        private void InitializeMetroComponents()
        {
            mainTabs = new MetroTabControl();
            mainTabs.Dock = DockStyle.Fill;

            var favourites = new MetroTabPage();
            favourites.Text = "Preferiti";

            mainTabs.TabPages.Add(favourites);

            var internet = new MetroTabPage();
            internet.Text = "Internet";

            mainTabs.TabPages.Add(internet);

            var hosted = new MetroTabPage();
            hosted.Text = "Hosted";

            mainTabs.TabPages.Add(hosted);

            var settings = new MetroTabPage();
            settings.Text = "Opzioni";
            mainTabs.TabPages.Add(settings);

            Controls.Add(mainTabs);
        }

    }
}
