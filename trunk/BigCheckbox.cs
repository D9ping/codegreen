//-----------------------------------------------------------------------
// <copyright file="BigCheckbox.cs" company="GNU">
// 
// This program is free software; you can redistribute it and/or modify it
// Free Software Foundation; either version 2, 
// or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// </copyright>
//-----------------------------------------------------------------------
namespace CodeGreen
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class BigCheckbox : UserControl
    {
        private bool ischecked = false;

        public BigCheckbox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the caption/title of the checkbox.
        /// </summary>
        public string Caption
        {
            get
            {
                return this.lbTitle.Text;
            }

            set
            {
                this.lbTitle.Text = value;
            }
        }


        public bool IsChecked
        {
            get
            {
                return this.ischecked;
            }
            set
            {
                this.ischecked = value;
                if (value)
                {
                    this.pbCheckbox.Image = CodeGreen.Properties.Resources.checkbox_on;
                }
                else
                {
                    this.pbCheckbox.Image = CodeGreen.Properties.Resources.checkbox_off;
                }
            }
        }

        private void lbTitle_MouseEnter(object sender, EventArgs e)
        {
            this.lbTitle.ForeColor = Color.Yellow;
        }

        private void lbTitle_MouseLeave(object sender, EventArgs e)
        {
            this.lbTitle.ForeColor = Color.Green;
        }
    }
}
