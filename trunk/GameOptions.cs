﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeGreen
{
    public partial class GameOptions : Form
    {
        #region datavelden
        Misc misc;
        OptionsHandler options;
        ResourceHandler resourceshandler;
        #endregion

        #region constructor
        public GameOptions()
        {
            InitializeComponent();
            misc = new Misc();
            options = new OptionsHandler();
            resourceshandler = new ResourceHandler();
        }
        #endregion

        #region properties
        #endregion

        #region methoden
        private void GameOptions_Shown(object sender, EventArgs e)
        {
            this.TimerTextEffect.Enabled = true;

            if (options.sound_enabled == true) { this.pbStateSound.Image = resourceshandler.loadimage("checkbox_on.png"); }
            else if (options.sound_enabled == false) { this.pbStateSound.Image = resourceshandler.loadimage("checkbox_off.png"); }

            if (options.controller_enabled == true) { this.pbStateSound.Image = resourceshandler.loadimage("checkbox_on.png"); }
            else if (options.controller_enabled == false) { this.pbStateSound.Image = resourceshandler.loadimage("checkbox_off.png"); }
        }

        private void knop_hover(object sender, EventArgs e)
        {
            try
            {
                if (sender == pbBackMenu)
                {
                    pbBackMenu.Image = resourceshandler.loadimage("knop_backmainmenu_selected.png");
                    //Image.FromFile("..\\..\\afb\\knop_backmainmenu_selected.png");
                }
                else if (sender == lblOptionSound)
                {
                    lblOptionSound.ForeColor = Color.Yellow;
                }
                else if (sender == lbOptionController)
                {
                    lbOptionController.ForeColor = Color.Yellow;
                }
                else
                {
                    misc.ToonBericht(2);
                }
            }
            catch
            {
                misc.ToonBericht(1);
            }
        }

        public void knop_normal(object sender, EventArgs e)
        {
            try
            {
                if (sender == pbBackMenu)
                {
                    pbBackMenu.Image = Image.FromFile("..\\..\\afb\\knop_backmainmenu.png");
                }
                else if (sender == lblOptionSound)
                {
                    lblOptionSound.ForeColor = Color.Lime;
                }
                else if (sender == lbOptionController)
                {
                    lbOptionController.ForeColor = Color.Lime;
                }
                else
                {
                    misc.ToonBericht(1);
                }

            }
            catch (Exception)
            {
                misc.ToonBericht(2);
            }
        }

        private void TimerTextEffect_Tick(object sender, EventArgs e)
        {
            lblTextOptions.Text = misc.TypeWordEffect("Options");
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
                pbStateSound.Image = resourceshandler.loadimage("checkbox_off.png");
                //Image.FromFile("..\\..\\afb\\checkbox_off.png");
                if (options.UpdateSetting("sound", false) == false) { misc.ToonBericht(3); }
            }
            else if (options.sound_enabled == false)
            {
                pbStateSound.Image = resourceshandler.loadimage("checkbox_on.png");
                //Image.FromFile("..\\..\\afb\\checkbox_on.png");
                if (options.UpdateSetting("sound", true) == false) { misc.ToonBericht(3); }
            }
        }

        private void lbOptionController_Click(object sender, EventArgs e)
        {
            if (options.controller_enabled == true)
            {
                pbStateController.Image = resourceshandler.loadimage("checkbox_off.png");
                //Image.FromFile("..\\..\\afb\\checkbox_off.png");
                if (options.UpdateSetting("controller", false) == false) { misc.ToonBericht(3); }
            }
            else if (options.controller_enabled == false)
            {
                pbStateController.Image = resourceshandler.loadimage("checkbox_on.png");
                //Image.FromFile("..\\..\\afb\\checkbox_on.png");
                if (options.UpdateSetting("sound", true) == false) { misc.ToonBericht(3); }
            }
        }
        #endregion


    }
}
