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
        SHOP,
        HUIS
    }
    public partial class GameScreen : Form
    {
        #region datavelden
        public Misc misc;
        public OptionsHandler options;
        private Inventory inventory;
        public ResourceHandler resourcehandler;        
        private int n, timesec, timemin;        
        private Bankaccount PlayerBankaccount;        
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

            huizen = new List<Huis>();
            inithuizen();

            options = new OptionsHandler();
            
            resourcehandler = new ResourceHandler();            
                       
            PlayerBankaccount = bank.GetByNaam("speler");                        

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
        public void inithuizen()
        {
            try
            {
                //TODO: verzin betere namen.
                Huis[] huis = new Huis[5];
                huis[0] = new Huis(pbHuis1, "Your", "33.23.34.45", true, "linksystems", false, true, true, true, false);
                huis[1] = new Huis(pbHuis2, "Jan de Vries", "66.23.34.45", true, "devries", true, false, false, false, false);
                huis[2] = new Huis(pbHuis3, "Marrieke", "72.23.34.45", true, "netgears", false, true, false, false, false);
                huis[3] = new Huis(pbHuis4, "Pieter", "14.23.34.45", false, "", true, true, false, false, false);
                huis[4] = new Huis(pbHuis5, "Roel", "68.23.34.45", true, "draadloos324098", false, true, true, true, false);                
                huizen.AddRange(huis);

                for (int i = 0; i < huizen.Count; i++)
			    {
                    tooltip.SetToolTip((Control)huis[i].Huisnaam, huis[i].Naam + " place");
			    }
                
            }
            catch (Exception) { misc.ToonBericht(6); }
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

        private void ToonWerkbalkknop(PictureBox ShowPB, String bestandsnaam)
        {
            this.pbKnopBank.Image = resourcehandler.loadimage("werkbalkknop_bank_off.png");
            this.pbKnopInventory.Image = resourcehandler.loadimage("werkbalkknop_inventory_off.png");
            this.pbKnopShop.Image = resourcehandler.loadimage("werkbalkknop_shop_off.png");
            if (ShowPB != null) { ShowPB.Image = resourcehandler.loadimage(bestandsnaam); }
        }


        private void TimerTextEffect_Tick(object sender, EventArgs e)
        {
            if (werkbalk == WerkbalkState.INSTRUCTIE)
            {
                if (misc.HuidigeTekst == "intro")
                {
                    lblIntroTextLine1.Text = misc.TypeTextFull("intro");
                }
                else if (misc.HuidigeTekst == "friend")
                {
                    lblIntroTextLine1.Text = misc.TypeTextFull("friend");
                    if (misc.HuidigeRegel >= 4)
                    {
                        if (inventory.getItemInventory("bankaccountlist") == null)
                        {
                            btnFriendGift.Visible = true;
                        }
                        else
                        {
                            btnFriendGift.Visible = false;
                        }
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
                if (werkbalk != WerkbalkState.INVENTORY) { werkbalk = WerkbalkState.INVENTORY;  }
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
            //if ((sender == pbHuis1) || (sender == pbHuis2) || (sender == pbHuis3) || (sender == pbHuis4) || (sender == pbHuis5))
            {
                if (werkbalk != WerkbalkState.HUIS) { werkbalk = WerkbalkState.HUIS; }

                Huis huis = this.getHuis(sender);
                if (huis == null) { misc.ToonBericht(7); return; }
                lbNaam.Text = huis.Naam;
                if (inventory.getItemInventory("netwerkscanner") != null)
                {
                    Item checkitem = inventory.getItemInventory("netwerkscanner");
                    if (checkitem.Active == true) { lbIPadres.Text = huis.IPAdres; }
                    else { lbIPadres.Text = "not scanned"; }
                }
                else { lbIPadres.Text = "unknow"; }
                if (huis.Wifi == true)
                {
                    lbWifi.Text = "Yes";
                    ShowWifiProperties(true);

                    lbWifiSSID.Text = huis.WifiSSID;
                    if (huis.WifiWEP == true) { lbWifiWEP.Text = "Yes"; }
                    else { lbWifiWEP.Text = "No"; }
                    if (huis.WifiWPA == true) { lbWifiWPA.Text = "Yes"; }
                    else { lbWifiWPA.Text = "No"; }
                }
                else if (huis.Wifi == false)
                {
                    lbWifi.Text = "No";
                    ShowWifiProperties(false);
                }

            }
            ShowWerkbalk();
        }

        private void ShowWifiProperties(bool toon)
        {
            lbTextWifiSSID.Visible = toon;
            lbTextWifiWEP.Visible = toon;
            lbTextWifiWPA.Visible = toon;
            lbWifiSSID.Visible = toon;
            lbWifiWEP.Visible = toon;
            lbWifiWPA.Visible = toon;
        }
        private Huis getHuis(object huisnm)
        {
            foreach (Huis curhuis in huizen)
            {
                if (curhuis.Huisnaam == huisnm)
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
        }

        /// <summary>
        /// tekent de bus op nieuwe plek, CPU intensief!
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
        /// <param name="sender"></param>
        /// <param name="data">1 = omhoog, 2 = omlaag, 4 = links, 8 = rechts</param>
        private void usb_OnDataRecieved(object sender, byte[] data)
        {
            //todo: moet terug gegeven welk huis of de bank geselecteerd is.

            //communication.VerwerkData(data);            
        }      
       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            gbxBanklogin.Visible = false;
            Bankaccount getaccount = bank.GetByRekening(cbAccountnummer.Text);
            if (getaccount==null) {
                misc.BlinkTekst = "NO ACCESS, accountnummer doesn't exist.";
                lbBanklogininfo.Text = misc.BlinkWordEffect();
            }
            else if (getaccount.AccountPassword != tbAccountPassword.Text)
            {
                misc.BlinkTekst = "NO ACCESS, wrong password.";
                lbBanklogininfo.Text = misc.BlinkWordEffect();
            }
            else
            {
                //account nummer okay
                //password okay
                //TODO: toon groepbox bank met saldo rekeningnummer etc. etc.            
                lbBanklogininfo.Text = "Access granted! Account details from: " + getaccount.AccountRekeningnr;
                lbSaldo.Text = "Saldo:  " + getaccount.AccountSaldo;
                btnTranfermoney.Enabled = true;
            }
            //Bankaccount getaccount = bank.GetByRekening(tbAccountnummer.Text);
            
        }
        
        /// <summary>
        /// Toon een winkel met alle items die gemaakt zijn in de inventory class.
        /// Ja, als je "cookie" item in de constructor uitcommenteer komt die in de shop.
        /// </summary>
        private void TekenWinkel()
        {
            gbxShopStock.Visible = true;

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
                btnItembuy.Text = "buy";
                btnItembuy.Location = new Point(170, ypos);
                btnItembuy.Width = 100;
                btnItembuy.Visible = true;
                btnItembuy.ForeColor = Color.Lime;
                btnItembuy.BackColor = Color.Black;
                btnItembuy.FlatStyle = FlatStyle.Flat;                
                btnItembuy.Click += new System.EventHandler(BuyItem);
                this.gbxShopStock.Controls.Add(lbitemnaam);
                this.gbxShopStock.Controls.Add(lbitemprijs);
                this.gbxShopStock.Controls.Add(btnItembuy);
                components.Add(btnItembuy);
                ypos += 20;
            }                                          
        }

        /// <summary>
        /// Verwijder de winkel van gamescreen
        /// </summary>
        public void VerbergWinkel()
        {
            gbxShopStock.Visible = false;
        }

        public void BuyItem(object sender, EventArgs e)
        {            
            Button buttontemp = (Button)sender;
            if (buttontemp.Name == "wepcracker")
            {
                //this.pbItemWifiWEPCracker.Visible = true;
                if (inventory.addItemInventory("wepcracker") == false) {
                    this.lbTextShop.Text = "Not enough money, try hacking some bankaccount first.";
                }
            }
            else if (buttontemp.Name == "keylogger")
            {
                if (inventory.addItemInventory("wepcracker") == false)
                {
                    this.lbTextShop.Text = "Not enough money, try hacking some bankaccount first.";
                }
                //this.pbItemKeylogger.Visible = true;
            }
            else if (buttontemp.Name == "netwerkscanner")
            {
                if (inventory.addItemInventory("netwerkscanner") == false)
                {
                    this.lbTextShop.Text = "Not enough money, try hacking some bankaccount first.";
                }
                //this.pbItemNetworkScanner.Visible = true;
            }
            else if (buttontemp.Name == "worm")
            {
                if (inventory.addItemInventory("worm") == false)
                {
                    this.lbTextShop.Text = "Not enough money, try hacking some bankaccount first.";
                }
                //this.pbItemWorm.Visible = true;
            }
            else if (buttontemp.Name == "coderedvirus")
            {
                if (inventory.addItemInventory("coderedvirus") == false)
                {
                    this.lbTextShop.Text = "Not enough money, try hacking some bankaccount first.";
                }
                //this.pbItemCoderedvirus.Visible = true;
            }
            else { misc.ToonBericht(8); }

            ToonInventoryItems();
        }

        

        private void pbQuitgame_Click(object sender, EventArgs e)
        {
            GameMenu gamemenu = new GameMenu();
            gamemenu.Show();
            this.Hide();
            //reset game progress
            inventory.youritems.Clear();
        }
     
        private void lbPlayerMoney_Paint(object sender, PaintEventArgs e)
        {
            lbPlayerMoney.Text = Convert.ToString(PlayerBankaccount.AccountSaldo);
        }


        private void ActivedItem(string item)
        {
            Item getitem = inventory.getItemInventory(item);
            if (getitem != null)
            {
                getitem.Active = !getitem.Active;
            }
            else
            {
                misc.ToonBericht(9);
            }
        }

        /*
         * Een inventory items clicked
        */
        private void pbItemWifiWEPCracker_Click(object sender, EventArgs e)
        {                        
            pbItemCoderedvirus.Visible = false;
            pbItemKeylogger.Visible = false;
            pbItemNetworkScanner.Visible = false;
            pbItemWorm.Visible = false;

            lbWEPcrackerinfo.Visible = true;
            tbCommand.Visible = true;
            tbCommand.Focus();
            
        }
        private void pbItemKeylogger_Click(object sender, EventArgs e)
        {
            ActivedItem("keylogger");
            
        }
        private void pbItemNetworkScanner_Click(object sender, EventArgs e)
        {
            ActivedItem("netwerkscanner");            

                                    
        }
        private void pbItemWorm_Click(object sender, EventArgs e)
        {
            ActivedItem("worm");
        }
        private void pbItemCoderedvirus_Click(object sender, EventArgs e)
        {
            ActivedItem("coderedvirus");
        }

        private void btnFriendGift_Click(object sender, EventArgs e)
        {
            //inventory.addBankaccountnrlist();

            //begin bij 1 en niet 0 omdat we niet de account van de speler willen.
            for (int pos = 1; pos < bank.numaccount; pos++)
			{
			    cbAccountnummer.Items.Add(bank.GetByPos(pos).AccountRekeningnr);
			}

            btnFriendGift.Visible = false;
            btnFriendGift.Enabled = false;
        }

        private void tbCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {                                
                    if (tbCommand.Text == "crack " + getHuis(pbHuis2).WifiSSID)
                    {
                        lbWEPcrackerinfo.Text = "Succesfully cracked " + getHuis(pbHuis2).Naam + " connection";
                        tbCommand.Text = "";
                        ActivedItem("wepcracker");

                    }
                    else if (tbCommand.Text.StartsWith("crack ", false, null) == true)
                    {
                        lbWEPcrackerinfo.Text = "Wifi SSID not found.";
                    }
                    else
                    {
                        lbWEPcrackerinfo.Text = "Unknow command.";
                    }
                
            }
        }

        private void ToonInventoryItems()
        {
            if (inventory.getItemInventory("wepcracker") != null)
            {
                pbItemWifiWEPCracker.Visible = true;
            }
            else { pbItemWifiWEPCracker.Visible = false; }
            if (inventory.getItemInventory("netwerkscanner") != null)
            {
                pbItemNetworkScanner.Visible = true;
            }
            else { pbItemNetworkScanner.Visible = false; }
            if (inventory.getItemInventory("keylogger") != null)
            {
                pbItemKeylogger.Visible = true;
            }
            else { pbItemKeylogger.Visible = false; }
            if (inventory.getItemInventory("worm") != null)
            {
                pbItemWorm.Visible = true;
            }
            else { pbItemWorm.Visible = false; }
            if (inventory.getItemInventory("coderedvirus") != null)
            {
                pbItemCoderedvirus.Visible = true;
            }
            else { pbItemCoderedvirus.Visible = false; }
        }
        #endregion


    }

}
