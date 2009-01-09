using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UsbLibrary; //ondersteuning voor atmel joystick

namespace CodeGreen
{
    public partial class GameScreen : Form
    {
        #region datavelden
        Misc misc;        
        int curintroregel;
        int gametime;
        private string[] intro_regel;
        #endregion

        #region constructor
        public GameScreen()
        {
            InitializeComponent();
            intro_regel = new String[5];
            misc = new Misc();
        }
        #endregion

        #region methoden
        private void GameScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }        

        private void GameScreen_Shown(object sender, EventArgs e)
        {            
            TimerTextEffect.Enabled = true;
            TimerGametime.Enabled = true;
        }        

        private void TimerTextEffect_Tick(object sender, EventArgs e)
        {            
            intro_regel[0] = "This is your neighourhood.";
            intro_regel[1] = "Your objective is to take the microsoft server down.";
            intro_regel[2] = "To do this, you will need to setup a bot network";
            intro_regel[3] = "by hacking as many house in your neighhood as possible.";
            intro_regel[4] = "It's time to take control of that micr$oft bastards.";

            for (int i = 0; i < 5; i++)
            {
                if (lblIntroTextLine1.Text == (intro_regel[i] + "_"))
                {
                    misc.Curlenword = 0;
                    curintroregel++;
                }  
            }


            for (int i = 0; i < 5; i++)
            {
                if (curintroregel == i)
                {
                    lblIntroTextLine1.Text = misc.TypeWordEffect(intro_regel[i]);
                }                
            }           
        }

        /// <summary>
        /// Deze methode verander groepbox op de werkbalk afhankelijk van het object dat als parameter meegeven wordt.
        /// </summary>
        /// <param name="sender">Object waarop geklikt(of eventeeul ander event) is.</param>
        /// <param name="e"></param>
        private void VeranderWerkbalk(object sender, EventArgs e)
        {
            if (sender == pbKnopInventory)
            {
                if (gbxInventory.Visible == true)
                {
                    gbxInventory.Visible = false;
                }
                else
                {
                    gbxInventory.Visible = true;
                }
            }
            /*** todo ***
            else if (sender == pbBank)
            {

            }
             */
        }

        private void btnBuyWifiwepcracker_Click(object sender, EventArgs e)
        {
            pbItemWepWifiCracker.Visible = true;
        }

        private void btnBuyneworkscanner_Click(object sender, EventArgs e)
        {
            pbItemNetworkScanner.Visible = true;
        }

        private void btnBuynetworksniffer_Click(object sender, EventArgs e)
        {
            GameOptions go = GameOptions();
            if (go.Optionsound == true)
            {
                //todo: speel geluid
            }
            pbItemNetworkSniffer.Visible = true;
        }        

        private void TimerGametime_Tick(object sender, EventArgs e)
        {
            gametime++;
            if (gametime > 60)
            {

                lbPlayerTime.Text = Convert.ToString(gametime) + "s";
            }
            else
            {
                lbPlayerTime.Text = Convert.ToString(gametime) + "s";
            }
        }

        #endregion
    }

}
