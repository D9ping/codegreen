namespace CodeGreen
{
    partial class GameOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameOptions));
            this.lblTextOptions = new System.Windows.Forms.Label();
            this.TimerTextEffect = new System.Windows.Forms.Timer(this.components);
            this.tbVendorID = new System.Windows.Forms.TextBox();
            this.tbProductID = new System.Windows.Forms.TextBox();
            this.lbtextVendorID = new System.Windows.Forms.Label();
            this.lbTextProductID = new System.Windows.Forms.Label();
            this.cbxSwitchXaxis = new System.Windows.Forms.CheckBox();
            this.pbBackMenu = new System.Windows.Forms.PictureBox();
            this.bigCheckbox3 = new CodeGreen.BigCheckbox();
            this.bigCheckbox2 = new CodeGreen.BigCheckbox();
            this.bigCheckbox1 = new CodeGreen.BigCheckbox();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTextOptions
            // 
            resources.ApplyResources(this.lblTextOptions, "lblTextOptions");
            this.lblTextOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblTextOptions.Name = "lblTextOptions";
            this.lblTextOptions.UseCompatibleTextRendering = true;
            // 
            // TimerTextEffect
            // 
            this.TimerTextEffect.Enabled = true;
            this.TimerTextEffect.Interval = 50;
            this.TimerTextEffect.Tick += new System.EventHandler(this.TimerTextEffect_Tick);
            // 
            // tbVendorID
            // 
            this.tbVendorID.BackColor = System.Drawing.Color.Gray;
            this.tbVendorID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tbVendorID, "tbVendorID");
            this.tbVendorID.Name = "tbVendorID";
            this.tbVendorID.TextChanged += new System.EventHandler(this.tbVendorID_TextChanged);
            // 
            // tbProductID
            // 
            this.tbProductID.BackColor = System.Drawing.Color.Gray;
            this.tbProductID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tbProductID, "tbProductID");
            this.tbProductID.Name = "tbProductID";
            this.tbProductID.TextChanged += new System.EventHandler(this.tbProductID_TextChanged);
            // 
            // lbtextVendorID
            // 
            resources.ApplyResources(this.lbtextVendorID, "lbtextVendorID");
            this.lbtextVendorID.ForeColor = System.Drawing.Color.Lime;
            this.lbtextVendorID.Name = "lbtextVendorID";
            this.lbtextVendorID.UseCompatibleTextRendering = true;
            // 
            // lbTextProductID
            // 
            resources.ApplyResources(this.lbTextProductID, "lbTextProductID");
            this.lbTextProductID.ForeColor = System.Drawing.Color.Lime;
            this.lbTextProductID.Name = "lbTextProductID";
            this.lbTextProductID.UseCompatibleTextRendering = true;
            // 
            // cbxSwitchXaxis
            // 
            resources.ApplyResources(this.cbxSwitchXaxis, "cbxSwitchXaxis");
            this.cbxSwitchXaxis.ForeColor = System.Drawing.Color.Lime;
            this.cbxSwitchXaxis.Name = "cbxSwitchXaxis";
            this.cbxSwitchXaxis.UseCompatibleTextRendering = true;
            this.cbxSwitchXaxis.UseVisualStyleBackColor = true;
            this.cbxSwitchXaxis.CheckedChanged += new System.EventHandler(this.cbxSwitchXaxis_CheckedChanged);
            // 
            // pbBackMenu
            // 
            this.pbBackMenu.Image = global::CodeGreen.Properties.Resources.knop_backmainmenu;
            resources.ApplyResources(this.pbBackMenu, "pbBackMenu");
            this.pbBackMenu.Name = "pbBackMenu";
            this.pbBackMenu.TabStop = false;
            this.pbBackMenu.Click += new System.EventHandler(this.pbBackMenu_Click);
            // 
            // bigCheckbox3
            // 
            this.bigCheckbox3.BackColor = System.Drawing.Color.Transparent;
            this.bigCheckbox3.Caption = "Music";
            this.bigCheckbox3.IsChecked = false;
            resources.ApplyResources(this.bigCheckbox3, "bigCheckbox3");
            this.bigCheckbox3.Name = "bigCheckbox3";
            // 
            // bigCheckbox2
            // 
            this.bigCheckbox2.BackColor = System.Drawing.Color.Transparent;
            this.bigCheckbox2.Caption = "Remote controller";
            this.bigCheckbox2.IsChecked = false;
            resources.ApplyResources(this.bigCheckbox2, "bigCheckbox2");
            this.bigCheckbox2.Name = "bigCheckbox2";
            // 
            // bigCheckbox1
            // 
            this.bigCheckbox1.BackColor = System.Drawing.Color.Transparent;
            this.bigCheckbox1.Caption = "Sounds";
            this.bigCheckbox1.IsChecked = false;
            resources.ApplyResources(this.bigCheckbox1, "bigCheckbox1");
            this.bigCheckbox1.Name = "bigCheckbox1";
            // 
            // GameOptions
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.bigCheckbox3);
            this.Controls.Add(this.bigCheckbox2);
            this.Controls.Add(this.bigCheckbox1);
            this.Controls.Add(this.cbxSwitchXaxis);
            this.Controls.Add(this.lbTextProductID);
            this.Controls.Add(this.lbtextVendorID);
            this.Controls.Add(this.tbProductID);
            this.Controls.Add(this.tbVendorID);
            this.Controls.Add(this.pbBackMenu);
            this.Controls.Add(this.lblTextOptions);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "GameOptions";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameOptions_Paint);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameOptions_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pbBackMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTextOptions;
        private System.Windows.Forms.PictureBox pbBackMenu;
        private System.Windows.Forms.TextBox tbVendorID;
        private System.Windows.Forms.TextBox tbProductID;
        private System.Windows.Forms.Label lbtextVendorID;
        private System.Windows.Forms.Label lbTextProductID;
        private System.Windows.Forms.CheckBox cbxSwitchXaxis;
        private System.Windows.Forms.Timer TimerTextEffect;
        private BigCheckbox bigCheckbox1;
        private BigCheckbox bigCheckbox2;
        private BigCheckbox bigCheckbox3;

    }
}