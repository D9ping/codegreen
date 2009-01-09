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
            this.pbItemWepWifiCracker = new System.Windows.Forms.PictureBox();
            this.pbItemNetworkSniffer = new System.Windows.Forms.PictureBox();
            this.pbItemNetworkScanner = new System.Windows.Forms.PictureBox();
            this.btnBuynetworksniffer = new System.Windows.Forms.Button();
            this.btnBuyWifiwepcracker = new System.Windows.Forms.Button();
            this.btnBuyneworkscanner = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lbPlayerTime = new System.Windows.Forms.Label();
            this.TimerGametime = new System.Windows.Forms.Timer(this.components);
            this.gbxGameInstructions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbKnopInventory)).BeginInit();
            this.gbxInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemWepWifiCracker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemNetworkSniffer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemNetworkScanner)).BeginInit();
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(89, 542);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
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
            // 
            // gbxInventory
            // 
            this.gbxInventory.BackColor = System.Drawing.Color.Transparent;
            this.gbxInventory.Controls.Add(this.pbItemWepWifiCracker);
            this.gbxInventory.Controls.Add(this.pbItemNetworkSniffer);
            this.gbxInventory.Controls.Add(this.pbItemNetworkScanner);
            this.gbxInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbxInventory.ForeColor = System.Drawing.Color.White;
            this.gbxInventory.Location = new System.Drawing.Point(12, 50);
            this.gbxInventory.Name = "gbxInventory";
            this.gbxInventory.Size = new System.Drawing.Size(636, 85);
            this.gbxInventory.TabIndex = 6;
            this.gbxInventory.TabStop = false;
            this.gbxInventory.Text = "Inventory";
            this.gbxInventory.Visible = false;
            // 
            // pbItemWepWifiCracker
            // 
            this.pbItemWepWifiCracker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbItemWepWifiCracker.Image = ((System.Drawing.Image)(resources.GetObject("pbItemWepWifiCracker.Image")));
            this.pbItemWepWifiCracker.Location = new System.Drawing.Point(10, 16);
            this.pbItemWepWifiCracker.Name = "pbItemWepWifiCracker";
            this.pbItemWepWifiCracker.Size = new System.Drawing.Size(79, 47);
            this.pbItemWepWifiCracker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbItemWepWifiCracker.TabIndex = 2;
            this.pbItemWepWifiCracker.TabStop = false;
            this.toolTip.SetToolTip(this.pbItemWepWifiCracker, "Wifi WEP cracker");
            this.pbItemWepWifiCracker.Visible = false;
            // 
            // pbItemNetworkSniffer
            // 
            this.pbItemNetworkSniffer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbItemNetworkSniffer.Image = ((System.Drawing.Image)(resources.GetObject("pbItemNetworkSniffer.Image")));
            this.pbItemNetworkSniffer.Location = new System.Drawing.Point(206, 16);
            this.pbItemNetworkSniffer.Name = "pbItemNetworkSniffer";
            this.pbItemNetworkSniffer.Size = new System.Drawing.Size(74, 50);
            this.pbItemNetworkSniffer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbItemNetworkSniffer.TabIndex = 1;
            this.pbItemNetworkSniffer.TabStop = false;
            this.toolTip.SetToolTip(this.pbItemNetworkSniffer, "Netwerk sniffer");
            this.pbItemNetworkSniffer.Visible = false;
            // 
            // pbItemNetworkScanner
            // 
            this.pbItemNetworkScanner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbItemNetworkScanner.Image = ((System.Drawing.Image)(resources.GetObject("pbItemNetworkScanner.Image")));
            this.pbItemNetworkScanner.Location = new System.Drawing.Point(108, 16);
            this.pbItemNetworkScanner.Name = "pbItemNetworkScanner";
            this.pbItemNetworkScanner.Size = new System.Drawing.Size(73, 50);
            this.pbItemNetworkScanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbItemNetworkScanner.TabIndex = 0;
            this.pbItemNetworkScanner.TabStop = false;
            this.toolTip.SetToolTip(this.pbItemNetworkScanner, "Netwerk scanner");
            this.pbItemNetworkScanner.Visible = false;
            // 
            // btnBuynetworksniffer
            // 
            this.btnBuynetworksniffer.Location = new System.Drawing.Point(640, 252);
            this.btnBuynetworksniffer.Name = "btnBuynetworksniffer";
            this.btnBuynetworksniffer.Size = new System.Drawing.Size(115, 24);
            this.btnBuynetworksniffer.TabIndex = 8;
            this.btnBuynetworksniffer.Text = "buy network sniffer";
            this.btnBuynetworksniffer.UseVisualStyleBackColor = true;
            this.btnBuynetworksniffer.Click += new System.EventHandler(this.btnBuynetworksniffer_Click);
            // 
            // btnBuyWifiwepcracker
            // 
            this.btnBuyWifiwepcracker.Location = new System.Drawing.Point(640, 192);
            this.btnBuyWifiwepcracker.Name = "btnBuyWifiwepcracker";
            this.btnBuyWifiwepcracker.Size = new System.Drawing.Size(115, 24);
            this.btnBuyWifiwepcracker.TabIndex = 9;
            this.btnBuyWifiwepcracker.Text = "buy wep wifi cracker";
            this.btnBuyWifiwepcracker.UseVisualStyleBackColor = true;
            this.btnBuyWifiwepcracker.Click += new System.EventHandler(this.btnBuyWifiwepcracker_Click);
            // 
            // btnBuyneworkscanner
            // 
            this.btnBuyneworkscanner.Location = new System.Drawing.Point(640, 222);
            this.btnBuyneworkscanner.Name = "btnBuyneworkscanner";
            this.btnBuyneworkscanner.Size = new System.Drawing.Size(115, 24);
            this.btnBuyneworkscanner.TabIndex = 10;
            this.btnBuyneworkscanner.Text = "buy networkscanner";
            this.btnBuyneworkscanner.UseVisualStyleBackColor = true;
            this.btnBuyneworkscanner.Click += new System.EventHandler(this.btnBuyneworkscanner_Click);
            // 
            // lbPlayerTime
            // 
            this.lbPlayerTime.AutoSize = true;
            this.lbPlayerTime.BackColor = System.Drawing.Color.Transparent;
            this.lbPlayerTime.Font = new System.Drawing.Font("Cordia New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlayerTime.ForeColor = System.Drawing.Color.Lime;
            this.lbPlayerTime.Location = new System.Drawing.Point(126, 508);
            this.lbPlayerTime.Name = "lbPlayerTime";
            this.lbPlayerTime.Size = new System.Drawing.Size(21, 22);
            this.lbPlayerTime.TabIndex = 12;
            this.lbPlayerTime.Text = "0s";
            this.lbPlayerTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TimerGametime
            // 
            this.TimerGametime.Interval = 1000;
            this.TimerGametime.Tick += new System.EventHandler(this.TimerGametime_Tick);
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 564);
            this.Controls.Add(this.lbPlayerTime);
            this.Controls.Add(this.lbPlayerMoney);
            this.Controls.Add(this.btnBuyneworkscanner);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuyWifiwepcracker);
            this.Controls.Add(this.btnBuynetworksniffer);
            this.Controls.Add(this.gbxInventory);
            this.Controls.Add(this.pbKnopInventory);
            this.Controls.Add(this.progbarServerload);
            this.Controls.Add(this.gbxGameInstructions);
            this.Name = "GameScreen";
            this.Text = "CodeGreen - pre-alpha";
            this.Shown += new System.EventHandler(this.GameScreen_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameScreen_FormClosed);
            this.gbxGameInstructions.ResumeLayout(false);
            this.gbxGameInstructions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbKnopInventory)).EndInit();
            this.gbxInventory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbItemWepWifiCracker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemNetworkSniffer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemNetworkScanner)).EndInit();
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
        private System.Windows.Forms.PictureBox pbItemWepWifiCracker;
        private System.Windows.Forms.Button btnBuyWifiwepcracker;
        private System.Windows.Forms.Button btnBuyneworkscanner;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbPlayerMoney;
        private System.Windows.Forms.Label lbPlayerTime;
        public System.Windows.Forms.Timer TimerGametime;
    }
}