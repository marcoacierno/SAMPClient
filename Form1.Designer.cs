using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace SAMPClient
{
    partial class Main
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.metroTabPage4 = new MetroFramework.Controls.MetroTabPage();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.savePasswordRcon = new MetroFramework.Controls.MetroToggle();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.saveServerPassword = new MetroFramework.Controls.MetroToggle();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.gtaLocationTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.nicknameTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.selectGTAPositionDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage4);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(20, 60);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.Padding = new System.Drawing.Point(6, 8);
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(782, 420);
            this.metroTabControl1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.flowLayoutPanel1);
            this.metroTabPage1.Enabled = true;
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(774, 378);
            this.metroTabPage1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Preferiti";
            this.metroTabPage1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            this.metroTabPage1.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(774, 378);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // metroTabPage4
            // 
            this.metroTabPage4.Controls.Add(this.metroButton2);
            this.metroTabPage4.Controls.Add(this.metroButton3);
            this.metroTabPage4.Controls.Add(this.savePasswordRcon);
            this.metroTabPage4.Controls.Add(this.metroLabel4);
            this.metroTabPage4.Controls.Add(this.saveServerPassword);
            this.metroTabPage4.Controls.Add(this.metroLabel3);
            this.metroTabPage4.Controls.Add(this.metroButton1);
            this.metroTabPage4.Controls.Add(this.gtaLocationTextBox);
            this.metroTabPage4.Controls.Add(this.metroLabel2);
            this.metroTabPage4.Controls.Add(this.nicknameTextBox);
            this.metroTabPage4.Controls.Add(this.metroLabel1);
            this.metroTabPage4.Enabled = true;
            this.metroTabPage4.HorizontalScrollbarBarColor = true;
            this.metroTabPage4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.HorizontalScrollbarSize = 10;
            this.metroTabPage4.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage4.Name = "metroTabPage4";
            this.metroTabPage4.Size = new System.Drawing.Size(774, 378);
            this.metroTabPage4.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTabPage4.TabIndex = 3;
            this.metroTabPage4.Text = "Opzioni";
            this.metroTabPage4.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTabPage4.VerticalScrollbarBarColor = true;
            this.metroTabPage4.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.VerticalScrollbarSize = 10;
            this.metroTabPage4.Visible = true;
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(675, 352);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(96, 31);
            this.metroButton2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton2.TabIndex = 12;
            this.metroButton2.Text = "Ripristina";
            this.metroButton2.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.Location = new System.Drawing.Point(573, 352);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(96, 31);
            this.metroButton3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton3.TabIndex = 13;
            this.metroButton3.Text = "Salva";
            this.metroButton3.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButton3.UseSelectable = true;
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // savePasswordRcon
            // 
            this.savePasswordRcon.AutoSize = true;
            this.savePasswordRcon.Location = new System.Drawing.Point(150, 99);
            this.savePasswordRcon.Name = "savePasswordRcon";
            this.savePasswordRcon.Size = new System.Drawing.Size(80, 17);
            this.savePasswordRcon.Style = MetroFramework.MetroColorStyle.Blue;
            this.savePasswordRcon.TabIndex = 11;
            this.savePasswordRcon.Text = "Off";
            this.savePasswordRcon.Theme = MetroFramework.MetroThemeStyle.Light;
            this.savePasswordRcon.UseSelectable = true;
            this.savePasswordRcon.UseVisualStyleBackColor = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(3, 97);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(140, 19);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel4.TabIndex = 10;
            this.metroLabel4.Text = "Salva password RCON";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // saveServerPassword
            // 
            this.saveServerPassword.AutoSize = true;
            this.saveServerPassword.Location = new System.Drawing.Point(150, 76);
            this.saveServerPassword.Name = "saveServerPassword";
            this.saveServerPassword.Size = new System.Drawing.Size(80, 17);
            this.saveServerPassword.Style = MetroFramework.MetroColorStyle.Blue;
            this.saveServerPassword.TabIndex = 9;
            this.saveServerPassword.Text = "Off";
            this.saveServerPassword.Theme = MetroFramework.MetroThemeStyle.Light;
            this.saveServerPassword.UseSelectable = true;
            this.saveServerPassword.UseVisualStyleBackColor = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(3, 74);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(138, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel3.TabIndex = 7;
            this.metroLabel3.Text = "Salva password server";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(744, 44);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(27, 23);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton1.TabIndex = 6;
            this.metroButton1.Text = "...";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // gtaLocationTextBox
            // 
            this.gtaLocationTextBox.Lines = new string[0];
            this.gtaLocationTextBox.Location = new System.Drawing.Point(150, 44);
            this.gtaLocationTextBox.MaxLength = 32767;
            this.gtaLocationTextBox.Name = "gtaLocationTextBox";
            this.gtaLocationTextBox.PasswordChar = '\0';
            this.gtaLocationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.gtaLocationTextBox.SelectedText = "";
            this.gtaLocationTextBox.Size = new System.Drawing.Size(590, 23);
            this.gtaLocationTextBox.Style = MetroFramework.MetroColorStyle.Blue;
            this.gtaLocationTextBox.TabIndex = 5;
            this.gtaLocationTextBox.Theme = MetroFramework.MetroThemeStyle.Light;
            this.gtaLocationTextBox.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(3, 48);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(105, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Posizione di GTA";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // nicknameTextBox
            // 
            this.nicknameTextBox.Lines = new string[0];
            this.nicknameTextBox.Location = new System.Drawing.Point(150, 15);
            this.nicknameTextBox.MaxLength = 32767;
            this.nicknameTextBox.Name = "nicknameTextBox";
            this.nicknameTextBox.PasswordChar = '\0';
            this.nicknameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.nicknameTextBox.SelectedText = "";
            this.nicknameTextBox.Size = new System.Drawing.Size(621, 23);
            this.nicknameTextBox.Style = MetroFramework.MetroColorStyle.Blue;
            this.nicknameTextBox.TabIndex = 3;
            this.nicknameTextBox.Theme = MetroFramework.MetroThemeStyle.Light;
            this.nicknameTextBox.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(3, 15);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(141, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Nickname da utilizzare";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Enabled = true;
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(774, 378);
            this.metroTabPage2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Internet";
            this.metroTabPage2.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            this.metroTabPage2.Visible = false;
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Enabled = true;
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(774, 378);
            this.metroTabPage3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Hosted";
            this.metroTabPage3.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            this.metroTabPage3.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 500);
            this.Controls.Add(this.metroTabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "SA-MP Client";
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage4.ResumeLayout(false);
            this.metroTabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroTabControl metroTabControl1;
        private MetroTabPage metroTabPage1;
        private MetroTabPage metroTabPage2;
        private MetroTabPage metroTabPage3;
        private MetroTabPage metroTabPage4;
        private MetroLabel metroLabel1;
        private MetroTextBox nicknameTextBox;
        private MetroTextBox gtaLocationTextBox;
        private MetroLabel metroLabel2;
        private MetroButton metroButton1;
        private MetroLabel metroLabel3;
        private MetroToggle saveServerPassword;
        private MetroToggle savePasswordRcon;
        private MetroLabel metroLabel4;
        private MetroButton metroButton2;
        private MetroButton metroButton3;
        private FolderBrowserDialog selectGTAPositionDialog;
        private FlowLayoutPanel flowLayoutPanel1;

    }
}

