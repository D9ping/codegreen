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
        private OptionsHandler options;
        private ResourceHandler resourceshandler;

        private const int SPEED = 10;
        #endregion

        #region constructor
        /// <summary>
        /// Init new instance of GameOptions class.
        /// </summary>
        public GameOptions()
        {
            InitializeComponent();
            droptexten = new List<DropText>();
            misc = new Misc();
            options = new OptionsHandler();
            resourceshandler = new ResourceHandler();

            tbVendorID.Text = options.VendorID;
            tbProductID.Text = options.ProductID;
            if (options.SwitchXaxis == true)
            {
                cbxSwitchXaxis.CheckState = CheckState.Checked;
            }
            if (options.GetSettingBool("sound") == true) 
            {
                //this.pbStateSound.Image = resourceshandler.loadimage("checkbox_on.png");
            }
            else 
            {
                //this.pbStateSound.Image = resourceshandler.loadimage("checkbox_off.png");
            }
            if (options.GetSettingBool("controller") == true) 
            {
                //this.pbStateController.Image = resourceshandler.loadimage("checkbox_on.png");
            }
            else 
            { 
                //this.pbStateController.Image = resourceshandler.loadimage("checkbox_off.png");
            }
        }
        #endregion

        #region properties
        #endregion

        #region methoden
       
        private void tbVendorID_TextChanged(object sender, EventArgs e)
        {
            options.VendorID = tbVendorID.Text;
        }

        private void tbProductID_TextChanged(object sender, EventArgs e)
        {
            options.ProductID = tbProductID.Text;
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

        private void pbBackMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameMenu gm = new GameMenu();
            gm.Show();
        }

        private void lblOptionSound_Click(object sender, EventArgs e)
        {
            if (options.sound_enabled == true)
            {
                if (options.UpdateSetting("Sound", false) == false) { misc.ToonBericht(3); }
            }
            else if (options.sound_enabled == false)
            {
                if (options.UpdateSetting("Sound", true) == false)
                {
                    misc.ToonBericht(3); 
                }
            }
        }

        private void lbOptionController_Click(object sender, EventArgs e)
        {
            if (options.controller_enabled == true)
            {
                if (options.UpdateSetting("Controller", false) == false) 
                {
                    misc.ToonBericht(3); 
                }
            }
            else if (options.controller_enabled == false)
            {
                if (options.UpdateSetting("Controller", true) == false) 
                {
                    misc.ToonBericht(3); 
                }
            }
        }

        private void cbxSwitchXaxis_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSwitchXaxis.Checked == true)
            {
                options.SwitchXaxis = true;
            }
            else
            {
                options.SwitchXaxis = false;
            }
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

        #endregion

    }
}
