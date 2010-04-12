namespace CodeGreen
{
    partial class BigCheckbox
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbCheckbox = new System.Windows.Forms.PictureBox();
            this.lbTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCheckbox)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCheckbox
            // 
            this.pbCheckbox.Image = global::CodeGreen.Properties.Resources.checkbox_off;
            this.pbCheckbox.Location = new System.Drawing.Point(3, 0);
            this.pbCheckbox.Name = "pbCheckbox";
            this.pbCheckbox.Size = new System.Drawing.Size(97, 91);
            this.pbCheckbox.TabIndex = 0;
            this.pbCheckbox.TabStop = false;
            this.pbCheckbox.Click += new System.EventHandler(this.SwitchCheck);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.Green;
            this.lbTitle.Location = new System.Drawing.Point(106, 27);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(128, 42);
            this.lbTitle.TabIndex = 1;
            this.lbTitle.Text = "Option";
            this.lbTitle.MouseLeave += new System.EventHandler(this.lbTitle_MouseLeave);
            this.lbTitle.Click += new System.EventHandler(this.SwitchCheck);
            this.lbTitle.MouseEnter += new System.EventHandler(this.lbTitle_MouseEnter);
            // 
            // BigCheckbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.pbCheckbox);
            this.Name = "BigCheckbox";
            this.Size = new System.Drawing.Size(416, 92);
            ((System.ComponentModel.ISupportInitialize)(this.pbCheckbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCheckbox;
        private System.Windows.Forms.Label lbTitle;
    }
}
