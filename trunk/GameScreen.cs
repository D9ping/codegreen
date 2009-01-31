﻿using System;
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

        public Misc misc;
        public OptionsHandler options;
        public ResourceHandler resourcehandler;
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
                       
            Speler = bank.GetByNaam("speler");

            //communicatie wordt alleen gemaakt als optie voor controller aan staat(standaard register setting) 
            if (options.controller_enabled == true)
            {
                Communication communication = new Communication();
            }

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
        private void inithuizen()
        {
            try
            {
                //TODO: verzin betere namen.
                Huis[] huis = new Huis[5];
                huis[0] = new Huis(pbHuis1, "Your", "33.23.34.45", true, "linksystems", false, true, false);
                //(object huisnaam, String naam, String ipadres, bool wifi, String wifissid, bool wifiwep, bool wifiwpa, bool windowsoutdated)
                huis[1] = new Huis(pbHuis2, "Jan de Vries", "66.23.34.45", true, "devries", true, false, false);
                huis[2] = new Huis(pbHuis3, "Marrieke", "72.23.34.45", true, "netgears", false, true, true);
                huis[3] = new Huis(pbHuis4, "Pieter", "14.23.34.45", false, "", true, true, true);
                huis[4] = new Huis(pbHuis5, "Roel", "68.23.34.45", true, "draadloos324098", false, true, false);                
                huizen.AddRange(huis);
                for (int i = 0; i < huizen.Count; i++)
			    {
                    tooltip.SetToolTip((Control)huis[i].Huisobj, huis[i].Naam + " place");
			    }                
            }
            catch (Exception) { misc.ToonBericht(6); }
        }

        private void resetgame()
        {
            inventory.youritems.Clear();
            huizen.Clear();            
            inithuizen();
            timesec = 0;
            timemin = 0;
            UpdateStateKnopSound();
        }

        private void GameScreen_Shown(object sender, EventArgs e)
        {
            TimerTextEffect.Enabled = true;
            TimerGametime.Enabled = true;
            if (resourcehandler.playsound("backgroundmusic.wav", true) == false)
            { misc.ToonBericht(5); }
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

        private void UpdateStateKnopSound()
        {
            if (options.sound_enabled == true)
            {
                this.pbKnopSound.Image = resourcehandler.loadimage("knop_sound_on.png");
            }
            else if (options.sound_enabled == false)
            {
                this.pbKnopSound.Image = resourcehandler.loadimage("knop_sound_off.png");
            }
        }

        /// <summary>
        /// Timer voor tekst effecten.
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
                }
                else if (misc.HuidigeTekst == "friend")
                {
                    if (IsItemInventory("listbankaccounts") == false)
                    {
                        lblIntroTextLine1.Text = misc.TypeTextFull("friend");
                        if (misc.HuidigeRegel >= 3)
                        {
                            btnFriendGift.Visible = true;
                        }
                        else
                        {
                            btnFriendGift.Visible = false;
                        }
                    }
                    else {
                        lblIntroTextLine1.Text = misc.TypeWordEffect("Hi, nice for dropping by.");
                    }
                }
                else { misc.ToonBericht(10); }
            }
            else if (werkbalk == WerkbalkState.SHOP)
            {                
                lbTextShop.Text = misc.TypeWordEffect("Welkom to nixxons shop, for all your hacker tools.");
            }
            else if (werkbalk == WerkbalkState.BANK)
            {
                if (gbxBanklogin.Visible == true)
                {
                    lbBanklogininfo.Text = misc.TypeWordEffect("To login you will need to have a bankaccount number and password.");
                }
                else
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
                    break;
                case WerkbalkState.BANK:
                    ToonGB(gbxWBBank);
                    ToonWerkbalkknop(pbKnopBank, "werkbalkknop_bank_on.png");
                    VerbergWinkel();
                    gbxBanklogin.Visible = true;
                    misc.Curlenword = 0;
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
            //knoppen werkbalk:
            if (sender == pbKnopInventory)
            {
                if (werkbalk != WerkbalkState.INVENTORY) { werkbalk = WerkbalkState.INVENTORY; }
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

        private void resetHuisInfo()
        {
            this.btnCreateBot.Visible = false;
            this.btnGetKeyloggerLog.Visible = false;
            this.lbTextNaam.Text = "Here lives:";
            this.lbIPadres.Text = "IP adres:";            
        }

        /// <summary>
        /// Haal huis informatie op.
        /// </summary>
        private void ToonHuisInfo(Huis huis)
        {
            resetHuisInfo();

            lbNaam.Text = huis.Naam;            

            if (huis.IsBot == false)
            {
                btnCreateBot.Enabled = true;
            }
            else { btnCreateBot.Enabled = true; }

            if (IsItemInventory("netwerkscanner")==true)
            {                
                if (inventory.getItemInventory("netwerkscanner").Active == true) {
                    lbIPadres.Text = huis.IPAdres; }
                else {
                    lbIPadres.Text = "not scanned"; 
                }
            } else { lbIPadres.Text = "unknow"; }

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

                            if (huis.IsBot == false) { this.btnCreateBot.Visible = true; }                            

                            if (IsItemInventory("keylogger")==true)
                            {
                                btnGetKeyloggerLog.Visible = true;
                                if (huis.KeyloggerInstalled == true) { btnGetKeyloggerLog.Enabled = true; }
                                else { btnGetKeyloggerLog.Enabled = false; }
                            }
                            else
                            {
                                btnGetKeyloggerLog.Visible = false;
                                btnGetKeyloggerLog.Enabled = false;
                            }
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
            if (IsItemInventory("netwerkscanner") ==true)
            {
                lbWindowsuptodate.Visible = true;
                lbTextWindowsUpdatetodate.Visible = true;

                if (inventory.getItemInventory("netwerkscanner").Active == true)
                {
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
            }
            else
            {
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

        private Huis getHuisByName(String bewonernaam)
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

            //spel gewonnen
            if (this.progbarServerload.Value == 100)
            {
                TimerGametime.Enabled = false;
                int geld = Convert.ToInt32(Speler.AccountSaldo);
                GameHighscore highscore = new GameHighscore(timemin, timesec, geld);  
                highscore.Show();
                this.Hide();                             
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
            //todo: moet terug gegeven welk huis of de bank geselecteerd is.

            //communication.VerwerkData(data);            
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
            }
            else
            {
                //login was succesvol.
                lbBanklogininfo.Visible = true;
                lbSaldo.Visible = true;
                btnTranfermoney.Visible = true;
                if (getaccount.AccountSaldo == 0) { btnTranfermoney.Enabled = false; }
                else { btnTranfermoney.Enabled = true; }
                lbBanklogininfo.Text = "Access granted! Account nr: " + getaccount.AccountRekeningnr + "\r\n Registert at " + getaccount.AccountNaam;
                lbSaldo.Text = "Saldo:  " + getaccount.AccountSaldo;
                
            }            
        }
                
        /// <summary>
        /// Toon een winkel met alle items die gemaakt zijn in de inventory class.
        /// Ja, als je "cookie" item in de constructor uitcommenteer komt die in de shop.
        /// </summary>
        private void TekenWinkel()
        {
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

            //controlleer voor genoeg geld.
            if (Speler.AccountSaldo >= buyitem.Prijs)
            {   
                if (inventory.addItemInventory(buttontemp.Name) == true) {
                    Speler.geldopnemen(buyitem.Prijs);
                    buttontemp.Click += null;
                    lbSpelerGeld.Refresh();
                }
                else {
                    lbTextShop.Text = "You already have this item.";
                }                
            }
            else
            { 
                lbTextShop.Text = "You don't have enough money to buy that.";
            }
            TekenWinkel();
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

            Huis getHuis = getHuisByName(lbNaam.Text);
            if (getHuis.IsBot == false)
            {
                getHuis.IsBot = true;                
                progbarServerload.Value = progbarServerload.Value + 25;
            }            
        }

        private void btnDeployKeylogger_Click(object sender, EventArgs e)
        {
            lbTextNaam.Text = " Your keylogger has captures the password!";
            lbNaam.Text = "";
            lbTextIPadres.Text = "His password appears to be: " + bank.GetByNaam("jan de vries").AccountPassword;
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
            
            int xpos = 10;
            
            /*
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
            if (options.sound_enabled == true) { options.UpdateSetting("sound", "False"); }
            else if (options.sound_enabled == false)
            { options.UpdateSetting("sound", "True"); }
            this.UpdateStateKnopSound();
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
                                lbItemCommandInfo.Text = "Keylogger succesfully installed on " + getHuis(pbHuis2).Naam + " house.";
                                tbCommand.Text = "";
                                getHuis(pbHuis2).KeyloggerInstalled = true;
                            }
                            else
                            {
                                lbItemCommandInfo.Text = "No access.";
                                tbCommand.Text = "";
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
                        else {
                            //lbItemCommandInfo.Text = "unknow command.";
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
            }

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
                lbItemCommandInfo.Text = "Enter \"crack\" followed by the SSID of the house that uses the weak WEP encryption for their wifi.";                
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
                lbItemCommandInfo.Text = "This is the list of bankaccount nummers in your neighbourhood with names.";                
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
                ToonSlechtItem(this.pbItemNetworkScanner);
                lbItemCommandInfo.Text = "Enter \"scan\" to reveal all ip adresses in your neigberhood.";            
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
                lbItemCommandInfo.Text = "Infect everyone with this, undiscoverd virus. Type \"release\" to active.";
            }
            else if (lbItemCommandInfo.Visible == true)
            {
                ToonInventoryItems();
            } 
            
        }


        #endregion
    }

}
