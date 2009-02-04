﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using UsbLibrary; //ondersteuning voor joystick

namespace CodeGreen
{

    public partial class GameScreen : Form
    {
        private enum WerkbalkState
        {
            INSTRUCTIE,
            INVENTORY,
            BANK,
            SHOP,
            HUIS
        }

        #region datavelden
        private int n, timesec, timemin;
        private String huisBewoner;
        private bool showshopintro = true;
        private bool IsConnected = false;
        public Misc misc;
        public OptionsHandler options;
        public ResourceHandler resourcehandler;
        public Communication communication;
        private Inventory inventory;        
        private Bankaccount Speler;        
        private WerkbalkState werkbalk;
        private Bank bank;
        private List<Huis> huizen; 
                       
        #endregion

        #region constructor
        public GameScreen()
        {
            InitializeComponent();            

            bank = new Bank();
            misc = new Misc();
            inventory = new Inventory();
            options = new OptionsHandler();
            resourcehandler = new ResourceHandler();
            huizen = new List<Huis>();

            resetgame();

            initController();                        

            Size werkbalksize = new Size(620, 80);
            Point werkbalklocation = new Point(160, 480);
            gbxGameInstructions.Size = werkbalksize;
            gbxGameInstructions.Location = werkbalklocation;
            gbxWBInventory.Size = werkbalksize;
            gbxWBInventory.Location = werkbalklocation;
            gbxWBBank.Size = werkbalksize;
            gbxWBBank.Location = werkbalklocation;
            gbxWBShop.Size = werkbalksize;
            gbxWBShop.Location = werkbalklocation;
            gbxWBHuis.Size = werkbalksize;
            gbxWBHuis.Location = werkbalklocation;
        }
        #endregion

        #region properties
        #endregion

        #region methoden
        private void resetgame()
        {
            inventory.youritems.Clear();
            huizen.Clear();
            initHuizen();

            timesec = 0;
            timemin = 0;
            
            UpdateStateKnopSound();
            
            Speler = bank.GetByNaam("speler");            
        }

        /// <summary>
        /// Maak alle huizen aan.
        /// </summary>
        private void initHuizen()
        {
            try
            {                
                Huis[] huis = new Huis[5];
                huis[0] = new Huis(pbHuis1, "Your", "33.23.34.45", true, "linksystems", false, true, false);                
                huis[1] = new Huis(pbHuis2, "Jan de Vries", "66.23.34.45", true, "devries", true, false, false);
                huis[2] = new Huis(pbHuis3, "Marrieke", "100.11.22.33", true, "netgears", false, true, true);
                huis[3] = new Huis(pbHuis4, "Pieter", "14.23.34.45", false, "", true, true, true);
                huis[4] = new Huis(pbHuis5, "Roel", "68.23.34.45", true, "draadloos324098", false, true, false);                
                huizen.AddRange(huis);
                settooltiphuizen();
            }
            catch (Exception) { misc.ToonBericht(6); }
        }        

        /// <summary>
        /// Heef elk huis een tooltip.
        /// </summary>
        private void settooltiphuizen()
        {
            if (IsItemInventory("netwerkscanner")==true)
            {
                if (inventory.getItemInventory("netwerkscanner").Active == true)
                {
                    foreach (Huis huis in huizen)
                    {
                        tooltip.SetToolTip((Control)huis.Huisobj, huis.Naam + " house \r\n IP: " + huis.IPAdres);
                    }
                }
            }
            else
            {
                foreach (Huis huis in huizen)
                {
                    tooltip.SetToolTip((Control)huis.Huisobj, huis.Naam + " house");
                }
            }
        }
        
        /// <summary>
        /// Verbinding met controller opzetten en info. tonen.
        /// </summary>
        private void initController()
        {
            btnReconnect.Visible = false;
            if (options.controller_enabled == true)
            {
                communication = new Communication();

                btnReconnect.Visible = true;
                if (ConnectController1() == true)
                {
                    //if (werkbalk != WerkbalkState.INSTRUCTIE) { GetControllerHuis(); }
                    GetControllerHuis();
                    lbControllerInfo.Text = "Connected with controller\r\n" +
                    "             VendorID: " + options.VendorID + "\r\n" +
                    "             ProductID: " + options.ProductID;                                        
                }
                else
                {
                    lbControllerInfo.Text = "Could not connect\r\n with controller";
                }
            }
        }

        /// <summary>
        /// Verbind met controller
        /// </summary>
        /// <returns></returns>
        public bool ConnectController1()
        {
            if (!IsConnected)
            {
                IsConnected = usb.Connect(this, Int32.Parse(options.VendorID, System.Globalization.NumberStyles.HexNumber),
                Int32.Parse(options.ProductID, System.Globalization.NumberStyles.HexNumber));
                return IsConnected;
            }
            else { return false; }
        }

