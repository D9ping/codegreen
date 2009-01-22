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
            gbxInventory.Size = werkbalksize;
            gbxInventory.Location = werkbalklocation;
            gbxBank.Size = werkbalksize;
            gbxBank.Location = werkbalklocation;
            gbxHuis.Size = werkbalksize;
            gbxHuis.Location = werkbalklocation;
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
            if (resourcehandler.playsound("backgroundmusic.wav", true) == false)
            { misc.ToonBericht(5); }
        }

        private void TimerTextEffect_Tick(object sender, EventArgs e)
        {            
            lblIntroTextLine1.Text = misc.TypeTextIntro();
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
                    //tooltip.SetToolTip(this.pbKnopInventory, "open inventory");
                    pbKnopInventory.Image = resourcehandler.loadimage("werkbalkknop_inventory_off.png");
                    //tooltip.SetToolTip(this.pbKnopBank, "login bank");
                    pbKnopBank.Image = resourcehandler.loadimage("werkbalkknop_bank_off.png");                    
                    break;
                case WerkbalkState.INVENTORY:
                    ToonGB(gbxInventory);
                    //tooltip.SetToolTip(this.pbKnopInventory, "close inventory");
                    pbKnopInventory.Image = resourcehandler.loadimage("werkbalkknop_inventory_on.png");
                    //tooltip.SetToolTip(this.pbKnopBank, "login bank");
                    pbKnopBank.Image = resourcehandler.loadimage("werkbalkknop_bank_off.png");                    
                    break;
                case WerkbalkState.BANK:
                    ToonGB(gbxBank);
                    //tooltip.SetToolTip(this.pbKnopInventory, "open inventory");
                    pbKnopInventory.Image = resourcehandler.loadimage("werkbalkknop_inventory_off.png");
                    //tooltip.SetToolTip(this.pbKnopBank, "logout bank");
                    pbKnopBank.Image = resourcehandler.loadimage("werkbalkknop_bank_on.png");                    
                    break;
                case WerkbalkState.HUIS:
                    ToonGB(gbxHuis);
                    //tooltip.SetToolTip(this.pbKnopInventory, "open inventory");
                    pbKnopInventory.Image = resourcehandler.loadimage("werkbalkknop_inventory_off.png");
                    //tooltip.SetToolTip(this.pbKnopBank, "login bank");
                    pbKnopBank.Image = resourcehandler.loadimage("werkbalkknop_bank_off.png");                    
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
            else if ((sender == pbHuis3) || (sender == pbHuis2) || (sender == pbHuis1) || (sender == pbHuis4) || (sender == pbHuis5) || (sender == pbHuis6))
            {
                if (werkbalk != WerkbalkState.HUIS)
                {
                    werkbalk = WerkbalkState.HUIS;
                }
                             
                Huis huis = this.getHuis(sender);
                if (huis == null) { misc.ToonBericht(7); return; }

                lbNaam.Text = huis.Naam;
                //
                if (btnBuyNeworkscanner.Visible == true) { lbIPadres.Text = huis.IPAdres; }
                else { lbIPadres.Text = "unknow"; }
                if (huis.Wifi==true) {
                    lbWifi.Text = "Yes";
                    lbWifiSSID.Text = huis.WifiSSID;
                    if (huis.WifiWEP == true) { lbWifiWEP.Text = "Yes"; }
                    if (huis.WifiWPA == true) { lbWifiWPA.Text = "No"; }
                    ShowWifiProperties(true);
                }
                else if (huis.Wifi == false) { 
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

        private void VeranderVenster(object sender, EventArgs e)
        {
            //winkel niet op werkbalk
            if ((sender == pbShop) || (sender == pbKnopshop))
            {                
                if (gbxShop.Visible == true) 
                {
                    pbKnopshop.Image = resourcehandler.loadimage("werkbalkknop_shop_off.png"); 
                    gbxShop.Visible=false;
                }
                else if (gbxShop.Visible == false)
                {
                    pbKnopshop.Image = resourcehandler.loadimage("werkbalkknop_shop_on.png"); 
                    gbxShop.Visible=true;
                }                                               

            }

            else if (sender == pbHuis3)
            {
                {
                    gbxHuis.Visible = true;
                    //todo: haal informatie huis op.
                }
            }
        }
  
 /*
                private void BuyItem(String itemnm)
                //private void BuyItem(object sender, EventArgs e)
                {
                    //Item test = inventory.getItem(sender.ToString());
                    //MessageBox.Show(test.NaamItem + " prijs: " + test.Prijs + " actief: "+Convert.ToString(test.Active));

            

                    if (itemnm == "wepcracker")
                    {
                        pbItemWifiWEPCracker.Visible = true;                
                
                        //TODO: Van de speler wordt geld af gehaalt,
                        //if (GamePlayer.geldopnemen(200) == true) { pbItemWepWifiCracker.Visible = true; }            
                    }
                    else if (itemnm == )
                    {
                        pbItemNetworkScanner.Visible = true;
                        btnBuyNeworkscanner.Enabled = false;
                    }
                    else if (sender == btnBuyKeylogger)
                    {
                        pbItemKeylogger.Visible = true;
                        btnBuyKeylogger.Enabled = false;
                    }
                    else if (sender == btnBuyWorm)
                    {
                        pbItemWorm.Visible = true;
                        btnBuyWorm.Enabled = false;
                    }
                    else if (sender == btnKoopVirus)
                    {
                        pbItemCoderedvirus.Visible = true;
                        btnKoopVirus.Enabled = false;
                    }
                    else
                    {
                        misc.ToonBericht(8);
                    }
 
                    resourcehandler.playsound("buy.wav", false);
                }   
         */

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
            //moet terug gegeven welk huis of de bank geselecteerd is.

            //communication.VerwerkData(data);            
        }

        public void inithuizen()
        {
            try
            {   
                //TODO: verzin betere namen.
                Huis[] huis = new Huis[6];
                huis[0] = new Huis(pbHuis1, "Your house", "33.23.34.45", true, "linksystems", false, true, true, true, false);
                huis[1] = new Huis(pbHuis2, "Jan de Vries", "66.23.34.45", true, "speedytouch", false, true, false, false, false);
                huis[2] = new Huis(pbHuis3, "Kees", "72.23.34.45", true, "netgears", true, true, false, false, false);
                huis[3] = new Huis(pbHuis4, "Pieter", "14.23.34.45", false, "", true, true, false, false, false);
                huis[4] = new Huis(pbHuis5, "Roel", "68.23.34.45", true, "draadloos324098", true, true, true, true, false);
                huis[5] = new Huis(pbHuis6, "Marrieke", "78.23.34.45", true, "linksystems", true, true, false, false, false);
                huizen.AddRange(huis);   
            }
            catch (Exception)
            {
                misc.ToonBericht(6);
            }
        }        

       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //TODO: toon groepbox bank met saldo rekeningnummer etc. etc.            
        }
        

        private void gbxShop_Paint(object sender, PaintEventArgs e)
        {

            int ypos = 220;
            for (int i = 0; i < inventory.numitems; i++)
            {
                Item curitem = inventory.getItemPos(i);

                Label lbitemnaam = new Label();
                lbitemnaam.Text = curitem.NaamItem;
                lbitemnaam.Location = new Point(280, ypos);
                lbitemnaam.ForeColor = Color.Lime;
                lbitemnaam.Visible = true;                

                Label lbitemprijs = new Label();
                lbitemprijs.Text = Convert.ToString(curitem.Prijs);
                lbitemprijs.ForeColor = Color.Lime;
                lbitemprijs.Location = new Point(380, ypos);
                lbitemnaam.Visible = true;                

                Button btnItembuy = new Button();
                btnItembuy.Name = curitem.NaamItem;
                btnItembuy.Text = "buy";
                btnItembuy.Location = new Point(480, ypos);
                btnItembuy.Width = 100;
                btnItembuy.Visible = true;
                btnItembuy.ForeColor = Color.Lime;
                btnItembuy.BackColor = Color.Black;
                btnItembuy.FlatStyle = FlatStyle.Flat;                
                btnItembuy.Click += new System.EventHandler(BuyItem);
                
                this.Controls.Add(lbitemnaam);
                this.Controls.Add(lbitemprijs);
                this.Controls.Add(btnItembuy);
                components.Add(btnItembuy);
                ypos += 20;

            }                                            
        }    


        public void BuyItem(object sender, EventArgs e)
        {
            //MessageBox.Show(sender.ToString());

            if (sender == this.components.Components[4])
            {
                this.pbItemWifiWEPCracker.Visible = true;
                if (inventory.addItemInventory("wepcracker") == false) {
                    werkbalk = WerkbalkState.INSTRUCTIE;

                }
            }
            else if (sender == this.components.Components[5])
            {
                this.pbItemKeylogger.Visible = true;
            }
            else if (sender == this.components.Components[6])
            {
                this.pbItemNetworkScanner.Visible = true;
            }
            else if (sender == this.components.Components[7])
            {
                this.pbItemWorm.Visible = true;
            }
            else if (sender == this.components.Components[8])
            {
                this.pbItemCoderedvirus.Visible = true;
            }
            else
                misc.ToonBericht(8);
            //throw new NotImplementedException();
             
        }

        #endregion

        /*
        private void BuyItem2(object sender, EventArgs e)
        {
            if (sender == this.button1)
            {
                MessageBox.Show("ok");
            }
            else if (sender == e)
            {
                MessageBox.Show("ok2");
            }
            else
            {
                MessageBox.Show("wrong");
            }            
        }
        */
    }

}
