using System;
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
        bool sound_enabled = true;
        bool controller_enabled = true;
        #endregion

        #region constructor
        public GameOptions()
        {
            InitializeComponent();
            misc = new Misc();
        }
        #endregion

        #region methoden
        private void GameOptions_Shown(object sender, EventArgs e)
        {
            this.TimerTextEffect.Enabled = true;            
        }

        private void knop_hover(object sender, EventArgs e)
        {
            try
            {
                if (sender == pbBackMenu)
                {
                    pbBackMenu.Image = Image.FromFile("..\\..\\afb\\knop_backmainmenu_selected.png");
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
                    misc.ToonBericht(2);
                }

            }
            catch (Exception)
            {
                
                throw;
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

        #endregion

        private void pbBackMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu gm = new frmMenu();
            gm.Show();
        }

        private void lblOptionSound_Click(object sender, EventArgs e)
        {
            if (sound_enabled==true)
            {
                pbStateSound.Image = Image.FromFile("..\\..\\afb\\checkbox_off.png");
                sound_enabled = false;
            }
            else if (sound_enabled==false)
            {
                pbStateSound.Image = Image.FromFile("..\\..\\afb\\checkbox_on.png");
                sound_enabled = true;
            }
        }

        private void lbOptionController_Click(object sender, EventArgs e)
        {
            if (controller_enabled == true)
            {
                pbStateController.Image = Image.FromFile("..\\..\\afb\\checkbox_off.png");
                controller_enabled = false;
            }
            else if (controller_enabled == false)
            {
                pbStateController.Image = Image.FromFile("..\\..\\afb\\checkbox_on.png");
                controller_enabled = true;
            }
        }
    }
}
