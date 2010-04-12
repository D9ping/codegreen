using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CodeGreen
{

    public partial class GameScreen : Form
    {
		#region Fields (12) 

        private string huisBewoner;
        private bool IsConnected = false, showshopintro = true;
        private int n, timesec, timemin;

        private Communication communication;
        private Bankaccount Speler;
        private WerkbalkState werkbalk;
        private List<House> huizen;
        private Bank bank;
        private Inventory inventory;
        private Misc misc;
        private SoundEngine snd;

		#endregion Fields 

		#region Enums (1) 

        private enum WerkbalkState
        {
            INSTRUCTIE,
            INVENTORY,
            BANK,
            SHOP,
            HUIS
        }

		#endregion Enums 

		#region Constructors (1) 

        public GameScreen()
        {
            InitializeComponent();

            bank = new Bank();
            misc = new Misc();
            inventory = new Inventory();
            huizen = new List<House>();
            snd = new SoundEngine();

            ResetGame();

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

		#endregion Constructors 

		#region Methods (52) 

		// Public Methods (4) 

        /// <summary>
        /// Controlleer of er genoeg geld bij de speler is.
        /// Zoja dan wordt het item aan de inventory list toegevoegd.
        /// </summary>
        /// <param name="sender">het item</param>
        /// <param name="e"></param>
        public void BuyItem(object sender, EventArgs e)
        {
            Button buttontemp = (Button)sender;
            Item buyitem = inventory.GetItemShop(buttontemp.Name);
            

            showshopintro = false;
            //controlleer voor genoeg geld.
            if (Speler.AccountSaldo >= buyitem.Prijs)
            {   
                if (inventory.AddItemInventory(buttontemp.Name) == true) {
                    if (CodeGreen.Properties.Settings.Default.sound)
                    {
                        snd.PlaySoundEffect("buysucceed.wav");
                    }
                    Speler.GeldOpnemen(buyitem.Prijs);
                    buttontemp.Click += null;
                    lbSpelerGeld.Refresh();
                    buttontemp.Text = "sold";
                    if (buttontemp.Name == "pizza")
                    {
                        lbTextShop.Text = "That taste good.";
                    }
                    else
                    {
                        lbTextShop.Text = "You bought a " + buttontemp.Name + ", go to your inventory to use it.";
                    }
                }
                else 
                {
                    if (CodeGreen.Properties.Settings.Default.sound)
                    {
                        snd.PlaySoundEffect("buyfail.wav");
                    }
                    lbTextShop.Text = "You already have this item.";
                }
            }
            else
            {
                if (CodeGreen.Properties.Settings.Default.sound)
                {
                    snd.PlaySoundEffect("buyfail.wav");
                }
                lbTextShop.Text = "You don't have enough money to buy that.";
            }
            ToonInventoryItems();
        }

        /// <summary>
        /// Verbind met controller
        /// </summary>
        /// <returns></returns>
        public bool ConnectController1()
        {
            if (!IsConnected)
            {
                int vendorid = Int32.Parse(CodeGreen.Properties.Settings.Default.controllerDefaultVendorID, System.Globalization.NumberStyles.HexNumber);
                int productid = Int32.Parse(CodeGreen.Properties.Settings.Default.controllerDefaultProductID, System.Globalization.NumberStyles.HexNumber);
                IsConnected = usb.Connect(this, vendorid, productid );
                return IsConnected;
            }
            else 
            {
                return false; 
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
                    ToonWerkbalkknop(pbKnopInventory, CodeGreen.Properties.Resources.werkbalkknop_inventory_on);
                    VerbergWinkel();
                    gbxBanklogin.Visible = false;
                    if (tbCommand.Text == "") { ToonInventoryItems(); }
                    break;
                case WerkbalkState.BANK:
                    ToonGB(gbxWBBank);
                    ToonWerkbalkknop(pbKnopBank, CodeGreen.Properties.Resources.werkbalkknop_bank_on);
                    VerbergWinkel();
                    gbxBanklogin.Visible = true;
                    misc.Curlenword = 0;
                    lbSaldo.Text = "";
                    lbBanklogininfo.Text = "";
                    break;
                case WerkbalkState.SHOP:
                    ToonGB(gbxWBShop);
                    ToonWerkbalkknop(pbKnopShop, CodeGreen.Properties.Resources.werkbalkknop_shop_on);
                    DrawShop();
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
        /// Verwijder de winkel van gamescreen
        /// </summary>
        public void VerbergWinkel()
        {
            gbxShopStock.Visible = false;
            gbxShopStock.Controls.Clear();
        }
		// Private Methods (48) 

        private void ActivedItem(string item)
        {
            Item getitem = inventory.GetItemInventory(item);
            if (getitem != null)
            {
                getitem.Active = true;
            }
            else { misc.ToonBericht(9); }
        }

        private void btnCreateBot_Click(object sender, EventArgs e)
        {
            this.btnCreateBot.Enabled = false;

            House getHuis = getHuisDoorBewonernaam(huisBewoner);
            if (getHuis.IsBot == false)
            {
                getHuis.IsBot = true;
                progbarServerload.Value = progbarServerload.Value + 25;
            }
            String regel1 = getHuis.Naam + " house is now attacking the miscrosol server.";
            ShowMsgAboutHouse(regel1, "");
        }

        private void btnDeployKeylogger_Click(object sender, EventArgs e)
        {
            String regel2 = "His password appears to be: " + bank.GetByName(huisBewoner).AccountPassword;
            ShowMsgAboutHouse("  Your keylogger has captures the password!", regel2);
        }

        private void btnFriendGift_Click(object sender, EventArgs e)
        {
            inventory.AddBankaccountnrlist();
            pbItemListaccountumbersbank.Visible = true;
            //voeg ook even alle accountnummers aan combobox toe.
            //begin bij 1 en niet 0 omdat we niet de account van de speler willen.
            for (int pos = 1; pos < this.bank.Numaccount; pos++)
            {
                this.cbAccountnummer.Items.Add(bank.GetByPos(pos).AccountRekeningnr);
            }
            this.btnFriendGift.Visible = false;
            this.btnFriendGift.Enabled = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            gbxBanklogin.Visible = false;
            Bankaccount getaccount = this.bank.GetByRekening(cbAccountnummer.Text);
            if (this.cbAccountnummer.Text == string.Empty)
            {
                misc.BlinkTekst = "NO ACCESS, enter a account number.";
                this.lbBanklogininfo.Text = misc.BlinkWordEffect();
            }
            else if (getaccount==null) {
                this.misc.BlinkTekst = "NO ACCESS, accountnummer doesn't exist.";
                this.lbBanklogininfo.Text = misc.BlinkWordEffect();
                this.cbAccountnummer.Text = "";
                if (CodeGreen.Properties.Settings.Default.sound)
                {
                    snd.PlaySoundEffect("bankaccessfail.wav");
                }
            }
            else if (tbAccountPassword.Text == string.Empty)
            {
                misc.BlinkTekst = "NO ACCESS, enter a password.";
                this.lbBanklogininfo.Text = misc.BlinkWordEffect();
            }
            else if (getaccount.AccountPassword != tbAccountPassword.Text)
            {
                misc.BlinkTekst = "NO ACCESS, wrong password.";
                this.lbBanklogininfo.Text = misc.BlinkWordEffect();
                this.tbAccountPassword.Text = string.Empty;
                if (CodeGreen.Properties.Settings.Default.sound)
                {
                    snd.PlaySoundEffect("bankaccessfail.wav");
                }
            }
            else
            {
                //login was succesvol.
                if (CodeGreen.Properties.Settings.Default.sound)
                {
                    snd.PlaySoundEffect("bankaccessgranted.wav");
                }

                this.lbBanklogininfo.Visible = true;
                this.lbSaldo.Visible = true;
                this.cbAccountnummer.Text = "";
                this.tbAccountPassword.Text = "";

                this.lbBanklogininfo.Text = "Access granted! Account nr: " + getaccount.AccountRekeningnr;
                this.lbSaldo.Text = "Saldo:  " + getaccount.AccountSaldo;

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

        private void btnReconnect_Click(object sender, EventArgs e)
        {
            this.initController();
        }

        private void CommandNoAccess(int hint)
        {
            String hinttext = "";
            if (hint == 1) { hinttext = ", try cracking wifi first"; }
            else if (hint == 2) { hinttext = ", try using a worm on the unpatched windows machines."; }
            lbItemCommandInfo.Text = "No access"+hinttext;
            tbCommand.Text = "";
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

        private void GameScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void GameScreen_Shown(object sender, EventArgs e)
        {
            TimerTextEffect.Enabled = true;
            TimerGametime.Enabled = true;
        }

        private void GeldOvermaken(object sender, EventArgs e)
        {            
            Button tempbutton = (Button) sender;
            Bankaccount BeroofdeAccount = this.bank.GetByName(tempbutton.Name);
            if (bank.AlHetGeldOvermaken(Speler, BeroofdeAccount) == false) { misc.ToonBericht(12); return; }
            tempbutton.Visible = false;
            lbSaldo.Text = "Saldo:  "+Convert.ToString(BeroofdeAccount.AccountSaldo);
            lbSpelerGeld.Refresh();
        }

        /// <summary>
        /// teken rondje op de juiste plek
        /// </summary>
        private void GetControllerHuis()
        {
            pbHuis1.Image = CodeGreen.Properties.Resources.controller_not_selected; //resourcehandler.loadimage("not_selected.png");
            pbHuis2.Image = CodeGreen.Properties.Resources.controller_not_selected; // resourcehandler.loadimage("not_selected.png");
            pbHuis3.Image = CodeGreen.Properties.Resources.controller_not_selected; //resourcehandler.loadimage("not_selected.png");
            pbHuis4.Image = CodeGreen.Properties.Resources.controller_not_selected; //resourcehandler.loadimage("not_selected.png");
            pbHuis5.Image = CodeGreen.Properties.Resources.controller_not_selected; //resourcehandler.loadimage("not_selected.png");
            pbBank.Image = CodeGreen.Properties.Resources.controller_not_selected;  //resourcehandler.loadimage("not_selected.png");
            pbShop.Image = CodeGreen.Properties.Resources.controller_not_selected;  //resourcehandler.loadimage("not_selected.png");
            pbHuisVriend.Image = CodeGreen.Properties.Resources.controller_not_selected;  //resourcehandler.loadimage("not_selected.png");

            if (getHuisDoorBewonernaam(communication.GeselecteerdHuis) != null)
            {
                House selectedhuis = getHuisDoorBewonernaam(communication.GeselecteerdHuis);
                PictureBox pbhuis = (PictureBox)selectedhuis.Huisobj;
                pbhuis.Image = CodeGreen.Properties.Resources.controller_selected; //resourcehandler.loadimage("selected.png");
                pbhuis.SizeMode = PictureBoxSizeMode.StretchImage;
                if (werkbalk != WerkbalkState.INSTRUCTIE) { VeranderWerkbalk(pbhuis, EventArgs.Empty); }
            }
            else if (communication.GeselecteerdHuis == "Bank")
            {
                pbBank.Image = CodeGreen.Properties.Resources.controller_selected; //resourcehandler.loadimage("selected.png");
                pbBank.SizeMode = PictureBoxSizeMode.StretchImage;
                VeranderWerkbalk(pbBank, EventArgs.Empty);
            } 
            else if (communication.GeselecteerdHuis == "Shop")
            {
                pbShop.Image = CodeGreen.Properties.Resources.controller_selected; //resourcehandler.loadimage("selected.png");
                pbShop.SizeMode = PictureBoxSizeMode.StretchImage;
                VeranderWerkbalk(pbShop, EventArgs.Empty);
            }
            else if (communication.GeselecteerdHuis == "HuisVriend")
            {
                pbHuisVriend.Image = CodeGreen.Properties.Resources.controller_selected; //resourcehandler.loadimage("selected.png");
                pbHuisVriend.SizeMode = PictureBoxSizeMode.StretchImage;
                VeranderWerkbalk(pbHuisVriend, EventArgs.Empty);
            }
        }

        private House getHuis(object huisnm)
        {
            foreach (House curhuis in huizen)
            {
                if (curhuis.Huisobj == huisnm)
                {
                    return curhuis;
                }
            }
            return null;
        }

        private House getHuisDoorBewonernaam(String bewonernaam)
        {
            foreach (House curhuis in huizen)
            {
                if (curhuis.Naam == bewonernaam)
                {
                    return curhuis;
                }
            }
            return null;
        }

        private void hungry()
        {
            lbItemCommandInfo.Text = "You are hungry, maby you should order some food first.";
        }

        /// <summary>
        /// Verbinding met controller opzetten en info. tonen.
        /// </summary>
        private void initController()
        {
            this.btnReconnect.Visible = false;
            if (CodeGreen.Properties.Settings.Default.controller)
            {
                this.communication = new Communication();
                this.btnReconnect.Visible = true;
                if (this.ConnectController1() == true)
                {
                    //if (werkbalk != WerkbalkState.INSTRUCTIE) { GetControllerHuis(); }
                    GetControllerHuis();
                    lbControllerInfo.Text = "Connected with controller\r\n" +
                    "             VendorID: " + CodeGreen.Properties.Settings.Default.controllerDefaultVendorID + "\r\n" +
                    "             ProductID: " + CodeGreen.Properties.Settings.Default.controllerDefaultProductID;
                }
                else
                {
                    lbControllerInfo.Text = "Could not connect\r\n with controller";
                }
            }
        }

        /// <summary>
        /// Maak alle huizen aan.
        /// </summary>
        private void initHuizen()
        {
            try
            {
                House[] huis = new House[5];
                huis[0] = new House(pbHuis1, "Your", "33.23.34.45", true, "linksystems", false, true, false);
                huis[1] = new House(pbHuis2, "Jan de Vries", "66.23.34.45", true, "devries", true, false, false);
                huis[2] = new House(pbHuis3, "Marrieke", "100.11.22.33", true, "natgears", false, true, true);
                huis[3] = new House(pbHuis4, "Pieter", "14.23.34.45", false, "", true, true, true);
                huis[4] = new House(pbHuis5, "Roel", "68.23.34.45", true, "wireless108", false, true, false);
                huizen.AddRange(huis);
                SetTooltipHouses();
            }
            catch (Exception) { misc.ToonBericht(6); }
        }

        private void installkeylogger(House huis)
        {
            lbItemCommandInfo.Text = "Keylogger succesfully installed on " + huis.IPAdres + ", " + huis.Naam + " house.";
            tbCommand.Text = "";
            huis.KeyloggerInstalled = true;
        }

              /// <summary>
        /// Kijk of item in inventory zit.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>heeft true terug als wel het geval is.</returns>
        private bool IsItemInventory(String item)
        {
            if (inventory.GetItemInventory(item) != null)
            {
                return true;
            }
            else
            { 
                return false;
            }
        }

        private void lbPlayerMoney_Paint(object sender, PaintEventArgs e)
        {
            lbSpelerGeld.Text = Convert.ToString(Speler.AccountSaldo);
        }

        private void pbItemCoderedvirus_Click(object sender, EventArgs e)
        {
            if (lbItemCommandInfo.Visible == false)
            {
                ToonSlechtItem(this.pbItemCoderedvirus);
                lbItemCommandInfo.Text = "Infect everyone with this yet undiscoverd virus. Type \"release\" to activate.";
            }
            else if (lbItemCommandInfo.Visible == true)
            {
                ToonInventoryItems();
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

        private void pbItemNetworkScanner_Click(object sender, EventArgs e)
        {
            if (lbItemCommandInfo.Visible == false)
            {
                if (inventory.GetItemInventory("netwerkscanner").Active == false)
                {
                    ToonSlechtItem(this.pbItemNetworkScanner);
                    lbItemCommandInfo.Text = "Enter \"scan\" to reveal all IP adresses in your neigbourhood.";
                }
                else if (inventory.GetItemInventory("netwerkscanner").Active == false)
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

        /// <summary>
        /// An inventory item clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// schakel sound in of uit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbKnopSound_Click(object sender, EventArgs e)
        {
            CodeGreen.Properties.Settings.Default.music = !CodeGreen.Properties.Settings.Default.music;
            CodeGreen.Properties.Settings.Default.Save();

            if (this.CheckMusic())
            {
                PlayBackgroundMusic();
            }
            else
            {
                snd.StopMusic();
            }

        }

        private void pbQuitgame_Click(object sender, EventArgs e)
        {
            GameMenu gamemenu = new GameMenu();
            gamemenu.Show();
            this.Hide();
            ResetGame();
        }

        private void ResetGame()
        {
            inventory.ResetInventory();
            huizen.Clear();
            initHuizen();

            timesec = 0;
            timemin = 0;

            if (this.CheckMusic())
            {
                PlayBackgroundMusic();
            }
            
            Speler = bank.GetByName("speler");
        }

        /// <summary>
        /// Reset the info on the toolbar of a house.
        /// </summary>
        private void ResetHuisInfo()
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
        /// Heef elk huis een tooltip.
        /// </summary>
        private void SetTooltipHouses()
        {
            if (IsItemInventory("netwerkscanner")==true)
            {
                if (inventory.GetItemInventory("netwerkscanner").Active == true)
                {
                    foreach (House huis in huizen)
                    {
                        tooltip.SetToolTip((Control)huis.Huisobj, huis.Naam + " house \r\n IP: " + huis.IPAdres);
                    }
                }
            }
            else
            {
                foreach (House huis in huizen)
                {
                    tooltip.SetToolTip((Control)huis.Huisobj, huis.Naam + " house");
                }
            }
        }

        private void tbAccountPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
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
                    foreach (House huis in huizen)
                    {
                        if (tbCommand.Text == "deploy " + huis.WifiSSID)
                        {
                            if (huis.Wepcracked == true)
                            {
                                installkeylogger(huis);
                            }
                            else
                            {
                                this.CommandNoAccess(1);
                            }
                        }
                        else if (tbCommand.Text == "deploy " + huis.IPAdres)
                        {
                            if ((huis.WindowsOutdated == true) && (IsItemInventory("worm")==true))
                            {
                                if (inventory.GetItemInventory("worm").Active == true)
                                {
                                    this.installkeylogger(huis);
                                }
                                else
                                {
                                    this.CommandNoAccess(2);
                                }
                            }

                            if ((huis.Naam != "Your") && (IsItemInventory("coderedvirus") == true))
                            {
                                if (inventory.GetItemInventory("coderedvirus").Active == true)
                                {
                                    this.installkeylogger(huis);
                                }
                                else
                                {
                                    this.CommandNoAccess(2);
                                }
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

                        if (CodeGreen.Properties.Settings.Default.sound)
                        {
                            snd.PlaySoundEffect("scanning.wav");
                        }
                    }
                }
                if (IsItemInventory("worm") == true)
                {
                    foreach (House huis in huizen)
                    {
                        if ((tbCommand.Text == "infect " + huis.IPAdres) && (huis.WindowsOutdated == true))
                        {
                            this.ActivedItem("worm");
                            this.lbItemCommandInfo.Text = "You infected " + huis.IPAdres + " with a worm, now other houses can get infected soon.";
                            this.tbCommand.Text = string.Empty;
                        }
                        else if ((tbCommand.Text == "infect " + huis.IPAdres) && (huis.WindowsOutdated == false))
                        {
                            lbItemCommandInfo.Text = "House is not vurnable.";
                        }
                        else if (this.tbCommand.Text.StartsWith("infect") == true)
                        {
                            this.lbItemCommandInfo.Text = "Unknow IP adres.";
                        }
                    }
                }
                if (IsItemInventory("coderedvirus") ==true)
                {
                    if (tbCommand.Text == "release -a")
                    {
                        if (IsItemInventory("pizza") == true)
                        {
                            this.ActivedItem("coderedvirus");
                            this.lbItemCommandInfo.Text = "Code red virus has infected your whole neigherhood.";
                            this.tbCommand.Text = "";
                        }
                        else hungry();
                    }
                    else if (this.tbCommand.Text == "release -?")
                    {
                        this.lbItemCommandInfo.Text = "Enter -a parameter after the release command to release the codered virus on your whole neigherhood.";
                    }
                    else if (this.tbCommand.Text == "release")
                    {
                        if (this.IsItemInventory("pizza") == true)
                        {
                            this.lbItemCommandInfo.Text = "Error, you need to added some parameters. Add the -? parameter after the release command to get help.";
                        }
                        else
                        {
                            this.hungry();
                        }
                    }
                }

                ////if (this.tbCommand.Text == "cheatwin")
                ////{
                ////    this.progbarServerload.Value = 100;
                ////}
            }
        }

        private void TekenListaccounts()
        {
            this.gbxShopStock.Visible = true;
            this.gbxShopStock.Text = "Account of pabobank";
            int ypos = 20;
            for (int i = 1; i < this.bank.Numaccount; i++)
            {
                Bankaccount account = this.bank.GetByPos(i);
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
        /// Toon een winkel met alle items die gemaakt zijn in de inventory class.
        /// </summary>
        private void DrawShop()
        {
            showshopintro = true;
            this.gbxShopStock.Controls.Clear();
            this.gbxShopStock.Visible = true;
            this.gbxShopStock.Text = "nixxon stock";
            int ypos = 20;
            for (int i = 0; i < inventory.Numitems; i++)
            {
                Item curitem = inventory.GetItemPos(i);
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
                    btnItembuy.Click += new System.EventHandler(this.BuyItem);
                }
                else if (IsItemInventory(curitem.NaamItem) == true)
                {
                    btnItembuy.Text = "sold";
                }
                this.gbxShopStock.Controls.Add(lbitemnaam);
                this.gbxShopStock.Controls.Add(lbitemprijs);
                this.gbxShopStock.Controls.Add(btnItembuy);
                ypos += 20;
            }
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
                    if (timemin == 0)
                    {
                        this.lbPlayerTime.Text = timesec + "s";
                    }
                    else
                    {
                        this.lbPlayerTime.Text = timemin + "m " + timesec + "s";
                    }
                }
                else
                {
                    timemin++;
                    timesec = 0;
                    this.lbPlayerTime.Text = timemin + "m " + timesec + "s";
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
                GameHighscore highscore = new GameHighscore(timemin, timesec, geld);
                highscore.Show();
                this.Hide();
            }
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
                this.btnFriendGift.Visible = false;

                if (misc.HuidigeTekst == "intro")
                {
                    lblIntroTextLine1.Text = misc.TypeTextFull("intro");
                    if (misc.HuidigeRegel > 6)
                    {
                        TimerTextEffect.Enabled = false;
                    }
                }
                else if (misc.HuidigeTekst == "friend")
                {
                    if (IsItemInventory("listbankaccounts") == false)
                    {
                        this.lblIntroTextLine1.Text = misc.TypeTextFull("friend");
                        if (misc.HuidigeRegel >= 2)
                        {
                            this.btnFriendGift.Visible = true;
                        }
                        else
                        {
                            this.btnFriendGift.Visible = false;
                        }
                    }
                    else
                    {
                        this.lblIntroTextLine1.Text = misc.TypeWordEffect("How is your work coming along ;P?");
                    }
                }
                else { misc.ToonBericht(10); }
            }
            else if (werkbalk == WerkbalkState.SHOP)
            {
                if (showshopintro ==true)
                {
                    this.lbTextShop.Text = misc.TypeWordEffect("Nixxons shop for all your hacker tools.");
                }
            }
            else if (werkbalk == WerkbalkState.BANK)
            {
                if ((gbxBanklogin.Visible == true) && (lbSaldo.Visible ==false))
                {
                    this.lbBanklogininfo.Text = misc.TypeWordEffect("To break in you will need an accountnumber and password.");
                }
                else if (this.lbSaldo.Visible == false)
                {
                    this.lbBanklogininfo.Text = misc.BlinkWordEffect();
                }
            }
            else if (werkbalk == WerkbalkState.INVENTORY)
            {
                if (this.lbItemCommandInfo.Text.StartsWith("scanning") == true)
                {
                    if (this.lbItemCommandInfo.Text.StartsWith("scanning....................................") == true)
                    {
                        if (this.lbItemCommandInfo.Text.EndsWith("done") == false)
                        {
                            this.lbItemCommandInfo.Text = this.lbItemCommandInfo.Text + "done";
                            this.ActivedItem("netwerkscanner");
                            this.SetTooltipHouses();
                        }
                    }
                    else
                    {
                        this.lbItemCommandInfo.Text = this.lbItemCommandInfo.Text + ".";
                    }
                }
            }
        }

        private void ShowMsgAboutHouse(String regel1, String regel2)
        {
            this.lbTextNaam.Text = regel1;
            this.lbNaam.Text = String.Empty;
            this.lbTextIPadres.Text = regel2;
            this.lbIPadres.Text = String.Empty;
            this.lbTextWifi.Text = String.Empty;
            this.lbWifi.Text = String.Empty;
            this.lbTextWifiSSID.Text = String.Empty;
            this.lbWifiSSID.Text = String.Empty;
            this.lbTextWifiWEP.Text = String.Empty;
            this.lbWifiWEP.Text = String.Empty;
            this.lbTextWifiWPA.Text = String.Empty;
            this.lbWifiWPA.Text = String.Empty;
        }

        /// <summary>
        /// First makes all groupboxs not visible then make the given groupbox visible.
        /// </summary>
        /// <param name="showGB">The groupbox to be visible.</param>
        private void ToonGB(GroupBox showGB)
        {
            this.gbxGameInstructions.Visible = false;
            this.gbxWBInventory.Visible = false;
            this.gbxWBShop.Visible = false;
            this.gbxWBBank.Visible = false;
            this.gbxWBHuis.Visible = false;
            
            showGB.Visible = true;
        }

        /// <summary>
        /// Haal huis informatie op.
        /// </summary>
        private void ToonHuisInfo(House huis)
        {
            this.ResetHuisInfo();

            huisBewoner = huis.Naam;
            this.lbNaam.Text = huisBewoner;

            if (huis.IsBot == false) 
            {
                this.btnCreateBot.Enabled = true; 
            }
            else if (huis.IsBot == true) 
            {
                this.btnCreateBot.Enabled = false;
            }

            if (huis.Wifi == true)
            {
                this.lbWifi.Text = "Yes";
                this.ToonHuisWifi(true);

                this.lbWifiSSID.Text = huis.WifiSSID;
                if (huis.WifiWEP == true)
                {
                    if (this.IsItemInventory("wepcracker") == true)
                    {
                        if (huis.Wepcracked==true)
                        {
                            this.lbWifiWEP.Text = "CRACKED";
                            this.lbWifiWEP.ForeColor = Color.Red;
                            this.btnCreateBot.Visible = true;
                        }
                        else
                        {
                            this.lbWifiWEP.Text = "Yes";
                            this.btnCreateBot.Visible = false;
                        }
                    }
                    else
                    {
                        this.lbWifiWEP.Text = "Yes";
                    }
                }
                else 
                {
                    this.lbWifiWEP.Text = "No";
                }

                if (huis.WifiWPA == true) 
                {
                    this.lbWifiWPA.Text = "Yes"; 
                }
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

            if (this.IsItemInventory("keylogger") == true)
            {
                if (huis.KeyloggerInstalled == true)
                {
                    this.btnGetKeyloggerLog.Visible = true;
                    this.btnGetKeyloggerLog.Enabled = true;
                }
                else 
                {
                    this.btnGetKeyloggerLog.Enabled = false; 
                }
            }
            else
            {
                this.btnGetKeyloggerLog.Visible = false;
                this.btnGetKeyloggerLog.Enabled = false;
            }

            if (this.IsItemInventory("netwerkscanner") == true)
            {
                lbWindowsuptodate.Visible = true;
                lbTextWindowsUpdatetodate.Visible = true;

                if (inventory.GetItemInventory("netwerkscanner").Active == true)
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
                            if (inventory.GetItemInventory("worm").Active == true)
                            {
                                this.lbInfectie.Text = "yes";
                                this.lbInfectie.ForeColor = Color.Red;
                                this.btnCreateBot.Visible = true;
                                if (huis.KeyloggerInstalled == true) 
                                {
                                    this.btnGetKeyloggerLog.Enabled = true;
                                }
                                else if (huis.KeyloggerInstalled == false)
                                {
                                    this.btnGetKeyloggerLog.Enabled = false;
                                }
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
                            if (inventory.GetItemInventory("worm").Active == true)
                            {
                                this.lbInfectie.Text = "no";
                                this.lbInfectie.ForeColor = Color.Lime;
                            }
                        }
                    }
                }
                else if (inventory.GetItemInventory("netwerkscanner").Active == false) 
                {
                    lbIPadres.Text = "not scanned"; 
                }
                if (IsItemInventory("coderedvirus") == true)
                {
                    if (inventory.GetItemInventory("coderedvirus").Active == true)
                    {
                        this.btnCreateBot.Visible = true;
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
        /// Toont wel of niet huis wifi instellingen.
        /// </summary>
        /// <param name="toon"></param>
        private void ToonHuisWifi(bool toon)
        {
            this.lbTextWifiSSID.Visible = toon;
            this.lbTextWifiWEP.Visible = toon;
            this.lbTextWifiWPA.Visible = toon;
            this.lbWifiSSID.Visible = toon;
            this.lbWifiWEP.Visible = toon;
            this.lbWifiWPA.Visible = toon;
            this.lbWifiWEP.ForeColor = Color.Lime;
        }

        /// <summary>
        /// Toon alle items in inventory uit inventorylijst
        /// </summary>
        private void ToonInventoryItems()
        {
            lbItemCommandInfo.Visible = false;
            this.tbCommand.Visible = false;
            this.tbCommand.Text = string.Empty;

            if (IsItemInventory("listbankaccounts") == true)
            {
                this.pbItemListaccountumbersbank.Location = new Point(10, 14);
                this.pbItemListaccountumbersbank.Visible = true;
            }
            else
            {
                this.pbItemListaccountumbersbank.Visible = false;
            }

            if (IsItemInventory("wepcracker") == true)
            {
                this.pbItemWifiWEPCracker.Location = new Point(110, 14);
                this.pbItemWifiWEPCracker.Visible = true;
            }
            else
            {
                this.pbItemWifiWEPCracker.Visible = false;
            }

            if (IsItemInventory("keylogger") == true)
            {
                this.pbItemKeylogger.Location = new Point(210, 14);
                this.pbItemKeylogger.Visible = true;
            }
            else
            {
                this.pbItemKeylogger.Visible = false; 
            }

            if (IsItemInventory("netwerkscanner") == true)
            {
                this.pbItemNetworkScanner.Location = new Point(310, 14);
                this.pbItemNetworkScanner.Visible = true;
            }
            else
            {
                this.pbItemNetworkScanner.Visible = false;
            }

            if (IsItemInventory("worm") == true)
            {
                this.pbItemWorm.Location = new Point(410, 14);
                this.pbItemWorm.Visible = true;
            }
            else 
            { 
                this.pbItemWorm.Visible = false; 
            }
            if (this.IsItemInventory("coderedvirus") == true)
            {
                this.pbItemCoderedvirus.Location = new Point(510, 14);
                this.pbItemCoderedvirus.Visible = true;
            }
            else 
            {
                this.pbItemCoderedvirus.Visible = false; 
            }
            
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
        /// Veranderd de werkbalk knoppen status (behalve geluid en quit knop)
        /// </summary>
        private void ToonWerkbalkknop(PictureBox ShowPB, Image newimg)
        {
            this.pbKnopBank.Image = CodeGreen.Properties.Resources.werkbalkknop_bank_off; //resourcehandler.loadimage("werkbalkknop_bank_off.png");
            this.pbKnopInventory.Image = CodeGreen.Properties.Resources.werkbalkknop_inventory_off; //resourcehandler.loadimage("werkbalkknop_inventory_off.png");
            this.pbKnopShop.Image = CodeGreen.Properties.Resources.werkbalkknop_shop_off; //resourcehandler.loadimage("werkbalkknop_shop_off.png");
            if (ShowPB != null) 
            {
                ShowPB.Image = newimg;//resourcehandler.loadimage(bestandsnaam); 
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
                        if (n == i)
                        { 
                            Ytruck = pbTruck1.Location.Y - 1; 
                        }
                    }
            }
            else if (Xtruck > 770) { Xtruck = 270; Ytruck = 306;
            pbTruck1.Refresh();  }
            else
            {
                Ytruck = pbTruck1.Location.Y; 
            }

            pbTruck1.Location = new Point(Xtruck, Ytruck);
        }

        /// <summary>
        /// Check if music is enabled.
        /// </summary>
        private bool CheckMusic()
        {
            if (CodeGreen.Properties.Settings.Default.music)
            {
                this.pbKnopSound.Image = CodeGreen.Properties.Resources.knop_sound_off;
                return true;
            }
            else
            {
                this.pbKnopSound.Image = CodeGreen.Properties.Resources.knop_sound_on;
                return false;
            }
        }

        private void PlayBackgroundMusic()
        {
            if (!snd.PlayMusic("gamemusic.wav", true))
            {
                misc.ToonBericht(5);
            }
        }

        /// <summary>
        /// Data verwerken van de remote controller.
        /// </summary>
        /// <param name="data">???</param>
        private void usb_OnDataRecieved(object sender, byte[] data)
        {
            if (CodeGreen.Properties.Settings.Default.controller)
            {
                this.communication.DataAtmelController(data);
                this.GetControllerHuis();
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
                if (werkbalk != WerkbalkState.INVENTORY)
                {
                    werkbalk = WerkbalkState.INVENTORY;
                    this.gbxShopStock.Focus();
                }
            }
            else if ((sender == pbKnopBank) || (sender == pbBank))
            {
                if (werkbalk != WerkbalkState.BANK) 
                {
                    werkbalk = WerkbalkState.BANK;
                    this.gbxBanklogin.Focus();
                }
            }
            else if ((sender == pbShop) || (sender == pbKnopShop))
            {
                if (werkbalk != WerkbalkState.SHOP) 
                {
                    werkbalk = WerkbalkState.SHOP;
                    this.gbxShopStock.Focus();
                }
            }
            else if (sender == pbHuisVriend)
            {
                if (werkbalk != WerkbalkState.INSTRUCTIE) 
                {
                    werkbalk = WerkbalkState.INSTRUCTIE;
                    this.gbxGameInstructions.Focus();
                }
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
                        if (werkbalk != WerkbalkState.HUIS)
                        {
                            werkbalk = WerkbalkState.HUIS;
                        }

                        if (getHuis(sender) == null)
                        {
                            misc.ToonBericht(7);
                        }
                        else
                        {
                            this.ToonHuisInfo(getHuis(sender));
                        }
                    }
                }
            }
            this.ToonWerkbalk();
        }

        private void GameScreen_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    pbQuitgame_Click(sender, e);
                    break;
                case Keys.Space:
                    if (werkbalk == WerkbalkState.INSTRUCTIE)
                    {
                        misc.Curlenword = misc.CurTekstLen;
                        misc.HuidigeRegel = misc.HuidigeRegel++;
                    }
                    break;
            }
        }

        #endregion Methods
    }

}
