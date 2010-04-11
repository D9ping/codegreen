namespace CodeGreen
{
    partial class lbHighscoreInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(lbHighscoreInfo));
            this.pbBackMenu = new System.Windows.Forms.PictureBox();
            this.gbxNewHighscore = new System.Windows.Forms.GroupBox();
            this.lbHighscorenInfo = new System.Windows.Forms.Label();
            this.btAddHighscore = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbTextNaam = new System.Windows.Forms.Label();
            this.gbxHighscoren = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timerTextEffect = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbBackMenu)).BeginInit();
            this.gbxNewHighscore.SuspendLayout();
            this.gbxHighscoren.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBackMenu
            // 
            this.pbBackMenu.Image = global::CodeGreen.Properties.Resources.knop_backmainmenu;
            resources.ApplyResources(this.pbBackMenu, "pbBackMenu");
            this.pbBackMenu.Name = "pbBackMenu";
            this.pbBackMenu.TabStop = false;
            this.pbBackMenu.MouseLeave += new System.EventHandler(this.pbBackMenu_MouseLeave);
            this.pbBackMenu.Click += new System.EventHandler(this.pbBackMenu_Click);
            this.pbBackMenu.MouseEnter += new System.EventHandler(this.pbBackMenu_MouseEnter);
            // 
            // gbxNewHighscore
            // 
            this.gbxNewHighscore.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.gbxNewHighscore, "gbxNewHighscore");
            this.gbxNewHighscore.Controls.Add(this.lbHighscorenInfo);
            this.gbxNewHighscore.Controls.Add(this.btAddHighscore);
            this.gbxNewHighscore.Controls.Add(this.tbName);
            this.gbxNewHighscore.Controls.Add(this.lbTextNaam);
            this.gbxNewHighscore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbxNewHighscore.Name = "gbxNewHighscore";
            this.gbxNewHighscore.TabStop = false;
            this.gbxNewHighscore.UseCompatibleTextRendering = true;
            // 
            // lbHighscorenInfo
            // 
            resources.ApplyResources(this.lbHighscorenInfo, "lbHighscorenInfo");
            this.lbHighscorenInfo.BackColor = System.Drawing.Color.Black;
            this.lbHighscorenInfo.Name = "lbHighscorenInfo";
            this.lbHighscorenInfo.UseCompatibleTextRendering = true;
            // 
            // btAddHighscore
            // 
            this.btAddHighscore.BackColor = System.Drawing.Color.Black;
            this.btAddHighscore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            resources.ApplyResources(this.btAddHighscore, "btAddHighscore");
            this.btAddHighscore.ForeColor = System.Drawing.Color.Lime;
            this.btAddHighscore.Name = "btAddHighscore";
            this.btAddHighscore.UseCompatibleTextRendering = true;
            this.btAddHighscore.UseVisualStyleBackColor = false;
            this.btAddHighscore.Click += new System.EventHandler(this.btAddHighscore_Click);
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tbName, "tbName");
            this.tbName.ForeColor = System.Drawing.Color.Lime;
            this.tbName.Name = "tbName";
            this.tbName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbName_KeyDown);
            // 
            // lbTextNaam
            // 
            resources.ApplyResources(this.lbTextNaam, "lbTextNaam");
            this.lbTextNaam.BackColor = System.Drawing.Color.Black;
            this.lbTextNaam.ForeColor = System.Drawing.Color.Lime;
            this.lbTextNaam.Name = "lbTextNaam";
            this.lbTextNaam.UseCompatibleTextRendering = true;
            // 
            // gbxHighscoren
            // 
            this.gbxHighscoren.Controls.Add(this.pictureBox2);
            this.gbxHighscoren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbxHighscoren.ForeColor = System.Drawing.Color.Lime;
            resources.ApplyResources(this.gbxHighscoren, "gbxHighscoren");
            this.gbxHighscoren.Name = "gbxHighscoren";
            this.gbxHighscoren.TabStop = false;
            this.gbxHighscoren.UseCompatibleTextRendering = true;
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // timerTextEffect
            // 
            this.timerTextEffect.Tick += new System.EventHandler(this.timerTextEffect_Tick);
            // 
            // lbHighscoreInfo
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.gbxHighscoren);
            this.Controls.Add(this.gbxNewHighscore);
            this.Controls.Add(this.pbBackMenu);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Lime;
            this.MaximizeBox = false;
            this.Name = "lbHighscoreInfo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameHighscore_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pbBackMenu)).EndInit();
            this.gbxNewHighscore.ResumeLayout(false);
            this.gbxNewHighscore.PerformLayout();
            this.gbxHighscoren.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBackMenu;
        private System.Windows.Forms.GroupBox gbxNewHighscore;
        private System.Windows.Forms.Button btAddHighscore;
        private System.Windows.Forms.Label lbTextNaam;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.GroupBox gbxHighscoren;
        private System.Windows.Forms.Label lbHighscorenInfo;
        private System.Windows.Forms.Timer timerTextEffect;
        private System.Windows.Forms.PictureBox pictureBox2;

    }
}