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
    public enum WerkbalkState
    {
        INSTRUCTIE,
        INVENTORY,
        BANK   
    }
    public partial class GameScreen : Form
    {
        #region datavelden
        public Misc misc;
        public OptionsHandler options;
        public ResourceHandler resourcehandler;

        private int curintroregel, timesec, timemin;
        private string[] intro_regel;
        private Bankaccount PlayerBankaccount;
        private Communication communication;        
        private WerkbalkState werkbalk;
        private Bank bank;
        #endregion

        #region constructor
        public GameScreen()
        {
            InitializeComponent();
            intro_regel = new String[5];
            misc = new Misc();
            options = new OptionsHandler();
            resourcehandler = new ResourceHandler();
            Bank bank = new Bank();
            bank.initbankaccounts();
            PlayerBankaccount = bank.GetByName("speler");

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
            if (resourcehandler.playsound("backgroundmusic.wav", true) == false) { misc.ToonBericht(5); }
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
                    TimerTextEffect.Interval = 2000;
                    curintroregel++;
                }
                else
                {
                    TimerTextEffect.Interval = 100;
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

        public void ShowWerkbalk()
        {
            switch (werkbalk)
            {
                case WerkbalkState.INSTRUCTIE:
                    ToonGB(gbxGameInstructions);
                    tooltip.SetToolTip(this.pbKnopInventory, "open inventory");
                    pbKnopInventory.Image = resourcehandler.loadimage("werkbalkknop_inventory_off.png");
                    tooltip.SetToolTip(this.pbKnopBank, "login bank");
                    pbKnopBank.Image = resourcehandler.loadimage("werkbalkknop_bank_off.png");
                    tooltip.SetToolTip(this.pbKnopshop, "go to shop");
                    pbKnopshop.Image = resourcehandler.loadimage("werkbalkknop_shop_on.png");
                    break;
                case WerkbalkState.INVENTORY:
                    ToonGB(gbxInventory);
                    tooltip.SetToolTip(this.pbKnopInventory, "close inventory");
                    pbKnopInventory.Image = resourcehandler.loadimage("werkbalkknop_inventory_on.png");
                    tooltip.SetToolTip(this.pbKnopBank, "login bank");
                    pbKnopBank.Image = resourcehandler.loadimage("werkbalkknop_bank_off.png");
                    tooltip.SetToolTip(this.pbKnopshop, "go to shop");
                    pbKnopshop.Image = resourcehandler.loadimage("werkbalkknop_shop_off.png");
                    break;
                case WerkbalkState.BANK:
                    ToonGB(gbxBank);
                    tooltip.SetToolTip(this.pbKnopInventory, "open inventory");
                    pbKnopInventory.Image = resourcehandler.loadimage("werkbalkknop_inventory_off.png");
                    tooltip.SetToolTip(this.pbKnopBank, "logout bank");
                    pbKnopBank.Image = resourcehandler.loadimage("werkbalkknop_bank_on.png");
                    tooltip.SetToolTip(this.pbKnopshop, "go to shop");
                    pbKnopshop.Image = resourcehandler.loadimage("werkbalkknop_shop_off.png");
                    break;
            }

        }

        /// <summary>
        /// Deze methode verander groepbox op de werkbalk afhankelijk van het object dat als parameter meegeven wordt.
        /// </summary>
        /// <param name="sender">Object waarop geklikt(of eventeeul ander event) is.</param>
        /// <param name="e"></param>
        private void VeranderWerkbalk(object sender, EventArgs e)
        {
            //op werkbalk
            if (sender == pbKnopInventory)
            {
                if (werkbalk != WerkbalkState.INVENTORY)
                {
                    werkbalk = WerkbalkState.INVENTORY;
                }                           
            }
            else if ((sender == pbKnopBank) || (sender == pbBank))
            {
                if (werkbalk != WerkbalkState.BANK)
                {
                    werkbalk = WerkbalkState.BANK;
                }        
            }
            //groupbox in het midden van gamescreen
            else if ((sender == pbSoftwareshop) || (sender == pbKnopshop))
            {
                if (gbxShop.Visible == true)
                {
                    gbxShop.Visible = false;
                    pbKnopshop.Image = resourcehandler.loadimage("");
                }
                else if (gbxShop.Visible == false)
                {
                    gbxShop.Visible = true;
                    pbKnopshop.Image = resourcehandler.loadimage("");
                }
            }
            else if (sender == pbHuis1)
            {
                
                    gbxInformatieHuis.Visible = true;
                    
                    
                    //todo: haal informatie huis op.
                }

            }
            ShowWerkbalk();
        }

        private void btnBuyWifiwepcracker_Click(object sender, EventArgs e)
        {
            //if (GamePlayer.geldopnemen(200) == true) { pbItemWepWifiCracker.Visible = true; }            
        }

        private void btnBuyneworkscanner_Click(object sender, EventArgs e)
        {
            pbItemNetworkScanner.Visible = true;
            resourcehandler.playsound("missngod.wav", true);
        }

        private void btnBuynetworksniffer_Click(object sender, EventArgs e)
        {
            if (options.sound_enabled == true)
            {
                //zoek een geluid voor iets dat verkocht is.
                //resourcehandler.playsound("");                                
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
                if (timemin == 0) { lbPlayerTime.Text = timesec + "s"; }
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

        private void btnKoopWorm_Click(object sender, EventArgs e)
        {

        }
    }

}