        /// <summary>
        /// teken rondje op de juiste plek
        /// </summary>
        private void GetControllerHuis()
        {            
            pbHuis1.Image= resourcehandler.loadimage("not_selected.png");
            pbHuis2.Image= resourcehandler.loadimage("not_selected.png");
            pbHuis3.Image= resourcehandler.loadimage("not_selected.png");
            pbHuis4.Image= resourcehandler.loadimage("not_selected.png");
            pbHuis5.Image= resourcehandler.loadimage("not_selected.png");            
            pbBank.Image = resourcehandler.loadimage("not_selected.png");
            pbShop.Image = resourcehandler.loadimage("not_selected.png");
            pbHuisVriend.Image = resourcehandler.loadimage("not_selected.png");

            if (getHuisDoorBewonernaam(communication.GeselecteerdHuis) != null)
            {
                Huis selectedhuis = getHuisDoorBewonernaam(communication.GeselecteerdHuis);
                PictureBox pbhuis = (PictureBox)selectedhuis.Huisobj;
                pbhuis.Image = resourcehandler.loadimage("selected.png");
                pbhuis.SizeMode = PictureBoxSizeMode.StretchImage;
                if (werkbalk != WerkbalkState.INSTRUCTIE) { VeranderWerkbalk(pbhuis, EventArgs.Empty); }
            }
            else if (communication.GeselecteerdHuis == "Bank")
            {
                pbBank.Image = resourcehandler.loadimage("selected.png");
                pbBank.SizeMode = PictureBoxSizeMode.StretchImage;
                VeranderWerkbalk(pbBank, EventArgs.Empty);
            } 
            else if (communication.GeselecteerdHuis == "Shop")
            {
                pbShop.Image = resourcehandler.loadimage("selected.png");
                pbShop.SizeMode = PictureBoxSizeMode.StretchImage;
                VeranderWerkbalk(pbShop, EventArgs.Empty);
            }
            else if (communication.GeselecteerdHuis == "HuisVriend")
            {
                pbHuisVriend.Image = resourcehandler.loadimage("selected.png");
                pbHuisVriend.SizeMode = PictureBoxSizeMode.StretchImage;
                VeranderWerkbalk(pbHuisVriend, EventArgs.Empty);
            }                       
        }

        private void GameScreen_Shown(object sender, EventArgs e)
        {
            TimerTextEffect.Enabled = true;
            TimerGametime.Enabled = true;           
        }

        private void btnReconnect_Click(object sender, EventArgs e)
        {
            initController();
        }

        private void GameScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ToonGB(GroupBox showGB)
        {
            gbxGameInstructions.Visible = false;
            gbxWBInventory.Visible = false;
            gbxWBShop.Visible = false;
            gbxWBBank.Visible = false;
            gbxWBHuis.Visible = false;

            showGB.Visible = true;
        }

        /// <summary>
        /// Veranderd de werkbalk knoppen status (behalve geluid en quit knop)
        /// </summary>
        private void ToonWerkbalkknop(PictureBox ShowPB, String bestandsnaam)
        {
            this.pbKnopBank.Image = resourcehandler.loadimage("werkbalkknop_bank_off.png");
            this.pbKnopInventory.Image = resourcehandler.loadimage("werkbalkknop_inventory_off.png");
            this.pbKnopShop.Image = resourcehandler.loadimage("werkbalkknop_shop_off.png");
            if (ShowPB != null) { ShowPB.Image = resourcehandler.loadimage(bestandsnaam); }
        }

        /// <summary>
        /// Timer voor tekst effecten (CPU intensief)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerTextEffect_Tick(object sender, EventArgs e)
        {
            if (werkbalk == WerkbalkState.INSTRUCTIE)
            {
                btnFriendGift.Visible = false;

                if (misc.HuidigeTekst == "intro")
                {
                    lblIntroTextLine1.Text = misc.TypeTextFull("intro");
                    if (misc.HuidigeRegel > 4)
                    {
                        TimerTextEffect.Enabled = false;
                    }
                }
                else if (misc.HuidigeTekst == "friend")
                {
                    if (IsItemInventory("listbankaccounts") == false)
                    {
                        lblIntroTextLine1.Text = misc.TypeTextFull("friend");
                        if (misc.HuidigeRegel >= 2)
                        {
                            btnFriendGift.Visible = true;
                        }
                        else
                        {
                            btnFriendGift.Visible = false;
                        }
                    }
                    else {
                            lblIntroTextLine1.Text = misc.TypeWordEffect("How is your work coming along ;P?");                       
                    }
                }
                else { misc.ToonBericht(10); }
            }
            else if (werkbalk == WerkbalkState.SHOP)
            {
                if (showshopintro ==true)
                {
                    lbTextShop.Text = misc.TypeWordEffect("Welkom to nixxons shop, for all your hacker tools.");
                }
            }
            else if (werkbalk == WerkbalkState.BANK)
            {
                if ((gbxBanklogin.Visible == true) && (lbSaldo.Visible ==false))
                {
                    lbBanklogininfo.Text = misc.TypeWordEffect("To break in you will need an accountnumber and password.");
                }
                else if (lbSaldo.Visible ==false)
                {
                    lbBanklogininfo.Text = misc.BlinkWordEffect();
                }           
            }
            else if (werkbalk == WerkbalkState.INVENTORY)
            {
                if (lbItemCommandInfo.Text.StartsWith("scanning")==true)
                {
                    if (lbItemCommandInfo.Text.StartsWith("scanning....................................")==true)
                    {
                        if (lbItemCommandInfo.Text.EndsWith("done")==false)
                        {
                            lbItemCommandInfo.Text = lbItemCommandInfo.Text + "done";
                            ActivedItem("netwerkscanner");
                            settooltiphuizen();
                        }
                    }
                    else
                    { lbItemCommandInfo.Text = lbItemCommandInfo.Text + "."; }                    
                }
            }
        }

