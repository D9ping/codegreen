using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CodeGreen
{
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
                this.pbStateSound.Image = resourceshandler.loadimage("checkbox_on.png");
            }
            else 
            {
                this.pbStateSound.Image = resourceshandler.loadimage("checkbox_off.png");
            }
            if (options.GetSettingBool("controller") == true) 
            {
                this.pbStateController.Image = resourceshandler.loadimage("checkbox_on.png");
            }
            else 
            { 
                this.pbStateController.Image = resourceshandler.loadimage("checkbox_off.png");
            }
        }
        #endregion

        #region properties
        #endregion

        #region methoden

        private void knop_hover(object sender, EventArgs e)
        {
            try
            {
                if (sender == pbBackMenu)
                {
                    pbBackMenu.Image = resourceshandler.loadimage("knop_backmainmenu_selected.png");
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
                    pbBackMenu.Image = resourceshandler.loadimage("knop_backmainmenu.png");
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
                pbStateSound.Image = resourceshandler.loadimage("checkbox_off.png");
                if (options.UpdateSetting("Sound", false) == false) { misc.ToonBericht(3); }
            }
            else if (options.sound_enabled == false)
            {
                pbStateSound.Image = resourceshandler.loadimage("checkbox_on.png");
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
                pbStateController.Image = resourceshandler.loadimage("checkbox_off.png");
                if (options.UpdateSetting("Controller", false) == false) 
                {
                    misc.ToonBericht(3); 
                }
            }
            else if (options.controller_enabled == false)
            {
                pbStateController.Image = resourceshandler.loadimage("checkbox_on.png");
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
        #endregion

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


    }
}
