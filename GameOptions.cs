//-----------------------------------------------------------------------
// <copyright file="GameOptions.cs" company="GNU">
// 
// This program is free software; you can redistribute it and/or modify it
// Free Software Foundation; either version 2, 
// or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// </copyright>
//-----------------------------------------------------------------------
namespace CodeGreen
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class GameOptions : Form
    {
        #region datavelden
        private int n = 0;
        private List<DropText> droptexten;
        private Misc misc;

        private const int SPEED = 10;
        #endregion

        #region constructor
        /// <summary>
        /// Init new instance of GameOptions class.
        /// </summary>
        public GameOptions()
        {
            InitializeComponent();
            SetSettings();

            this.CheckControllerEnabled();
            droptexten = new List<DropText>();
            misc = new Misc();

            tbVendorID.Text = CodeGreen.Properties.Settings.Default.controllerDefaultVendorID;
            tbProductID.Text = CodeGreen.Properties.Settings.Default.controllerDefaultProductID;
            cbxSwitchXaxis.Enabled = CodeGreen.Properties.Settings.Default.controllerSwitchXasix;
        }

        #endregion

        #region properties
        #endregion

        #region methoden
        /// <summary>
        /// Set bigcheckbox to display the currrent settings.
        /// </summary>
        private void SetSettings()
        {
            if (CodeGreen.Properties.Settings.Default.music)
            {
                this.bcbxMusic.IsChecked = true;
            }
            if (CodeGreen.Properties.Settings.Default.sound)
            {
                this.bcbxSound.IsChecked = true;
            }
            if (CodeGreen.Properties.Settings.Default.controller)
            {
                this.bcbxController.IsChecked = true;
            }
        }

        private void TimerTextEffect_Tick(object sender, EventArgs e)
        {
            lblTextOptions.Text = misc.TypeWordEffect("Options");

            this.updateDropText();
            n++;
            if (n == 4)
            {
                newDropText();
                n = 0;
            }
        }

        private void newDropText()
        {
            if (this.droptexten.Count < 100)
            {
                DropText newdroptext;
                Random ran = new Random();
                int locX = ran.Next(10, this.ClientRectangle.Width - 10);
                int ncolor = ran.Next(0, 3);
                string strcodegreen = "S\r\nN\r\nI\r\nO\r\nT\r\nP\r\nO";
                switch (ncolor)
                {
                    case 0:
                        newdroptext = new DropText(strcodegreen, Brushes.Green, locX);
                        break;
                    case 1:
                        newdroptext = new DropText(strcodegreen, Brushes.LightGreen, locX);
                        break;
                    case 2:
                        newdroptext = new DropText(strcodegreen, Brushes.DarkGreen, locX);
                        break;
                    default:
                        newdroptext = new DropText(strcodegreen, Brushes.Green, locX);
                        break;
                }
                this.droptexten.Add(newdroptext);
            }
        }

        private void updateDropText()
        {
            for (int i = 0; i < this.droptexten.Count; i++)
            {
                this.droptexten[i].Location = new Point(this.droptexten[i].Location.X, this.droptexten[i].Location.Y + SPEED);
                if (this.droptexten[i].Location.Y + 20 > this.ClientRectangle.Height)
                {
                    this.droptexten.Remove(this.droptexten[i]);
                }
            }
            this.Refresh();
        }

        private void GameOptions_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Save settings and return to main menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbBackMenu_Click(object sender, EventArgs e)
        {
            CodeGreen.Properties.Settings.Default.Save();

            this.Hide();
            GameMenu gm = new GameMenu();
            gm.Show();
        }

        private void GameOptions_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Font font = new Font("Arail", 10);
            for (int i = 0; i < this.droptexten.Count; i++)
            {
                if (i < 100)
                {
                    g.DrawString(this.droptexten[i].Text, font, this.droptexten[i].Color, this.droptexten[i].Location);
                }
            }
        }

        /// <summary>
        /// Check if the remote controller is enabled.
        /// If so then enable the textbox to change vendor and product id
        /// and the checkbox to switch x axis.
        /// </summary>
        private void CheckControllerEnabled()
        {
            if (CodeGreen.Properties.Settings.Default.controller)
            {
                this.tbVendorID.Enabled = true;
                this.tbProductID.Enabled = true;
                this.cbxSwitchXaxis.Enabled = true;
            }
            else
            {
                this.tbVendorID.Enabled = false;
                this.tbProductID.Enabled = false;
                this.cbxSwitchXaxis.Enabled = false;
            }
        }

        private void bcbxMusic_Click(object sender, EventArgs e)
        {
            CodeGreen.Properties.Settings.Default.music = this.bcbxMusic.IsChecked;
        }

        private void bcbxSound_Click(object sender, EventArgs e)
        {
            CodeGreen.Properties.Settings.Default.sound = this.bcbxSound.IsChecked;
        }

        private void bcbxController_Click(object sender, EventArgs e)
        {
            CodeGreen.Properties.Settings.Default.controller = this.bcbxController.IsChecked;
            this.CheckControllerEnabled();
        }

        private void cbxSwitchXaxis_CheckedChanged(object sender, EventArgs e)
        {
            CodeGreen.Properties.Settings.Default.controllerSwitchXasix = this.cbxSwitchXaxis.Checked;
        }

        private void pbBackMenu_MouseEnter(object sender, EventArgs e)
        {
            this.pbBackMenu.Image = CodeGreen.Properties.Resources.knop_backmainmenu_selected;
        }

        private void pbBackMenu_MouseLeave(object sender, EventArgs e)
        {
            this.pbBackMenu.Image = CodeGreen.Properties.Resources.knop_backmainmenu;
        }
        #endregion

        
    }
}
