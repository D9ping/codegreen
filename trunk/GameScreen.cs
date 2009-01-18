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
        BANK,
        HUIS
    }
    public partial class GameScreen : Form
    {
        #region datavelden
        public Misc misc;
        public OptionsHandler options;
        public ResourceHandler resourcehandler;
        private int curintroregel, n, timesec, timemin;
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

            PlayerBankaccount = bank.GetByNaam("speler");

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
            gbxHuis.Visible = false;

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

        /// <summary>
        /// Veranderd de getoonde werkbalk
        /// </summary>
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
                case WerkbalkState.HUIS:
                    ToonGB(gbxHuis);
                    tooltip.SetToolTip(this.pbKnopInventory, "open inventory");
                    pbKnopInventory.Image = resourcehandler.loadimage("werkbalkknop_inventory_off.png");
                    tooltip.SetToolTip(this.pbKnopBank, "login bank");
                    pbKnopBank.Image = resourcehandler.loadimage("werkbalkknop_bank_off.png");
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
            //knoppen werkbalk:
            if (sender == pbKnopInventory)
            {
                if (werkbalk != WerkbalkState.INVENTORY) { werkbalk = WerkbalkState.INVENTORY; }
            }
            else if ((sender == pbKnopBank) || (sender == pbBank))
            {
                if (werkbalk != WerkbalkState.BANK) { werkbalk = WerkbalkState.BANK; }
            }

            //huizen:
            else if ((sender == pbHuis1) || (sender == pbHuis2) || (sender == pbHuis3) || (sender == pbHuis4) || (sender == pbHuis5) || (sender == pbHuis6))
            {
                if (werkbalk != WerkbalkState.HUIS)
                {
                    werkbalk = WerkbalkState.HUIS;
                }
                /*
                Huis getHuis = new Huis();
                getHuis.
                lbHuisNaam.Text = huis.Bewonernaam;
                lbHuisIP.Text = huis.IPADRES;                
                if (huis.wifi==true) { lbHuisWifi.Text = "Heeft draadloos netwerk."; }
                else if (huis.Wifi == false) { lbHuisWifi.Text = "Geen draadloos netwerk"; }
                */

            }
            ShowWerkbalk();
        }


        private Huis getHuisInfo(object huis)
        {

            if (huis == pbHuis1)
            {

            }
            else if (huis == pbHuis2)
            {

            }

            return null;
        }
        private void VeranderVenster(object sender, EventArgs e)
        {
            //winkel is een groepbox
            if ((sender == pbSoftwareshop) || (sender == pbKnopshop))
            {
                gbxShop.Visible = !gbxShop.Visible;
                if (gbxShop.Visible == true) { pbKnopshop.Image = resourcehandler.loadimage("werkbalkknop_shop_off.png"); }
                else if (gbxShop.Visible == false) { pbKnopshop.Image = resourcehandler.loadimage("werkbalkknop_shop_on.png"); }
            }

            else if (sender == pbHuis1)
            {
                {
                    gbxHuis.Visible = true;
                    //todo: haal informatie huis op.
                }
            }
        }

        private void btnBuyWifiwepcracker_Click(object sender, EventArgs e)
        {
            pbItemWifiWEPCracker.Visible = true;
            //TODO: zoek CC of GPL 'ping' kassa geluid van iets gekocht.
            resourcehandler.playsound("buy.wav", true);
            //TODO: Van de speler wordt geld af gehaalt,
            //if (GamePlayer.geldopnemen(200) == true) { pbItemWepWifiCracker.Visible = true; }            
        }

        private void btnBuyneworkscanner_Click(object sender, EventArgs e)
        {
            pbItemNetworkScanner.Visible = true;

            resourcehandler.playsound("buy.wav", true);
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
            n++;

            this.truckdrive(n);

            if (n == 20)
            {
                n = 0;
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
        }

        /// <summary>
        /// tekent de bus op nieuwe plek, CPU intensief!!
        /// </summary>
        private void truckdrive(int n)
        {
            int Ytruck = pbTruck1.Location.Y;
            int Xtruck = pbTruck1.Location.X + 1;
            
            if ((Xtruck > 270) && (Xtruck < 290)) { Ytruck = pbTruck1.Location.Y + 1; }
            else if (Xtruck > 675)
            {
                int maxn = 1000 / this.TimerGametime.Interval;
                for (int i = 0; i < maxn; i=i+2)
			        {
			            if (n==i)
                        { 
                            Ytruck = pbTruck1.Location.Y - 1; 
                        }
                        //else { Ytruck = pbTruck1.Location.Y; }
                    }
            }
            else if (Xtruck > 770) { Xtruck = 270; Ytruck = 306; }
            else { Ytruck = pbTruck1.Location.Y; }

            pbTruck1.Location = new Point(Xtruck, Ytruck);

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


        private void btnKoopWorm_Click(object sender, EventArgs e)
        {
            //todo
        }

        public void inithuizen()
        {
            try
            {
                Huis huis1 = new Huis("naam", "naam1", "12.23.34.45", true, "naam1", true, true, false, false);
            }
            catch (Exception)
            {
                misc.ToonBericht(6);
            }
        }


        #endregion
    }

}