        /// <summary>
        /// Veranderd de getoonde werkbalk
        /// </summary>
        public void ToonWerkbalk()
        {
            switch (werkbalk)
            {
                case WerkbalkState.INSTRUCTIE:
                    ToonGB(gbxGameInstructions);
                    ToonWerkbalkknop(null, null);
                    VerbergWinkel();
                    gbxBanklogin.Visible = false;
                    misc.Curlenword = 0;                    
                    break;
                case WerkbalkState.INVENTORY:
                    ToonGB(gbxWBInventory);
                    ToonWerkbalkknop(pbKnopInventory, "werkbalkknop_inventory_on.png");
                    VerbergWinkel();
                    gbxBanklogin.Visible = false;
                    if (tbCommand.Text == "") { ToonInventoryItems(); }
                    break;
                case WerkbalkState.BANK:
                    ToonGB(gbxWBBank);
                    ToonWerkbalkknop(pbKnopBank, "werkbalkknop_bank_on.png");
                    VerbergWinkel();
                    gbxBanklogin.Visible = true;
                    misc.Curlenword = 0;
                    lbSaldo.Text = "";
                    lbBanklogininfo.Text = "";
                    break;
                case WerkbalkState.SHOP:
                    ToonGB(gbxWBShop);
                    ToonWerkbalkknop(pbKnopShop, "werkbalkknop_shop_on.png");
                    TekenWinkel();
                    gbxBanklogin.Visible = false;
                    misc.Curlenword = 0;
                    break;
                case WerkbalkState.HUIS:
                    ToonGB(gbxWBHuis);
                    ToonWerkbalkknop(null, null);
                    VerbergWinkel();
                    gbxBanklogin.Visible = false;
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
            this.TimerTextEffect.Enabled = true;
            //knoppen werkbalk:
            if (sender == pbKnopInventory)
            {
                werkbalk = WerkbalkState.INVENTORY;
            }
            else if ((sender == pbKnopBank) || (sender == pbBank))
            {
                if (werkbalk != WerkbalkState.BANK) { werkbalk = WerkbalkState.BANK; }
            }
            else if ((sender == pbShop) || (sender == pbKnopShop))
            {
                if (werkbalk != WerkbalkState.SHOP) { werkbalk = WerkbalkState.SHOP; }
            }
            else if (sender == pbHuisVriend)
            {
                if (werkbalk != WerkbalkState.INSTRUCTIE) { werkbalk = WerkbalkState.INSTRUCTIE; }
                misc.HuidigeRegel = 0;
                lblIntroTextLine1.Text = misc.TypeTextFull("friend");                
            }
            else            
            {
                this.TimerTextEffect.Enabled = false;
                for (int i = 0; i < huizen.Count; i++)
                {
                    if (sender == huizen[i].Huisobj)
                    {
                        if (werkbalk != WerkbalkState.HUIS) { werkbalk = WerkbalkState.HUIS; }                        
                        if (getHuis(sender) == null) { misc.ToonBericht(7); return; }
                        ToonHuisInfo(getHuis(sender));
                    }
                }                
            }
            ToonWerkbalk();
        }

        private Huis getHuis(object huisnm)
        {
            foreach (Huis curhuis in huizen)
            {
                if (curhuis.Huisobj == huisnm)
                {
                    return curhuis;
                }
            }
            return null;
        }

        private Huis getHuisDoorBewonernaam(String bewonernaam)
        {
            foreach (Huis curhuis in huizen)
            {
                if (curhuis.Naam == bewonernaam)
                {
                    return curhuis;
                }
            }
            return null;
        }

        private void resetHuisInfo()
        {
            this.btnCreateBot.Visible = false;
            this.btnGetKeyloggerLog.Visible = false;            
            this.lbTextNaam.Text = "Here lives:";            
            this.lbTextIPadres.Text = "IP adres:";
            this.lbTextWifi.Text = "wifi:";
            this.lbTextWifiSSID.Text = "SSID:";
            this.lbTextWifiWEP.Text = "using WEP:";
            this.lbTextWifiWPA.Text = "using WPA:";
            this.lbTextWindowsUpdatetodate.Text = "Windows uptodate:";
            this.lbTextInfectie.Text = "Infected:";
        }

        /// <summary>
        /// Haal huis informatie op.
        /// </summary>
        private void ToonHuisInfo(Huis huis)
        {
            resetHuisInfo();

            huisBewoner = huis.Naam;
            lbNaam.Text = huisBewoner;            

            if (huis.IsBot == false) { btnCreateBot.Enabled = true; }
            else if (huis.IsBot == true) { btnCreateBot.Enabled = false;  }

            if (huis.Wifi == true)
            {
                lbWifi.Text = "Yes";
                ToonHuisWifi(true);                

                lbWifiSSID.Text = huis.WifiSSID;
                if (huis.WifiWEP == true)
                {                    
                    if (IsItemInventory("wepcracker")==true)
                    {
                        if (huis.Wepcracked==true)
                        {
                            lbWifiWEP.Text = "CRACKED";
                            lbWifiWEP.ForeColor = Color.Red;
                            this.btnCreateBot.Visible = true;
                        }
                        else
                        {
                            lbWifiWEP.Text = "Yes";
                            this.btnCreateBot.Visible = false;
                        }
                    }
                    else { lbWifiWEP.Text = "Yes"; }
                }
                else { lbWifiWEP.Text = "No"; }
                if (huis.WifiWPA == true) { lbWifiWPA.Text = "Yes"; }
                else
                {
                    lbWifiWPA.Text = "No";
                }
            }
            else if (huis.Wifi == false)
            {
                lbWifi.Text = "No";
                ToonHuisWifi(false);
            }

            if (IsItemInventory("keylogger") == true)
            {                
                if (huis.KeyloggerInstalled == true)
                {
                    btnGetKeyloggerLog.Visible = true;
                    btnGetKeyloggerLog.Enabled = true;
                }
                else { btnGetKeyloggerLog.Enabled = false; }
            }
            else
            {
                btnGetKeyloggerLog.Visible = false;
                btnGetKeyloggerLog.Enabled = false;
            }

            if (IsItemInventory("netwerkscanner") ==true)
            {
                lbWindowsuptodate.Visible = true;
                lbTextWindowsUpdatetodate.Visible = true;

                if (inventory.getItemInventory("netwerkscanner").Active == true)
                {
                    lbIPadres.Text = huis.IPAdres;

                    if (huis.WindowsOutdated == true)
                    {
                        this.lbWindowsuptodate.Text = "no";
                        this.lbWindowsuptodate.ForeColor = Color.Red;
                        if (IsItemInventory("worm") == true)
                        {
                            lbInfectie.Visible = true;
                            lbTextInfectie.Visible = true;
                            if (inventory.getItemInventory("worm").Active == true)
                            {
                                this.lbInfectie.Text = "yes";
                                this.lbInfectie.ForeColor = Color.Red;
                                btnCreateBot.Visible = true;
                                if (huis.KeyloggerInstalled == true) { btnGetKeyloggerLog.Enabled = true; }
                                else if (huis.KeyloggerInstalled == false) { btnGetKeyloggerLog.Enabled = false; }
                            }
                        }
                    }
                    else if (huis.WindowsOutdated == false)
                    {
                        this.lbWindowsuptodate.Text = "yes";
                        this.lbWindowsuptodate.ForeColor = Color.Lime;
                        if (IsItemInventory("worm") == true)
                        {
                            lbInfectie.Visible = true;
                            lbTextInfectie.Visible = true;
                            if (inventory.getItemInventory("worm").Active == true)
                            {
                                this.lbInfectie.Text = "no";
                                this.lbInfectie.ForeColor = Color.Lime;
                            }
                        }
                    }
                }
                else if (inventory.getItemInventory("netwerkscanner").Active == false) 
                {
                    lbIPadres.Text = "not scanned"; 
                }
                if (IsItemInventory("coderedvirus") == true)
                {
                    if (inventory.getItemInventory("coderedvirus").Active == true)
                    {
                        btnCreateBot.Visible = true;
                        this.lbInfectie.Text = "yes";
                        this.lbInfectie.ForeColor = Color.Red;
                    }
                }

            }
            else
            {
                lbIPadres.Text = "unknow";
                lbWindowsuptodate.Visible = false;
                lbTextWindowsUpdatetodate.Visible = false;
            }
        }      

        /// <summary>
        /// Kijk of item in inventory zit.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>heeft true terug als wel het geval is.</returns>
        private bool IsItemInventory(String item)
        {
            if (inventory.getItemInventory(item) != null)
            {
                return true;                    
            }
            else
            { 
                return false;
            }
        }

        /// <summary>
        /// Toont wel of niet huis wifi instellingen.
        /// </summary>
        /// <param name="toon"></param>
        private void ToonHuisWifi(bool toon)
        {
            lbTextWifiSSID.Visible = toon;
            lbTextWifiWEP.Visible = toon;
            lbTextWifiWPA.Visible = toon;
            lbWifiSSID.Visible = toon;
            lbWifiWEP.Visible = toon;
            lbWifiWPA.Visible = toon;
            lbWifiWEP.ForeColor = Color.Lime;
            //lbWifiWPA.ForeColor = Color.Lime;
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

            if (n == 1000/TimerGametime.Interval)
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

                if (IsConnected == true)
                {
                    ControllerLedEffecten();
                }
            }

            //spel gewonnen
            if (this.progbarServerload.Value == 100)
            {
                TimerGametime.Enabled = false;
                int geld = Convert.ToInt32(Speler.AccountSaldo);
                lbHighscoreInfo highscore = new lbHighscoreInfo(timemin, timesec, geld);  
                highscore.Show();
                this.Hide();                             
            }
        }

