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
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            InitializeMetroComponents();
        }

        private void InitializeMetroComponents()
        {
            MetroTabControl tabServerTypes = new MetroTabControl();
            tabServerTypes.Dock = DockStyle.Fill;

            MetroTabPage favourites = new MetroTabPage();
            favourites.Text = "Preferiti";

            tabServerTypes.TabPages.Add(favourites);

            MetroTabPage internet = new MetroTabPage();
            internet.Text = "Internet";

            tabServerTypes.TabPages.Add(internet);

            MetroTabPage hosted = new MetroTabPage();
            hosted.Text = "Hosted";

            tabServerTypes.TabPages.Add(hosted);

            MetroTabPage settings = new MetroTabPage();
            settings.Text = "Opzioni";
            tabServerTypes.TabPages.Add(settings);

            this.Controls.Add(tabServerTypes);
        }
    }
}
