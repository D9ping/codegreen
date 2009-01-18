namespace CodeGreen
{
    partial class GameScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameScreen));
            this.TimerTextEffect = new System.Windows.Forms.Timer(this.components);
            this.lblIntroTextLine1 = new System.Windows.Forms.Label();
            this.gbxGameInstructions = new System.Windows.Forms.GroupBox();
            this.lbPlayerMoney = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progbarServerload = new System.Windows.Forms.ProgressBar();
            this.pbKnopInventory = new System.Windows.Forms.PictureBox();
            this.gbxInventory = new System.Windows.Forms.GroupBox();
            this.pbItemWifiWEPCracker = new System.Windows.Forms.PictureBox();
            this.pbItemNetworkSniffer = new System.Windows.Forms.PictureBox();
            this.gbxShop = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnKoopVirus = new System.Windows.Forms.Button();
            this.btnKoopWorm = new System.Windows.Forms.Button();
            this.btnBuyWifiwepcracker = new System.Windows.Forms.Button();
            this.btnBuyneworkscanner = new System.Windows.Forms.Button();
            this.btnBuynetworksniffer = new System.Windows.Forms.Button();
            this.pbItemNetworkScanner = new System.Windows.Forms.PictureBox();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.pbKnopBank = new System.Windows.Forms.PictureBox();
            this.pbSoftwareshop = new System.Windows.Forms.PictureBox();
            this.pbBank = new System.Windows.Forms.PictureBox();
            this.pbHuis2 = new System.Windows.Forms.PictureBox();
            this.pbHuis5 = new System.Windows.Forms.PictureBox();
            this.pbHuis1 = new System.Windows.Forms.PictureBox();
            this.pbHuis3 = new System.Windows.Forms.PictureBox();
            this.pbHuis4 = new System.Windows.Forms.PictureBox();
            this.pbHuis6 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbKnopshop = new System.Windows.Forms.PictureBox();
            this.lbPlayerTime = new System.Windows.Forms.Label();
            this.TimerGametime = new System.Windows.Forms.Timer(this.components);
            this.usb = new UsbLibrary.UsbHidPort(this.components);
            this.gbxHuis = new System.Windows.Forms.GroupBox();
            this.lbHuisWifi = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbHuisNaam = new System.Windows.Forms.Label();
            this.lbTextHuis = new System.Windows.Forms.Label();
            this.gbxBank = new System.Windows.Forms.GroupBox();
            this.pbTruck1 = new System.Windows.Forms.PictureBox();
            this.gbxGameInstructions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbKnopInventory)).BeginInit();
            this.gbxInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemWifiWEPCracker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemNetworkSniffer)).BeginInit();
            this.gbxShop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemNetworkScanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbKnopBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSoftwareshop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHuis2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHuis5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHuis1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHuis3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHuis4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHuis6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbKnopshop)).BeginInit();
            this.gbxHuis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTruck1)).BeginInit();
            this.SuspendLayout();
            // 
            // TimerTextEffect
            // 
            this.TimerTextEffect.Tick += new System.EventHandler(this.TimerTextEffect_Tick);
            // 
            // lblIntroTextLine1
            // 
            this.lblIntroTextLine1.AutoSize = true;
            this.lblIntroTextLine1.BackColor = System.Drawing.Color.Transparent;
            this.lblIntroTextLine1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntroTextLine1.ForeColor = System.Drawing.Color.Lime;
            this.lblIntroTextLine1.Location = new System.Drawing.Point(6, 16);
            this.lblIntroTextLine1.Name = "lblIntroTextLine1";
            this.lblIntroTextLine1.Size = new System.Drawing.Size(48, 18);
            this.lblIntroTextLine1.TabIndex = 4;
            this.lblIntroTextLine1.Text = "(..)";
            // 
            // gbxGameInstructions
            // 
            this.gbxGameInstructions.BackColor = System.Drawing.Color.Transparent;
            this.gbxGameInstructions.Controls.Add(this.lblIntroTextLine1);
            this.gbxGameInstructions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbxGameInstructions.Location = new System.Drawing.Point(160, 480);
            this.gbxGameInstructions.Name = "gbxGameInstructions";
            this.gbxGameInstructions.Size = new System.Drawing.Size(620, 80);
            this.gbxGameInstructions.TabIndex = 5;
            this.gbxGameInstructions.TabStop = false;
            this.gbxGameInstructions.Text = ",";
            // 
            // lbPlayerMoney
            // 
            this.lbPlayerMoney.AutoSize = true;
            this.lbPlayerMoney.BackColor = System.Drawing.Color.Transparent;
            this.lbPlayerMoney.Font = new System.Drawing.Font("Cordia New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlayerMoney.ForeColor = System.Drawing.Color.Lime;
            this.lbPlayerMoney.Location = new System.Drawing.Point(116, 540);
            this.lbPlayerMoney.Name = "lbPlayerMoney";
            this.lbPlayerMoney.Size = new System.Drawing.Size(31, 22);
            this.lbPlayerMoney.TabIndex = 11;
            this.lbPlayerMoney.Text = "0,00";
            this.lbPlayerMoney.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(94, 541);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "$";
            // 
            // progbarServerload
            // 
            this.progbarServerload.Location = new System.Drawing.Point(22, 8);
            this.progbarServerload.Name = "progbarServerload";
            this.progbarServerload.Size = new System.Drawing.Size(85, 23);
            this.progbarServerload.TabIndex = 6;
            // 
            // pbKnopInventory
            // 
            this.pbKnopInventory.BackColor = System.Drawing.Color.Transparent;
            this.pbKnopInventory.Image = ((System.Drawing.Image)(resources.GetObject("pbKnopInventory.Image")));
            this.pbKnopInventory.Location = new System.Drawing.Point(12, 447);
            this.pbKnopInventory.Name = "pbKnopInventory";
            this.pbKnopInventory.Size = new System.Drawing.Size(32, 29);
            this.pbKnopInventory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbKnopInventory.TabIndex = 7;
            this.pbKnopInventory.TabStop = false;
            this.tooltip.SetToolTip(this.pbKnopInventory, "open inventory");
            this.pbKnopInventory.Click += new System.EventHandler(this.VeranderWerkbalk);
            // 
            // gbxInventory
            // 
            this.gbxInventory.BackColor = System.Drawing.Color.Transparent;
            this.gbxInventory.Controls.Add(this.pbItemWifiWEPCracker);
            this.gbxInventory.Controls.Add(this.pbItemNetworkSniffer);
            this.gbxInventory.Controls.Add(this.gbxShop);
            this.gbxInventory.Controls.Add(this.pbItemNetworkScanner);
            this.gbxInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbxInventory.ForeColor = System.Drawing.Color.White;
            this.gbxInventory.Location = new System.Drawing.Point(12, 120);
            this.gbxInventory.Name = "gbxInventory";
            this.gbxInventory.Size = new System.Drawing.Size(345, 66);
            this.gbxInventory.TabIndex = 6;
            this.gbxInventory.TabStop = false;
            this.gbxInventory.Text = "Inventory";
            this.gbxInventory.Visible = false;
            // 
            // pbItemWifiWEPCracker
            // 
            this.pbItemWifiWEPCracker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbItemWifiWEPCracker.Image = ((System.Drawing.Image)(resources.GetObject("pbItemWifiWEPCracker.Image")));
            this.pbItemWifiWEPCracker.Location = new System.Drawing.Point(16, 16);
            this.pbItemWifiWEPCracker.Name = "pbItemWifiWEPCracker";
            this.pbItemWifiWEPCracker.Size = new System.Drawing.Size(79, 47);
            this.pbItemWifiWEPCracker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbItemWifiWEPCracker.TabIndex = 2;
            this.pbItemWifiWEPCracker.TabStop = false;
            this.tooltip.SetToolTip(this.pbItemWifiWEPCracker, "Wifi WEP cracker");
            this.pbItemWifiWEPCracker.Visible = false;
            // 
            // pbItemNetworkSniffer
            // 
            this.pbItemNetworkSniffer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbItemNetworkSniffer.Image = ((System.Drawing.Image)(resources.GetObject("pbItemNetworkSniffer.Image")));
            this.pbItemNetworkSniffer.Location = new System.Drawing.Point(235, 13);
            this.pbItemNetworkSniffer.Name = "pbItemNetworkSniffer";
            this.pbItemNetworkSniffer.Size = new System.Drawing.Size(74, 50);
            this.pbItemNetworkSniffer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbItemNetworkSniffer.TabIndex = 1;
            this.pbItemNetworkSniffer.TabStop = false;
            this.tooltip.SetToolTip(this.pbItemNetworkSniffer, "Netwerk sniffer");
            this.pbItemNetworkSniffer.Visible = false;
            // 
            // gbxShop
            // 
            this.gbxShop.BackColor = System.Drawing.Color.Transparent;
            this.gbxShop.Controls.Add(this.label8);
            this.gbxShop.Controls.Add(this.label7);
            this.gbxShop.Controls.Add(this.label6);
            this.gbxShop.Controls.Add(this.label5);
            this.gbxShop.Controls.Add(this.label4);
            this.gbxShop.Controls.Add(this.btnKoopVirus);
            this.gbxShop.Controls.Add(this.btnKoopWorm);
            this.gbxShop.Controls.Add(this.btnBuyWifiwepcracker);
            this.gbxShop.Controls.Add(this.btnBuyneworkscanner);
            this.gbxShop.Controls.Add(this.btnBuynetworksniffer);
            this.gbxShop.ForeColor = System.Drawing.Color.White;
            this.gbxShop.Location = new System.Drawing.Point(330, 56);
            this.gbxShop.Name = "gbxShop";
            this.gbxShop.Size = new System.Drawing.Size(351, 238);
            this.gbxShop.TabIndex = 22;
            this.gbxShop.TabStop = false;
            this.gbxShop.Text = "Welcome to Nixxons!";
            this.gbxShop.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Code red-virus         800$";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Netwerk scanner       250$";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "WEPcracker            100$";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Worm                       250$";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Keylogger                 100$";
            // 
            // btnKoopVirus
            // 
            this.btnKoopVirus.ForeColor = System.Drawing.Color.Black;
            this.btnKoopVirus.Location = new System.Drawing.Point(230, 190);
            this.btnKoopVirus.Name = "btnKoopVirus";
            this.btnKoopVirus.Size = new System.Drawing.Size(65, 24);
            this.btnKoopVirus.TabIndex = 12;
            this.btnKoopVirus.Text = "Koop!";
            this.btnKoopVirus.UseVisualStyleBackColor = true;
            // 
            // btnKoopWorm
            // 
            this.btnKoopWorm.ForeColor = System.Drawing.Color.Black;
            this.btnKoopWorm.Location = new System.Drawing.Point(230, 81);
            this.btnKoopWorm.Name = "btnKoopWorm";
            this.btnKoopWorm.Size = new System.Drawing.Size(65, 24);
            this.btnKoopWorm.TabIndex = 11;
            this.btnKoopWorm.Text = "Koop!";
            this.btnKoopWorm.UseVisualStyleBackColor = true;
            this.btnKoopWorm.Click += new System.EventHandler(this.btnKoopWorm_Click);
            // 
            // btnBuyWifiwepcracker
            // 
            this.btnBuyWifiwepcracker.ForeColor = System.Drawing.Color.Black;
            this.btnBuyWifiwepcracker.Location = new System.Drawing.Point(228, 118);
            this.btnBuyWifiwepcracker.Name = "btnBuyWifiwepcracker";
            this.btnBuyWifiwepcracker.Size = new System.Drawing.Size(67, 24);
            this.btnBuyWifiwepcracker.TabIndex = 9;
            this.btnBuyWifiwepcracker.Text = "Koop!";
            this.btnBuyWifiwepcracker.UseVisualStyleBackColor = true;
            this.btnBuyWifiwepcracker.Click += new System.EventHandler(this.btnBuyWifiwepcracker_Click);
            // 
            // btnBuyneworkscanner
            // 
            this.btnBuyneworkscanner.ForeColor = System.Drawing.Color.Black;
            this.btnBuyneworkscanner.Location = new System.Drawing.Point(230, 155);
            this.btnBuyneworkscanner.Name = "btnBuyneworkscanner";
            this.btnBuyneworkscanner.Size = new System.Drawing.Size(65, 24);
            this.btnBuyneworkscanner.TabIndex = 10;
            this.btnBuyneworkscanner.Text = "Koop!";
            this.btnBuyneworkscanner.UseVisualStyleBackColor = true;
            this.btnBuyneworkscanner.Click += new System.EventHandler(this.btnBuyneworkscanner_Click);
            // 
            // btnBuynetworksniffer
            // 
            this.btnBuynetworksniffer.ForeColor = System.Drawing.Color.Black;
            this.btnBuynetworksniffer.Location = new System.Drawing.Point(230, 43);
            this.btnBuynetworksniffer.Name = "btnBuynetworksniffer";
            this.btnBuynetworksniffer.Size = new System.Drawing.Size(65, 26);
            this.btnBuynetworksniffer.TabIndex = 8;
            this.btnBuynetworksniffer.Text = "Koop!";
            this.btnBuynetworksniffer.UseVisualStyleBackColor = true;
            this.btnBuynetworksniffer.Click += new System.EventHandler(this.btnBuynetworksniffer_Click);
            // 
            // pbItemNetworkScanner
            // 
            this.pbItemNetworkScanner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbItemNetworkScanner.Image = ((System.Drawing.Image)(resources.GetObject("pbItemNetworkScanner.Image")));
            this.pbItemNetworkScanner.Location = new System.Drawing.Point(129, 13);
            this.pbItemNetworkScanner.Name = "pbItemNetworkScanner";
            this.pbItemNetworkScanner.Size = new System.Drawing.Size(73, 50);
            this.pbItemNetworkScanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbItemNetworkScanner.TabIndex = 0;
            this.pbItemNetworkScanner.TabStop = false;
            this.tooltip.SetToolTip(this.pbItemNetworkScanner, "Netwerk scanner");
            this.pbItemNetworkScanner.Visible = false;
            // 
            // pbKnopBank
            // 
            this.pbKnopBank.BackColor = System.Drawing.Color.Transparent;
            this.pbKnopBank.Image = ((System.Drawing.Image)(resources.GetObject("pbKnopBank.Image")));
            this.pbKnopBank.Location = new System.Drawing.Point(48, 454);
            this.pbKnopBank.Name = "pbKnopBank";
            this.pbKnopBank.Size = new System.Drawing.Size(32, 29);
            this.pbKnopBank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbKnopBank.TabIndex = 22;
            this.pbKnopBank.TabStop = false;
            this.tooltip.SetToolTip(this.pbKnopBank, "login bank");
            this.pbKnopBank.Click += new System.EventHandler(this.VeranderWerkbalk);
            // 
            // pbSoftwareshop
            // 
            this.pbSoftwareshop.BackColor = System.Drawing.Color.Transparent;
            this.pbSoftwareshop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSoftwareshop.Location = new System.Drawing.Point(141, 324);
            this.pbSoftwareshop.Name = "pbSoftwareshop";
            this.pbSoftwareshop.Size = new System.Drawing.Size(127, 90);
            this.pbSoftwareshop.TabIndex = 13;
            this.pbSoftwareshop.TabStop = false;
            this.tooltip.SetToolTip(this.pbSoftwareshop, "Nixxons sells a whole bunch of handy PC tools.");
            this.pbSoftwareshop.Click += new System.EventHandler(this.VeranderVenster);
            // 
            // pbBank
            // 
            this.pbBank.BackColor = System.Drawing.Color.Transparent;
            this.pbBank.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbBank.Location = new System.Drawing.Point(37, 228);
            this.pbBank.Name = "pbBank";
            this.pbBank.Size = new System.Drawing.Size(119, 90);
            this.pbBank.TabIndex = 14;
            this.pbBank.TabStop = false;
            this.tooltip.SetToolTip(this.pbBank, "Pabobank ensures that your money is safely stored, \r\nthey also offer an account w" +
                    "ith online access.");
            this.pbBank.Click += new System.EventHandler(this.VeranderWerkbalk);
            // 
            // pbHuis2
            // 
            this.pbHuis2.BackColor = System.Drawing.Color.Transparent;
            this.pbHuis2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbHuis2.Location = new System.Drawing.Point(372, 41);
            this.pbHuis2.Name = "pbHuis2";
            this.pbHuis2.Size = new System.Drawing.Size(103, 82);
            this.pbHuis2.TabIndex = 15;
            this.pbHuis2.TabStop = false;
            this.tooltip.SetToolTip(this.pbHuis2, "Someone lives here...");
            this.pbHuis2.Click += new System.EventHandler(this.VeranderWerkbalk);
            // 
            // pbHuis5
            // 
            this.pbHuis5.BackColor = System.Drawing.Color.Transparent;
            this.pbHuis5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbHuis5.Location = new System.Drawing.Point(348, 335);
            this.pbHuis5.Name = "pbHuis5";
            this.pbHuis5.Size = new System.Drawing.Size(100, 105);
            this.pbHuis5.TabIndex = 16;
            this.pbHuis5.TabStop = false;
            this.tooltip.SetToolTip(this.pbHuis5, "Someone lives here...");
            this.pbHuis5.Click += new System.EventHandler(this.VeranderWerkbalk);
            // 
            // pbHuis1
            // 
            this.pbHuis1.BackColor = System.Drawing.Color.Transparent;
            this.pbHuis1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbHuis1.Location = new System.Drawing.Point(324, 148);
            this.pbHuis1.Name = "pbHuis1";
            this.pbHuis1.Size = new System.Drawing.Size(89, 70);
            this.pbHuis1.TabIndex = 17;
            this.pbHuis1.TabStop = false;
            this.tooltip.SetToolTip(this.pbHuis1, "Someone lives here...");
            this.pbHuis1.Click += new System.EventHandler(this.VeranderWerkbalk);
            // 
            // pbHuis3
            // 
            this.pbHuis3.BackColor = System.Drawing.Color.Transparent;
            this.pbHuis3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbHuis3.Location = new System.Drawing.Point(481, 138);
            this.pbHuis3.Name = "pbHuis3";
            this.pbHuis3.Size = new System.Drawing.Size(83, 78);
            this.pbHuis3.TabIndex = 18;
            this.pbHuis3.TabStop = false;
            this.tooltip.SetToolTip(this.pbHuis3, "You live here.\r\n\'Cause there are a lot of houses nearby,\r\nyou can receive their w" +
                    "ireless\r\nnetwork traffic too.");
            this.pbHuis3.Click += new System.EventHandler(this.VeranderWerkbalk);
            // 
            // pbHuis4
            // 
            this.pbHuis4.BackColor = System.Drawing.Color.Transparent;
            this.pbHuis4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbHuis4.Location = new System.Drawing.Point(595, 45);
            this.pbHuis4.Name = "pbHuis4";
            this.pbHuis4.Size = new System.Drawing.Size(83, 78);
            this.pbHuis4.TabIndex = 19;
            this.pbHuis4.TabStop = false;
            this.tooltip.SetToolTip(this.pbHuis4, "Someone lives here...");
            this.pbHuis4.Click += new System.EventHandler(this.VeranderWerkbalk);
            // 
            // pbHuis6
            // 
            this.pbHuis6.BackColor = System.Drawing.Color.Transparent;
            this.pbHuis6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbHuis6.Location = new System.Drawing.Point(595, 351);
            this.pbHuis6.Name = "pbHuis6";
            this.pbHuis6.Size = new System.Drawing.Size(108, 79);
            this.pbHuis6.TabIndex = 20;
            this.pbHuis6.TabStop = false;
            this.tooltip.SetToolTip(this.pbHuis6, "Your ex\'s place...You REALLY don\'t want to be here!");
            this.pbHuis6.Click += new System.EventHandler(this.VeranderWerkbalk);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(97, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(199, 90);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            this.tooltip.SetToolTip(this.pictureBox1, "Microsoft datacenter... \r\nHighly secured building.");
            // 
            // pbKnopshop
            // 
            this.pbKnopshop.BackColor = System.Drawing.Color.Transparent;
            this.pbKnopshop.Image = ((System.Drawing.Image)(resources.GetObject("pbKnopshop.Image")));
            this.pbKnopshop.Location = new System.Drawing.Point(72, 486);
            this.pbKnopshop.Name = "pbKnopshop";
            this.pbKnopshop.Size = new System.Drawing.Size(24, 24);
            this.pbKnopshop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbKnopshop.TabIndex = 24;
            this.pbKnopshop.TabStop = false;
            this.tooltip.SetToolTip(this.pbKnopshop, "login bank");
            this.pbKnopshop.Click += new System.EventHandler(this.VeranderVenster);
            // 
            // lbPlayerTime
            // 
            this.lbPlayerTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPlayerTime.AutoEllipsis = true;
            this.lbPlayerTime.AutoSize = true;
            this.lbPlayerTime.BackColor = System.Drawing.Color.Transparent;
            this.lbPlayerTime.Font = new System.Drawing.Font("Cordia New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlayerTime.ForeColor = System.Drawing.Color.Lime;
            this.lbPlayerTime.Location = new System.Drawing.Point(116, 507);
            this.lbPlayerTime.Name = "lbPlayerTime";
            this.lbPlayerTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbPlayerTime.Size = new System.Drawing.Size(21, 22);
            this.lbPlayerTime.TabIndex = 12;
            this.lbPlayerTime.Text = "0s";
            // 
            // TimerGametime
            // 
            this.TimerGametime.Interval = 50;
            this.TimerGametime.Tick += new System.EventHandler(this.TimerGametime_Tick);
            // 
            // usb
            // 
            this.usb.OnDataRecieved += new UsbLibrary.OnDataRecievedEventHandler(this.usb_OnDataRecieved);
            // 
            // gbxHuis
            // 
            this.gbxHuis.BackColor = System.Drawing.Color.Transparent;
            this.gbxHuis.Controls.Add(this.lbHuisWifi);
            this.gbxHuis.Controls.Add(this.label3);
            this.gbxHuis.Controls.Add(this.lbHuisNaam);
            this.gbxHuis.Controls.Add(this.lbTextHuis);
            this.gbxHuis.ForeColor = System.Drawing.Color.White;
            this.gbxHuis.Location = new System.Drawing.Point(12, 192);
            this.gbxHuis.Name = "gbxHuis";
            this.gbxHuis.Size = new System.Drawing.Size(341, 74);
            this.gbxHuis.TabIndex = 21;
            this.gbxHuis.TabStop = false;
            this.gbxHuis.Text = "Informatie Huis";
            this.gbxHuis.Visible = false;
            // 
            // lbHuisWifi
            // 
            this.lbHuisWifi.AutoSize = true;
            this.lbHuisWifi.ForeColor = System.Drawing.Color.Lime;
            this.lbHuisWifi.Location = new System.Drawing.Point(78, 50);
            this.lbHuisWifi.Name = "lbHuisWifi";
            this.lbHuisWifi.Size = new System.Drawing.Size(19, 13);
            this.lbHuisWifi.TabIndex = 3;
            this.lbHuisWifi.Text = "(..)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(25, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Huis:";
            // 
            // lbHuisNaam
            // 
            this.lbHuisNaam.AutoSize = true;
            this.lbHuisNaam.ForeColor = System.Drawing.Color.Lime;
            this.lbHuisNaam.Location = new System.Drawing.Point(78, 24);
            this.lbHuisNaam.Name = "lbHuisNaam";
            this.lbHuisNaam.Size = new System.Drawing.Size(19, 13);
            this.lbHuisNaam.TabIndex = 1;
            this.lbHuisNaam.Text = "(..)";
            // 
            // lbTextHuis
            // 
            this.lbTextHuis.AutoSize = true;
            this.lbTextHuis.ForeColor = System.Drawing.Color.Lime;
            this.lbTextHuis.Location = new System.Drawing.Point(25, 24);
            this.lbTextHuis.Name = "lbTextHuis";
            this.lbTextHuis.Size = new System.Drawing.Size(31, 13);
            this.lbTextHuis.TabIndex = 0;
            this.lbTextHuis.Text = "Huis:";
            // 
            // gbxBank
            // 
            this.gbxBank.BackColor = System.Drawing.Color.Transparent;
            this.gbxBank.ForeColor = System.Drawing.Color.White;
            this.gbxBank.Location = new System.Drawing.Point(12, 335);
            this.gbxBank.Name = "gbxBank";
            this.gbxBank.Size = new System.Drawing.Size(324, 79);
            this.gbxBank.TabIndex = 22;
            this.gbxBank.TabStop = false;
            this.gbxBank.Text = "Pabobank INC.";
            this.gbxBank.Visible = false;
            // 
            // pbTruck1
            // 
            this.pbTruck1.BackColor = System.Drawing.Color.Transparent;
            this.pbTruck1.Image = ((System.Drawing.Image)(resources.GetObject("pbTruck1.Image")));
            this.pbTruck1.InitialImage = null;
            this.pbTruck1.Location = new System.Drawing.Point(-23, 305);
            this.pbTruck1.Name = "pbTruck1";
            this.pbTruck1.Size = new System.Drawing.Size(45, 23);
            this.pbTruck1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbTruck1.TabIndex = 25;
            this.pbTruck1.TabStop = false;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 564);
            this.Controls.Add(this.pbHuis5);
            this.Controls.Add(this.pbKnopshop);
            this.Controls.Add(this.gbxBank);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbKnopBank);
            this.Controls.Add(this.gbxHuis);
            this.Controls.Add(this.pbHuis6);
            this.Controls.Add(this.pbHuis4);
            this.Controls.Add(this.pbHuis3);
            this.Controls.Add(this.pbHuis1);
            this.Controls.Add(this.pbHuis2);
            this.Controls.Add(this.pbSoftwareshop);
            this.Controls.Add(this.lbPlayerTime);
            this.Controls.Add(this.lbPlayerMoney);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbxInventory);
            this.Controls.Add(this.pbKnopInventory);
            this.Controls.Add(this.progbarServerload);
            this.Controls.Add(this.gbxGameInstructions);
            this.Controls.Add(this.pbTruck1);
            this.Controls.Add(this.pbBank);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameScreen";
            this.Text = "CodeGreen - alpha";
            this.Shown += new System.EventHandler(this.GameScreen_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameScreen_FormClosed);
            this.gbxGameInstructions.ResumeLayout(false);
            this.gbxGameInstructions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbKnopInventory)).EndInit();
            this.gbxInventory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbItemWifiWEPCracker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemNetworkSniffer)).EndInit();
            this.gbxShop.ResumeLayout(false);
            this.gbxShop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemNetworkScanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbKnopBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSoftwareshop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHuis2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHuis5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHuis1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHuis3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHuis4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHuis6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbKnopshop)).EndInit();
            this.gbxHuis.ResumeLayout(false);
            this.gbxHuis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTruck1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Timer TimerTextEffect;
        private System.Windows.Forms.Label lblIntroTextLine1;
        private System.Windows.Forms.GroupBox gbxGameInstructions;
        private System.Windows.Forms.ProgressBar progbarServerload;
        private System.Windows.Forms.PictureBox pbKnopInventory;
        private System.Windows.Forms.GroupBox gbxInventory;
        private System.Windows.Forms.Button btnBuynetworksniffer;
        private System.Windows.Forms.PictureBox pbItemNetworkScanner;
        private System.Windows.Forms.PictureBox pbItemNetworkSniffer;
        private System.Windows.Forms.PictureBox pbItemWifiWEPCracker;
        private System.Windows.Forms.Button btnBuyWifiwepcracker;
        private System.Windows.Forms.Button btnBuyneworkscanner;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbPlayerMoney;
        private System.Windows.Forms.Label lbPlayerTime;
        public System.Windows.Forms.Timer TimerGametime;
        private UsbLibrary.UsbHidPort usb;
        private System.Windows.Forms.PictureBox pbSoftwareshop;
        private System.Windows.Forms.PictureBox pbBank;
        private System.Windows.Forms.PictureBox pbHuis2;
        private System.Windows.Forms.PictureBox pbHuis5;
        private System.Windows.Forms.PictureBox pbHuis1;
        private System.Windows.Forms.PictureBox pbHuis3;
        private System.Windows.Forms.PictureBox pbHuis4;
        private System.Windows.Forms.PictureBox pbHuis6;
        private System.Windows.Forms.GroupBox gbxHuis;
        private System.Windows.Forms.Label lbTextHuis;
        private System.Windows.Forms.Label lbHuisNaam;
        private System.Windows.Forms.PictureBox pbKnopBank;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox gbxShop;
        private System.Windows.Forms.GroupBox gbxBank;
        private System.Windows.Forms.PictureBox pbKnopshop;
        private System.Windows.Forms.Button btnKoopWorm;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnKoopVirus;
        private System.Windows.Forms.Label lbHuisWifi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbTruck1;
    }
}