        /// <summary>
        /// Laat ledjes controller knipper aan de hand van hoeveel huizen de server aanvallen.
        /// </summary>
        private void ControllerLedEffecten()
        {
            switch (progbarServerload.Value)
            {
                case 25:
                    if (timesec % 2 == 0) { usb.SendData(communication.Groenledje1(true)); }
                    else { usb.SendData(communication.Groenledje1(false)); }
                    break;
                case 50:
                    if (timesec % 2 == 0) { usb.SendData(communication.Roodledje1(true)); }
                    else { usb.SendData(communication.Roodledje1(false)); }
                    break;
                case 75:
                    if (timesec % 2 == 0) {
                        usb.SendData(communication.Roodledje1(false));
                        usb.SendData(communication.Roodledje2(true));
                    }
                    else {
                        usb.SendData(communication.Roodledje1(true));
                        usb.SendData(communication.Roodledje2(false));
                    }                   
                    break;
                default:
                    usb.SendData(communication.Groenledje1(false));
                    usb.SendData(communication.Roodledje1(false));
                    usb.SendData(communication.Roodledje2(false));
                    break;
            }

        }

        /// <summary>
        /// tekent de bus op nieuwe plek, (CPU intensief)
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
            else if (Xtruck > 770) { Xtruck = 270; Ytruck = 306;
            pbTruck1.Refresh();  }
            else { Ytruck = pbTruck1.Location.Y; }

