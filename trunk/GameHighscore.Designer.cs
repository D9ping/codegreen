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
            ((System.ComponentModel.ISupportInitialize)(this.pbBackMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBackMenu
            // 
            this.pbBackMenu.Image = ((System.Drawing.Image)(resources.GetObject("pbBackMenu.Image")));
            this.pbBackMenu.Location = new System.Drawing.Point(266, 471);
            this.pbBackMenu.Name = "pbBackMenu";
            this.pbBackMenu.Size = new System.Drawing.Size(201, 45);
            this.pbBackMenu.TabIndex = 4;
            this.pbBackMenu.TabStop = false;
            this.pbBackMenu.Click += new System.EventHandler(this.pbBackMenu_Click);
            // 
            // GameHighscore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(784, 564);
            this.Controls.Add(this.pbBackMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameHighscore";
            this.Text = "Highscore";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameHighscore_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pbBackMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBackMenu;

    }
}