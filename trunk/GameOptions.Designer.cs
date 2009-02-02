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
            this.pbStateController = new System.Windows.Forms.PictureBox();
            this.pbBackMenu = new System.Windows.Forms.PictureBox();
            this.pbStateSound = new System.Windows.Forms.PictureBox();
            this.tbVendorID = new System.Windows.Forms.TextBox();
            this.tbProductID = new System.Windows.Forms.TextBox();
            this.lbtextVendorID = new System.Windows.Forms.Label();
            this.lbTextProductID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbStateController)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStateSound)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOptionSound
            // 
            this.lblOptionSound.AutoSize = true;
            this.lblOptionSound.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptionSound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblOptionSound.Location = new System.Drawing.Point(123, 151);
            this.lblOptionSound.Name = "lblOptionSound";
            this.lblOptionSound.Size = new System.Drawing.Size(92, 31);
            this.lblOptionSound.TabIndex = 1;
            this.lblOptionSound.Text = "Sound";
            this.lblOptionSound.MouseLeave += new System.EventHandler(this.knop_normal);
            this.lblOptionSound.Click += new System.EventHandler(this.lblOptionSound_Click);
            this.lblOptionSound.MouseHover += new System.EventHandler(this.knop_hover);
            // 
            // lblTextOptions
            // 
            this.lblTextOptions.AutoSize = true;
            this.lblTextOptions.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblTextOptions.Location = new System.Drawing.Point(286, 33);
            this.lblTextOptions.Name = "lblTextOptions";
            this.lblTextOptions.Size = new System.Drawing.Size(34, 36);
            this.lblTextOptions.TabIndex = 2;
            this.lblTextOptions.Text = "_";
            // 
            // TimerTextEffect
            // 
            this.TimerTextEffect.Enabled = true;
            this.TimerTextEffect.Tick += new System.EventHandler(this.TimerTextEffect_Tick);
            // 
            // lbOptionController
            // 
            this.lbOptionController.AutoSize = true;
            this.lbOptionController.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOptionController.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbOptionController.Location = new System.Drawing.Point(123, 255);
            this.lbOptionController.Name = "lbOptionController";
            this.lbOptionController.Size = new System.Drawing.Size(228, 31);
            this.lbOptionController.TabIndex = 4;
            this.lbOptionController.Text = "Remote controller";
            this.lbOptionController.MouseLeave += new System.EventHandler(this.knop_normal);
            this.lbOptionController.Click += new System.EventHandler(this.lbOptionController_Click);
            this.lbOptionController.MouseHover += new System.EventHandler(this.knop_hover);
            // 
            // pbStateController
            // 
            this.pbStateController.Image = ((System.Drawing.Image)(resources.GetObject("pbStateController.Image")));
            this.pbStateController.Location = new System.Drawing.Point(33, 226);
            this.pbStateController.Name = "pbStateController";
            this.pbStateController.Size = new System.Drawing.Size(84, 82);
            this.pbStateController.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStateController.TabIndex = 5;
            this.pbStateController.TabStop = false;
            // 
            // pbBackMenu
            // 
            this.pbBackMenu.Image = ((System.Drawing.Image)(resources.GetObject("pbBackMenu.Image")));
            this.pbBackMenu.Location = new System.Drawing.Point(277, 487);
            this.pbBackMenu.Name = "pbBackMenu";
            this.pbBackMenu.Size = new System.Drawing.Size(201, 45);
            this.pbBackMenu.TabIndex = 3;
            this.pbBackMenu.TabStop = false;
            this.pbBackMenu.Click += new System.EventHandler(this.pbBackMenu_Click);
            this.pbBackMenu.MouseHover += new System.EventHandler(this.knop_hover);
            // 
            // pbStateSound
            // 
            this.pbStateSound.Image = ((System.Drawing.Image)(resources.GetObject("pbStateSound.Image")));
            this.pbStateSound.Location = new System.Drawing.Point(33, 123);
            this.pbStateSound.Name = "pbStateSound";
            this.pbStateSound.Size = new System.Drawing.Size(84, 82);
            this.pbStateSound.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStateSound.TabIndex = 0;
            this.pbStateSound.TabStop = false;
            // 
            // tbVendorID
            // 
            this.tbVendorID.Location = new System.Drawing.Point(677, 244);
            this.tbVendorID.Name = "tbVendorID";
            this.tbVendorID.Size = new System.Drawing.Size(73, 20);
            this.tbVendorID.TabIndex = 6;
            this.tbVendorID.Text = "????";
            this.tbVendorID.TextChanged += new System.EventHandler(this.tbVendorID_TextChanged);
            // 
            // tbProductID
            // 
            this.tbProductID.Location = new System.Drawing.Point(677, 267);
            this.tbProductID.Name = "tbProductID";
            this.tbProductID.Size = new System.Drawing.Size(73, 20);
            this.tbProductID.TabIndex = 7;
            this.tbProductID.Text = "????";
            this.tbProductID.TextChanged += new System.EventHandler(this.tbProductID_TextChanged);
            // 
            // lbtextVendorID
            // 
            this.lbtextVendorID.AutoSize = true;
            this.lbtextVendorID.ForeColor = System.Drawing.Color.Lime;
            this.lbtextVendorID.Location = new System.Drawing.Point(617, 247);
            this.lbtextVendorID.Name = "lbtextVendorID";
            this.lbtextVendorID.Size = new System.Drawing.Size(55, 13);
            this.lbtextVendorID.TabIndex = 8;
            this.lbtextVendorID.Text = "Vendor ID";
            // 
            // lbTextProductID
            // 
            this.lbTextProductID.AutoSize = true;
            this.lbTextProductID.ForeColor = System.Drawing.Color.Lime;
            this.lbTextProductID.Location = new System.Drawing.Point(613, 274);
            this.lbTextProductID.Name = "lbTextProductID";
            this.lbTextProductID.Size = new System.Drawing.Size(58, 13);
            this.lbTextProductID.TabIndex = 9;
            this.lbTextProductID.Text = "Product ID";
            // 
            // GameOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(784, 564);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameOptions";
            this.Text = "Codegreen Options";
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
        public System.Windows.Forms.Timer TimerTextEffect;
        private System.Windows.Forms.Label lbOptionController;
        private System.Windows.Forms.PictureBox pbStateController;
        private System.Windows.Forms.TextBox tbVendorID;
        private System.Windows.Forms.TextBox tbProductID;
        private System.Windows.Forms.Label lbtextVendorID;
        private System.Windows.Forms.Label lbTextProductID;

    }
}