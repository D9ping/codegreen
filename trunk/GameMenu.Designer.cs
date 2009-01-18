namespace CodeGreen
{
    partial class GameMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameMenu));
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.pbHighscore = new System.Windows.Forms.PictureBox();
            this.pbOptions = new System.Windows.Forms.PictureBox();
            this.pbStartGame = new System.Windows.Forms.PictureBox();
            this.pbTitel = new System.Windows.Forms.PictureBox();
            this.timerDropText = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHighscore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStartGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitel)).BeginInit();
            this.SuspendLayout();
            // 
            // pbExit
            // 
            this.pbExit.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.pbExit.BackColor = System.Drawing.Color.Transparent;
            this.pbExit.Image = ((System.Drawing.Image)(resources.GetObject("pbExit.Image")));
            this.pbExit.Location = new System.Drawing.Point(555, 480);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(200, 41);
            this.pbExit.TabIndex = 3;
            this.pbExit.TabStop = false;
            this.pbExit.MouseLeave += new System.EventHandler(this.knop_normal);
            this.pbExit.Click += new System.EventHandler(this.GameShutdown);
            this.pbExit.MouseHover += new System.EventHandler(this.knop_hover);
            // 
            // pbHighscore
            // 
            this.pbHighscore.BackColor = System.Drawing.Color.Transparent;
            this.pbHighscore.Image = ((System.Drawing.Image)(resources.GetObject("pbHighscore.Image")));
            this.pbHighscore.Location = new System.Drawing.Point(555, 434);
            this.pbHighscore.Name = "pbHighscore";
            this.pbHighscore.Size = new System.Drawing.Size(200, 40);
            this.pbHighscore.TabIndex = 2;
            this.pbHighscore.TabStop = false;
            this.pbHighscore.MouseLeave += new System.EventHandler(this.knop_normal);
            this.pbHighscore.MouseHover += new System.EventHandler(this.knop_hover);
            // 
            // pbOptions
            // 
            this.pbOptions.BackColor = System.Drawing.Color.Transparent;
            this.pbOptions.Image = ((System.Drawing.Image)(resources.GetObject("pbOptions.Image")));
            this.pbOptions.Location = new System.Drawing.Point(555, 388);
            this.pbOptions.Name = "pbOptions";
            this.pbOptions.Size = new System.Drawing.Size(200, 40);
            this.pbOptions.TabIndex = 1;
            this.pbOptions.TabStop = false;
            this.pbOptions.MouseLeave += new System.EventHandler(this.knop_normal);
            this.pbOptions.Click += new System.EventHandler(this.pbOptions_Click);
            this.pbOptions.MouseHover += new System.EventHandler(this.knop_hover);
            // 
            // pbStartGame
            // 
            this.pbStartGame.BackColor = System.Drawing.Color.Transparent;
            this.pbStartGame.Image = ((System.Drawing.Image)(resources.GetObject("pbStartGame.Image")));
            this.pbStartGame.InitialImage = null;
            this.pbStartGame.Location = new System.Drawing.Point(555, 342);
            this.pbStartGame.Name = "pbStartGame";
            this.pbStartGame.Size = new System.Drawing.Size(200, 40);
            this.pbStartGame.TabIndex = 0;
            this.pbStartGame.TabStop = false;
            this.pbStartGame.MouseLeave += new System.EventHandler(this.knop_normal);
            this.pbStartGame.Click += new System.EventHandler(this.pbStartGame_Click);
            this.pbStartGame.MouseHover += new System.EventHandler(this.knop_hover);
            // 
            // pbTitel
            // 
            this.pbTitel.BackColor = System.Drawing.Color.Transparent;
            this.pbTitel.Image = ((System.Drawing.Image)(resources.GetObject("pbTitel.Image")));
            this.pbTitel.Location = new System.Drawing.Point(-5, -1);
            this.pbTitel.Name = "pbTitel";
            this.pbTitel.Size = new System.Drawing.Size(760, 324);
            this.pbTitel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTitel.TabIndex = 0;
            this.pbTitel.TabStop = false;
            // 
            // timerDropText
            // 
            this.timerDropText.Enabled = true;
            this.timerDropText.Tick += new System.EventHandler(this.timerDropText_Tick);
            // 
            // GameMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(784, 564);
            this.Controls.Add(this.pbExit);
            this.Controls.Add(this.pbHighscore);
            this.Controls.Add(this.pbOptions);
            this.Controls.Add(this.pbStartGame);
            this.Controls.Add(this.pbTitel);
            this.Name = "GameMenu";
            this.Text = "CodeGreen";
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHighscore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStartGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTitel;
        private System.Windows.Forms.PictureBox pbExit;
        private System.Windows.Forms.PictureBox pbHighscore;
        private System.Windows.Forms.PictureBox pbOptions;
        private System.Windows.Forms.PictureBox pbStartGame;
        private System.Windows.Forms.Timer timerDropText;
    }
}

