namespace CodeGreen
{
    partial class GameHighscore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameHighscore));
            this.pbBackMenu = new System.Windows.Forms.PictureBox();
            this.gbxNewHighscore = new System.Windows.Forms.GroupBox();
            this.btAddHighscore = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbTextNaam = new System.Windows.Forms.Label();
            this.gbxHighscoren = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackMenu)).BeginInit();
            this.gbxNewHighscore.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbBackMenu
            // 
            this.pbBackMenu.Image = ((System.Drawing.Image)(resources.GetObject("pbBackMenu.Image")));
            this.pbBackMenu.Location = new System.Drawing.Point(288, 507);
            this.pbBackMenu.Name = "pbBackMenu";
            this.pbBackMenu.Size = new System.Drawing.Size(201, 45);
            this.pbBackMenu.TabIndex = 4;
            this.pbBackMenu.TabStop = false;
            this.pbBackMenu.Click += new System.EventHandler(this.pbBackMenu_Click);
            // 
            // gbxNewHighscore
            // 
            this.gbxNewHighscore.BackColor = System.Drawing.Color.Transparent;
            this.gbxNewHighscore.Controls.Add(this.btAddHighscore);
            this.gbxNewHighscore.Controls.Add(this.tbName);
            this.gbxNewHighscore.Controls.Add(this.lbTextNaam);
            this.gbxNewHighscore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbxNewHighscore.Location = new System.Drawing.Point(12, 12);
            this.gbxNewHighscore.Name = "gbxNewHighscore";
            this.gbxNewHighscore.Size = new System.Drawing.Size(574, 260);
            this.gbxNewHighscore.TabIndex = 5;
            this.gbxNewHighscore.TabStop = false;
            this.gbxNewHighscore.Visible = false;
            // 
            // btAddHighscore
            // 
            this.btAddHighscore.BackColor = System.Drawing.Color.Black;
            this.btAddHighscore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.btAddHighscore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAddHighscore.ForeColor = System.Drawing.Color.Lime;
            this.btAddHighscore.Location = new System.Drawing.Point(466, 229);
            this.btAddHighscore.Name = "btAddHighscore";
            this.btAddHighscore.Size = new System.Drawing.Size(59, 23);
            this.btAddHighscore.TabIndex = 1;
            this.btAddHighscore.Text = "ok";
            this.btAddHighscore.UseVisualStyleBackColor = false;
            this.btAddHighscore.Click += new System.EventHandler(this.btAddHighscore_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(326, 231);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(123, 20);
            this.tbName.TabIndex = 2;
            // 
            // lbTextNaam
            // 
            this.lbTextNaam.AutoSize = true;
            this.lbTextNaam.ForeColor = System.Drawing.Color.Lime;
            this.lbTextNaam.Location = new System.Drawing.Point(208, 234);
            this.lbTextNaam.Name = "lbTextNaam";
            this.lbTextNaam.Size = new System.Drawing.Size(112, 13);
            this.lbTextNaam.TabIndex = 0;
            this.lbTextNaam.Text = "enter your (nick)name:";
            // 
            // gbxHighscoren
            // 
            this.gbxHighscoren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbxHighscoren.ForeColor = System.Drawing.Color.Lime;
            this.gbxHighscoren.Location = new System.Drawing.Point(12, 289);
            this.gbxHighscoren.Name = "gbxHighscoren";
            this.gbxHighscoren.Size = new System.Drawing.Size(574, 176);
            this.gbxHighscoren.TabIndex = 3;
            this.gbxHighscoren.TabStop = false;
            this.gbxHighscoren.Text = "Hall of fame hackers";
            this.gbxHighscoren.Visible = false;
            // 
            // GameHighscore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(784, 564);
            this.Controls.Add(this.gbxHighscoren);
            this.Controls.Add(this.gbxNewHighscore);
            this.Controls.Add(this.pbBackMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameHighscore";
            this.Text = "Highscore";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameHighscore_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pbBackMenu)).EndInit();
            this.gbxNewHighscore.ResumeLayout(false);
            this.gbxNewHighscore.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBackMenu;
        private System.Windows.Forms.GroupBox gbxNewHighscore;
        private System.Windows.Forms.Button btAddHighscore;
        private System.Windows.Forms.Label lbTextNaam;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.GroupBox gbxHighscoren;

    }
}