            pbTruck1.Location = new Point(Xtruck, Ytruck);
        }

        /// <summary>
        /// Data verwerken van de remote controller.  
        /// </summary>        
        /// <param name="data">???</param>
        private void usb_OnDataRecieved(object sender, byte[] data)
        {
            if (options.controller_enabled == true)
            {
                communication.DataAtmelController(data);
                GetControllerHuis();
            }
        }      
       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            gbxBanklogin.Visible = false;
            Bankaccount getaccount = bank.GetByRekening(cbAccountnummer.Text);
            if (cbAccountnummer.Text == "")
            {
                misc.BlinkTekst = "NO ACCESS, enter a account number.";
                lbBanklogininfo.Text = misc.BlinkWordEffect();
            }            
            else if (getaccount==null) {
                misc.BlinkTekst = "NO ACCESS, accountnummer doesn't exist.";
                lbBanklogininfo.Text = misc.BlinkWordEffect();
                cbAccountnummer.Text = "";
            }
            else if (tbAccountPassword.Text == "")
            {
                misc.BlinkTekst = "NO ACCESS, enter a password.";
                lbBanklogininfo.Text = misc.BlinkWordEffect();                
            }
            else if (getaccount.AccountPassword != tbAccountPassword.Text)
            {
                misc.BlinkTekst = "NO ACCESS, wrong password.";
                lbBanklogininfo.Text = misc.BlinkWordEffect();
                tbAccountPassword.Text = "";
            }
            else
            {
                //login was succesvol.
                lbBanklogininfo.Visible = true;
                lbSaldo.Visible = true;
                cbAccountnummer.Text = "";
                tbAccountPassword.Text = "";

                lbBanklogininfo.Text = "Access granted! Account nr: " + getaccount.AccountRekeningnr;
                lbSaldo.Text = "Saldo:  " + getaccount.AccountSaldo;

                Button btnGeldOvermaken = new Button();
                
                if (getaccount.AccountSaldo == 0) { btnGeldOvermaken.Enabled = false; }
                else { btnGeldOvermaken.Enabled = true; }

                btnGeldOvermaken.Name = getaccount.AccountNaam;
                btnGeldOvermaken.AutoSize = true;
                btnGeldOvermaken.Text = "Steal all money.";
                btnGeldOvermaken.BackColor = Color.Black;
                btnGeldOvermaken.ForeColor = Color.Lime;
                btnGeldOvermaken.FlatStyle = FlatStyle.Flat;                
                btnGeldOvermaken.Location = new Point(500, 20);
                btnGeldOvermaken.Click += new System.EventHandler(GeldOvermaken);
                btnGeldOvermaken.Visible = true;
                btnGeldOvermaken.Height = 50;
                gbxWBBank.Controls.Add(btnGeldOvermaken);
            }            
        }

        private void GeldOvermaken(object sender, EventArgs e)
        {            
            Button tempbutton = (Button) sender;   
            Bankaccount BeroofdeAccount = bank.GetByNaam(tempbutton.Name);
            if (bank.AlHetGeldOvermaken(Speler, BeroofdeAccount) == false) { misc.ToonBericht(12); return; }
            tempbutton.Visible = false;
            lbSaldo.Text = "Saldo:  "+Convert.ToString(BeroofdeAccount.AccountSaldo);
            lbSpelerGeld.Refresh();
        }

        private void tbAccountPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
                
        /// <summary>
        /// Toon een winkel met alle items die gemaakt zijn in de inventory class.
        /// Ja, als je "cookie" item in de constructor uitcommenteer komt die in de shop.
        /// </summary>
        private void TekenWinkel()
        {
            showshopintro = true;
            gbxShopStock.Controls.Clear();
            gbxShopStock.Visible = true;
            gbxShopStock.Text = "nixxon stock";
            int ypos = 20;
            for (int i = 0; i < inventory.numitems; i++)
            {
                Item curitem = inventory.getItemPos(i);
                Label lbitemnaam = new Label();
                lbitemnaam.Text = curitem.NaamItem;
                lbitemnaam.Location = new Point(20, ypos);
                lbitemnaam.ForeColor = Color.Lime;
                lbitemnaam.Visible = true;                
                Label lbitemprijs = new Label();
                lbitemprijs.Text = Convert.ToString(curitem.Prijs);
                lbitemprijs.ForeColor = Color.Lime;
                lbitemprijs.Width = 50;
                lbitemprijs.Location = new Point(120, ypos);
                lbitemnaam.Visible = true;                
                Button btnItembuy = new Button();                
                btnItembuy.Name = curitem.NaamItem;                               
                btnItembuy.Location = new Point(170, ypos);
                btnItembuy.Width = 100;
                btnItembuy.Visible = true;
                btnItembuy.ForeColor = Color.Lime;
                btnItembuy.BackColor = Color.Black;
                btnItembuy.FlatStyle = FlatStyle.Flat;
                btnItembuy.FlatAppearance.MouseOverBackColor = Color.DimGray;
                btnItembuy.FlatAppearance.MouseDownBackColor= Color.Silver;
                if (IsItemInventory(curitem.NaamItem) == false)
                {
                    btnItembuy.Text = "buy";
                    btnItembuy.Click += new System.EventHandler(BuyItem);
                }
                else if (IsItemInventory(curitem.NaamItem) == true)
                {
                    btnItembuy.Text = "sold";
                }                                    
                this.gbxShopStock.Controls.Add(lbitemnaam);
                this.gbxShopStock.Controls.Add(lbitemprijs);
                this.gbxShopStock.Controls.Add(btnItembuy);
                //components.Add(btnItembuy);
                ypos += 20;
            }                                          
        }

        /// <summary>
        /// Verwijder de winkel van gamescreen
        /// </summary>
        public void VerbergWinkel()
        {
            gbxShopStock.Visible = false;
            gbxShopStock.Controls.Clear();
        }

        private void TekenListaccounts()
        {
            gbxShopStock.Visible = true;
            gbxShopStock.Text = "Account of pabobank";
            int ypos = 20;
            for (int i = 1; i < bank.numaccount; i++)
            {
                Bankaccount account = bank.GetByPos(i);
                
                Label lbaccount = new Label();
                String regellistaccount = account.AccountNaam + "   account nr: " + account.AccountRekeningnr;
                lbaccount.Text = regellistaccount;
                lbaccount.Location = new Point(20, ypos);
                lbaccount.ForeColor = Color.Lime;
                lbaccount.AutoSize = true;
                ypos = ypos + 20;
                this.gbxShopStock.Controls.Add(lbaccount);
            }
        }

        /// <summary>
        /// Controlleer of er genoeg geld bij de speler is.
        /// Zoja dan wordt het item aan de inventory list toegevoegd.
        /// </summary>
        /// <param name="sender">het item</param>
        /// <param name="e"></param>
        public void BuyItem(object sender, EventArgs e)
        {            
            Button buttontemp = (Button)sender;            

            Item buyitem = inventory.getItemShop(buttontemp.Name);

            showshopintro = false;
            //controlleer voor genoeg geld.
            if (Speler.AccountSaldo >= buyitem.Prijs)
            {   
                if (inventory.addItemInventory(buttontemp.Name) == true) {
                    Speler.geldopnemen(buyitem.Prijs);                    
                    buttontemp.Click += null;                    
                    lbSpelerGeld.Refresh();
                    buttontemp.Text = "sold";
                    lbTextShop.Text = "You bought a "+buttontemp.Name+", go to your inventory to use it.";
                }
                else {                    
                    lbTextShop.Text = "You already have this item.";
                }                
            }
            else
            { 
                lbTextShop.Text = "You don't have enough money to buy that.";
            }            
            ToonInventoryItems();
        }

        

        private void pbQuitgame_Click(object sender, EventArgs e)
        {
            GameMenu gamemenu = new GameMenu();
            gamemenu.Show();
            this.Hide();            
            resetgame();            
        }
     
        private void lbPlayerMoney_Paint(object sender, PaintEventArgs e)
        {
            lbSpelerGeld.Text = Convert.ToString(Speler.AccountSaldo);
        }

        private void btnFriendGift_Click(object sender, EventArgs e)
        {
            inventory.addBankaccountnrlist();
            pbItemListaccountumbersbank.Visible = true;
            //voeg ook even alle accountnummers aan combobox toe.
            //begin bij 1 en niet 0 omdat we niet de account van de speler willen.
            for (int pos = 1; pos < bank.numaccount; pos++)
            {
                cbAccountnummer.Items.Add(bank.GetByPos(pos).AccountRekeningnr);
            }
            btnFriendGift.Visible = false;
            btnFriendGift.Enabled = false;
        }

        private void ActivedItem(string item)
        {
            Item getitem = inventory.getItemInventory(item);
            if (getitem != null)
            {
                getitem.Active = true;
            }
            else { misc.ToonBericht(9); }
        }

        private void btnCreateBot_Click(object sender, EventArgs e)
        {
            btnCreateBot.Enabled = false;

            Huis getHuis = getHuisDoorBewonernaam(huisBewoner);
            if (getHuis.IsBot == false)
            {
                getHuis.IsBot = true;
                progbarServerload.Value = progbarServerload.Value + 25;
            }
            String regel1 = getHuis.Naam + " house is now attacking the miscrosoft server.";
            ToonBerichtHuis(regel1, "");
        }

        private void btnDeployKeylogger_Click(object sender, EventArgs e)
        {
            String regel2 = "His password appears to be: " + bank.GetByNaam(huisBewoner).AccountPassword;
            ToonBerichtHuis("  Your keylogger has captures the password!", regel2);
        }

        private void ToonBerichtHuis(String regel1, String regel2)
        {
            lbTextNaam.Text = regel1;
            lbNaam.Text = "";
            lbTextIPadres.Text = regel2;
            lbIPadres.Text = "";
            lbTextWifi.Text = "";
            lbWifi.Text = "";
            lbTextWifiSSID.Text = "";
            lbWifiSSID.Text = "";
            lbTextWifiWEP.Text = "";
            lbWifiWEP.Text = "";
            lbTextWifiWPA.Text = "";
            lbWifiWPA.Text = "";
        }
        /// <summary>
        /// Toon alle items in inventory uit inventorylijst
        /// </summary>
        private void ToonInventoryItems()
        {
            lbItemCommandInfo.Visible = false;
            tbCommand.Visible = false;
            tbCommand.Text = "";

            /*
            int xpos = 10;
            foreach (Item curitem in inventory.youritems)
            {
                PictureBox curpb = (PictureBox)curitem.item;
                curpb.Location = new Point(xpos, 14);
                xpos += 100;
            }
            */

            // /*
            if (IsItemInventory("listbankaccounts") == true)
            {
                pbItemListaccountumbersbank.Location = new Point(10, 14);
                pbItemListaccountumbersbank.Visible = true;
            }
            else { pbItemListaccountumbersbank.Visible = false; }

            if (IsItemInventory("wepcracker") == true)
            {
                pbItemWifiWEPCracker.Location = new Point(110, 14);
                pbItemWifiWEPCracker.Visible = true;
            }
            else { pbItemWifiWEPCracker.Visible = false; }

            if (IsItemInventory("keylogger") == true)
            {
                pbItemKeylogger.Location = new Point(210, 14);
                pbItemKeylogger.Visible = true;
            }
            else { pbItemKeylogger.Visible = false; }

            if (IsItemInventory("netwerkscanner") == true)
            {
                pbItemNetworkScanner.Location = new Point(310, 14);
                pbItemNetworkScanner.Visible = true;
            }
            else { pbItemNetworkScanner.Visible = false; }

            if (IsItemInventory("worm") == true)
            {
                pbItemWorm.Location = new Point(410, 14);
                pbItemWorm.Visible = true;
            }
            else { pbItemWorm.Visible = false; }
            if (IsItemInventory("coderedvirus") == true)
            {
                pbItemCoderedvirus.Location = new Point(510, 14);
                pbItemCoderedvirus.Visible = true;
            }
            else { pbItemCoderedvirus.Visible = false; }
            // */
            
        }

        /// <summary>
        /// Laat op de inventory werkbalk alleen een bepaalde afbeelding zien.
        /// </summary>
        /// <param name="pbitem"></param>
        private void ToonSlechtItem(PictureBox pbitem)
        {
            pbItemListaccountumbersbank.Visible = false;
            pbItemWifiWEPCracker.Visible = false;
            pbItemKeylogger.Visible = false;            
            pbItemNetworkScanner.Visible = false;
            pbItemWorm.Visible = false;
            pbItemCoderedvirus.Visible = false;

            lbItemCommandInfo.Visible = true;
            tbCommand.Visible = true;
            tbCommand.Focus();
             
            pbitem.Visible = true;
            pbitem.Location = new Point(10, 14);
        }
        
      
        /// <summary>
        /// schakel sound in of uit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbKnopSound_Click(object sender, EventArgs e)
        {            
            if (options.sound_enabled == true)
            { options.UpdateSetting("Sound", false);
            }
            else if (options.sound_enabled == false)
            { options.UpdateSetting("Sound", true);          
            }
            this.UpdateStateKnopSound();
        }

        /// <summary>
        /// Als sound_enable is waar, dan speel muziek en zet knop op juist status.
        /// </summary>
        private void UpdateStateKnopSound()
        {
            if (options.sound_enabled == true)
            {
                //pbKnopSound.Image.Dispose();
                this.pbKnopSound.Image = resourcehandler.loadimage("knop_sound_off.png");
                if (resourcehandler.PlaySound("backgroundmusic.wav", true) == false) { misc.ToonBericht(5); }
            }
            else if (options.sound_enabled == false)
            {
                //pbKnopSound.Image.Dispose();
                this.pbKnopSound.Image = resourcehandler.loadimage("knop_sound_on.png");
                resourcehandler.StopSound();
            }
        }

        /// <summary>
        /// Commandline inventory opdracht afhandelen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (IsItemInventory("wepcracker") ==true)
                {
                    if (tbCommand.Text == "crack " + getHuis(pbHuis2).WifiSSID)
                    {
                        lbItemCommandInfo.Text = "Succesfully cracked " + getHuis(pbHuis2).Naam + " connection";
                        tbCommand.Text = "";
                        getHuis(pbHuis2).Wepcracked = true;
                    }
                    else if (tbCommand.Text.StartsWith("crack ", false, null) == true)
                    {
                        lbItemCommandInfo.Text = "Wifi SSID not found.";
                    }
                }
                if (IsItemInventory("keylogger") ==true)
                {
                    foreach (Huis huis in huizen)
                    {
                        if (tbCommand.Text == "deploy " + huis.WifiSSID)
                        {
                            if (huis.Wepcracked == true)
                            {
                                installkeylogger(huis);
                            }
                            else { CommandNoAccess(1); }
                        }
                        else if (tbCommand.Text == "deploy " + huis.IPAdres)
                        {
                            if ((huis.WindowsOutdated == true) && (IsItemInventory("worm")==true))
                            {
                                if (inventory.getItemInventory("worm").Active == true)
                                {
                                    installkeylogger(huis);
                                }
                                else
                                {
                                    CommandNoAccess(2);
                                }
                            }

                            if ((huis.Naam != "Your") && (IsItemInventory("coderedvirus") == true))
                            {
                                if (inventory.getItemInventory("coderedvirus").Active == true)
                                {
                                    installkeylogger(huis);
                                }
                                else { CommandNoAccess(2); }
                            }
                            
                        }
                    }
                }
                if (IsItemInventory("netwerkscanner") ==true)
                {
                    if (tbCommand.Text == "scan")
                    {
                        lbItemCommandInfo.Text = "scanning";
                        tbCommand.Text = "";
                    }
                }
                if (IsItemInventory("worm") == true)
                {
                    foreach (Huis huis in huizen)
                    {
                        if ((tbCommand.Text == "infect " + huis.IPAdres) && (huis.WindowsOutdated == true))
                        {
                            ActivedItem("worm");
                            lbItemCommandInfo.Text = "You infected " + huis.IPAdres + " with a worm, now other houses can get infected soon.";
                            tbCommand.Text = "";
                        }
                        else if ((tbCommand.Text == "infect " + huis.IPAdres) && (huis.WindowsOutdated == false))
                        {
                            lbItemCommandInfo.Text = "House is not vurnable.";
                        }
                        else if (tbCommand.Text.StartsWith("infect")==true)
                        {
                            lbItemCommandInfo.Text = "Unknow IP adres.";
                        }                    
                    }
                }
                if (IsItemInventory("coderedvirus") ==true)
                {
                    if (tbCommand.Text == "release")
                    {
                        ActivedItem("coderedvirus");
                        lbItemCommandInfo.Text = "Code red virus has infected your whole neigherhood.";
                        tbCommand.Text = "";
                    }
                }
                if (tbCommand.Text == "cheatwin")
                {
                    progbarServerload.Value = 100;
                }
            }
        }

        private void installkeylogger(Huis huis)
        {
            lbItemCommandInfo.Text = "Keylogger succesfully installed on " + huis.IPAdres + ", " + huis.Naam + " house.";
            tbCommand.Text = "";
            huis.KeyloggerInstalled = true;
        }

        private void CommandNoAccess(int hint)
        {
            String hinttext = "";
            if (hint == 1) { hinttext = ", try cracking wifi first"; }
            else if (hint == 2) { hinttext = ", try using a worm on the unpatched windows machines."; }
            lbItemCommandInfo.Text = "No access"+hinttext;
            tbCommand.Text = "";
        }

        /***********************************************************
         * 
         *    Een inventory item clicked
         *         
         */
        private void pbItemWifiWEPCracker_Click(object sender, EventArgs e)
        {
            if (lbItemCommandInfo.Visible == false)
            {
                ToonSlechtItem(this.pbItemWifiWEPCracker);                
                lbItemCommandInfo.Text = "Enter \"crack\" followed by the SSID of the house that uses a weak WEP encryption for their wifi.";                
            }
            else if (lbItemCommandInfo.Visible == true)
            {
                ToonInventoryItems();
            }
        }
        private void pbItemListaccountumbersbank_Click(object sender, EventArgs e)
        {
            if (lbItemCommandInfo.Visible == false)
            {
                ToonSlechtItem(this.pbItemListaccountumbersbank);
                lbItemCommandInfo.Text = "This is the list of bankaccountnummers in your neighbourhood.";                
                TekenListaccounts();                
            }
            else if (lbItemCommandInfo.Visible == true)
            {
                ToonInventoryItems();               
                VerbergWinkel();
            }
            
        }
        private void pbItemKeylogger_Click(object sender, EventArgs e)
        {
            if (lbItemCommandInfo.Visible == false)
            {
                ToonSlechtItem(this.pbItemKeylogger);
                lbItemCommandInfo.Text = "Enter \"deploy\" followed by the SSID of a cracked wifi connection or a vulnerable IP adres.";                
            }
            else if (lbItemCommandInfo.Visible == true)
            {
                ToonInventoryItems();
            }            
        }
        private void pbItemNetworkScanner_Click(object sender, EventArgs e)
        {
            if (lbItemCommandInfo.Visible == false)
            {
                if (inventory.getItemInventory("netwerkscanner").Active == false)
                {
                    ToonSlechtItem(this.pbItemNetworkScanner);
                    lbItemCommandInfo.Text = "Enter \"scan\" to reveal all IP adresses in your neigbourhood.";
                }
                else if (inventory.getItemInventory("netwerkscanner").Active == false)
                {
                    ToonSlechtItem(this.pbItemNetworkScanner);
                    lbItemCommandInfo.Text = "You already scanned your neighbourhood, and revealed their IP adresses";
                }
            }
            else if (lbItemCommandInfo.Visible == true)
            {
                ToonInventoryItems();
            }            
        }
        private void pbItemWorm_Click(object sender, EventArgs e)
        {
            if (lbItemCommandInfo.Visible == false)
            {
                ToonSlechtItem(this.pbItemWorm);
                lbItemCommandInfo.Text = "Enter \"infect\" followed by a vurnable IP adres, the worm will automatically infect other vurnable IPs.";
            }
            else if (lbItemCommandInfo.Visible == true)
            {
                ToonInventoryItems();
            }             
        }
        private void pbItemCoderedvirus_Click(object sender, EventArgs e)
        {
            if (lbItemCommandInfo.Visible == false)
            {
                ToonSlechtItem(this.pbItemCoderedvirus);
                lbItemCommandInfo.Text = "Infect everyone with this undiscoverd virus. Type \"release\" to activate.";
            }
            else if (lbItemCommandInfo.Visible == true)
            {
                ToonInventoryItems();
            } 
            
        }


        #endregion
    }

}
