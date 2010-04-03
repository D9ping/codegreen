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
            this.lblOptionSound = new System.Windows.Forms.Label();
            this.lblTextOptions = new System.Windows.Forms.Label();
            this.TimerTextEffect = new System.Windows.Forms.Timer(this.components);
            this.lbOptionController = new System.Windows.Forms.Label();
            this.tbVendorID = new System.Windows.Forms.TextBox();
            this.tbProductID = new System.Windows.Forms.TextBox();
            this.lbtextVendorID = new System.Windows.Forms.Label();
            this.lbTextProductID = new System.Windows.Forms.Label();
            this.cbxSwitchXaxis = new System.Windows.Forms.CheckBox();
            this.pbStateController = new System.Windows.Forms.PictureBox();
            this.pbBackMenu = new System.Windows.Forms.PictureBox();
            this.pbStateSound = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbStateController)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStateSound)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOptionSound
            // 
            resources.ApplyResources(this.lblOptionSound, "lblOptionSound");
            this.lblOptionSound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblOptionSound.Name = "lblOptionSound";
            this.lblOptionSound.UseCompatibleTextRendering = true;
            this.lblOptionSound.MouseLeave += new System.EventHandler(this.knop_normal);
            this.lblOptionSound.Click += new System.EventHandler(this.lblOptionSound_Click);
            this.lblOptionSound.MouseHover += new System.EventHandler(this.knop_hover);
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
            // lbOptionController
            // 
            resources.ApplyResources(this.lbOptionController, "lbOptionController");
            this.lbOptionController.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbOptionController.Name = "lbOptionController";
            this.lbOptionController.UseCompatibleTextRendering = true;
            this.lbOptionController.MouseLeave += new System.EventHandler(this.knop_normal);
            this.lbOptionController.Click += new System.EventHandler(this.lbOptionController_Click);
            this.lbOptionController.MouseHover += new System.EventHandler(this.knop_hover);
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
            // pbStateController
            // 
            resources.ApplyResources(this.pbStateController, "pbStateController");
            this.pbStateController.Name = "pbStateController";
            this.pbStateController.TabStop = false;
            // 
            // pbBackMenu
            // 
            resources.ApplyResources(this.pbBackMenu, "pbBackMenu");
            this.pbBackMenu.Name = "pbBackMenu";
            this.pbBackMenu.TabStop = false;
            this.pbBackMenu.Click += new System.EventHandler(this.pbBackMenu_Click);
            this.pbBackMenu.MouseHover += new System.EventHandler(this.knop_hover);
            // 
            // pbStateSound
            // 
            resources.ApplyResources(this.pbStateSound, "pbStateSound");
            this.pbStateSound.Name = "pbStateSound";
            this.pbStateSound.TabStop = false;
            // 
            // GameOptions
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.cbxSwitchXaxis);
            this.Controls.Add(this.lbTextProductID);
            this.Controls.Add(this.lbtextVendorID);
            this.Controls.Add(this.tbProductID);
            this.Controls.Add(this.tbVendorID);
            this.Controls.Add(this.pbStateController);
            this.Controls.Add(this.lbOptionController);
            this.Controls.Add(this.pbBackMenu);
            this.Controls.Add(this.lblTextOptions);
            this.Controls.Add(this.lblOptionSound);
            this.Controls.Add(this.pbStateSound);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "GameOptions";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameOptions_Paint);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameOptions_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pbStateController)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStateSound)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbStateSound;
        private System.Windows.Forms.Label lblOptionSound;
        private System.Windows.Forms.Label lblTextOptions;
        private System.Windows.Forms.PictureBox pbBackMenu;
        private System.Windows.Forms.Label lbOptionController;
        private System.Windows.Forms.PictureBox pbStateController;
        private System.Windows.Forms.TextBox tbVendorID;
        private System.Windows.Forms.TextBox tbProductID;
        private System.Windows.Forms.Label lbtextVendorID;
        private System.Windows.Forms.Label lbTextProductID;
        private System.Windows.Forms.CheckBox cbxSwitchXaxis;
        private System.Windows.Forms.Timer TimerTextEffect;

    }
}