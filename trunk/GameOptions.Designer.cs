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
            this.pbStateSound = new System.Windows.Forms.PictureBox();
            this.lblOptionSound = new System.Windows.Forms.Label();
            this.lblTextOptions = new System.Windows.Forms.Label();
            this.pbBackMenu = new System.Windows.Forms.PictureBox();
            this.TimerTextEffect = new System.Windows.Forms.Timer(this.components);
            this.lbOptionController = new System.Windows.Forms.Label();
            this.pbStateController = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbStateSound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStateController)).BeginInit();
            this.SuspendLayout();
            // 
            // pbStateSound
            // 
            this.pbStateSound.Image = global::CodeGreen.Properties.Resources.checkbox_on;
            this.pbStateSound.Location = new System.Drawing.Point(33, 123);
            this.pbStateSound.Name = "pbStateSound";
            this.pbStateSound.Size = new System.Drawing.Size(84, 82);
            this.pbStateSound.TabIndex = 0;
            this.pbStateSound.TabStop = false;
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
            // TimerTextEffect
            // 
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
            this.pbStateController.Image = global::CodeGreen.Properties.Resources.checkbox_on;
            this.pbStateController.Location = new System.Drawing.Point(33, 226);
            this.pbStateController.Name = "pbStateController";
            this.pbStateController.Size = new System.Drawing.Size(84, 82);
            this.pbStateController.TabIndex = 5;
            this.pbStateController.TabStop = false;
            // 
            // GameOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(784, 564);
            this.Controls.Add(this.pbStateController);
            this.Controls.Add(this.lbOptionController);
            this.Controls.Add(this.pbBackMenu);
            this.Controls.Add(this.lblTextOptions);
            this.Controls.Add(this.lblOptionSound);
            this.Controls.Add(this.pbStateSound);
            this.Name = "GameOptions";
            this.Text = "GameOptions";
            this.Shown += new System.EventHandler(this.GameOptions_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameOptions_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pbStateSound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStateController)).EndInit();
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

    }
}