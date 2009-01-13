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
        OptionsHandler options;
        int curintroregel, timesec, timemin;     
        private string[] intro_regel;
        Bankaccount PlayerBankaccount;
        Communication communication;
        ResourceHandler resourcehandler;
        
        #endregion

        #region constructor
        public GameScreen()
        {
            InitializeComponent();
            intro_regel = new String[5];
            misc = new Misc();
            options = new OptionsHandler();
            resourcehandler = new ResourceHandler();

            PlayerBankaccount = new Bankaccount("hacker", "12.45.87.355", 0, 100);

            //communicatie wordt alleen gemaakt als optie voor controller aan staat(standaard) 
            if (options.controller_enabled == true)
            {
                Communication communication = new Communication();
            }
            Size werkbalksize = new Size(620, 80);
            Point werkbalklocation = new Point(160, 480);

            gbxGameInstructions.Size = werkbalksize;
            gbxGameInstructions.Location = werkbalklocation;
            gbxInventory.Size = werkbalksize;
            gbxInventory.Location = werkbalklocation;
            gbxInformatieHuis.Size = werkbalksize;
            gbxInformatieHuis.Location = werkbalklocation;
            gbxShop.Size = werkbalksize;
            gbxShop.Location = werkbalklocation;
            gbxBank.Size = werkbalksize;
            gbxBank.Location = werkbalklocation;
        }
        #endregion

        #region properties

        #endregion

        #region methoden
        private void GameScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }               

        private void ToonGB(GroupBox showGB)
        {
            gbxGameInstructions.Visible = false;
            gbxInventory.Visible = false;
            gbxShop.Visible = false;
            gbxBank.Visible = false;
            gbxInformatieHuis.Visible = false;
            showGB.Visible = true;
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
                if (werkbalk == WerkbalkState.INVENTORY)
                {
                    ShowWerkbalk();                      
                }
                else
                {
                    werkbalk = WerkbalkState.INVENTORY;
                    ShowWerkbalk();                    
                }
            }
            else if ((sender == pbKnopBank) || (sender == pbBank))
            {
                if (werkbalk == WerkbalkState.BANK)
                {
                    ShowWerkbalk();                                                                
                }
                else
                {
                    werkbalk = WerkbalkState.BANK;
                    ShowWerkbalk();                                                            
                }
            }
            else if ((sender == pbSoftwareshop) || (sender == pbKnopshop))
            {
                if (werkbalk == WerkbalkState.SHOP)
                {
                    ShowWerkbalk();                                        
                }
                else
                {
                    werkbalk = WerkbalkState.SHOP;
                    ShowWerkbalk();
                }
            }
            else if (sender == pbHuis1)
            {
                if (werkbalk == WerkbalkState.HUIS)
                {
                    ShowWerkbalk();                    
                }
                else
                {
                    werkbalk = WerkbalkState.HUIS;
                    ShowWerkbalk();
                }

            }             
        }

        private void btnBuyWifiwepcracker_Click(object sender, EventArgs e)
        {
            //if (GamePlayer.geldopnemen(200) == true) { pbItemWepWifiCracker.Visible = true; }            
        }

        private void btnBuyneworkscanner_Click(object sender, EventArgs e)
        {
            pbItemNetworkScanner.Visible = true;
        }

        private void btnBuynetworksniffer_Click(object sender, EventArgs e)
        {            
            if (options.sound_enabled == true)
            {
                System.Media.SoundPlayer myPlayer = new System.Media.SoundPlayer();
                myPlayer.SoundLocation = "sound_sold.wav";
                myPlayer.Play();
            }
            pbItemNetworkSniffer.Visible = true;
        }        

        /// <summary>
        /// update gametimer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerGametime_Tick(object sender, EventArgs e)
        {
            timesec++;
            if (timesec < 60)
            {
                if (timemin == 0) { lbPlayerTime.Text = timesec + "s";  }
                else { lbPlayerTime.Text = timemin + "m " + timesec + "s"; }
            }
            else
            {
                timemin++;
                timesec = 0;
                lbPlayerTime.Text = timemin + "m " + timesec + "s";
            }
        }        

        /// <summary>
        /// Data verwerken van de remote controller.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data">1 = omhoog, 2 = omlaag, 4 = links, 8 = rechts</param>
        private void usb_OnDataRecieved(object sender, byte[] data)
        {
            communication.VerwerkData(data);
            //moet terug gegeven welk huis of de bank geselecteerd is.
        }

        

        #endregion
    }

}
