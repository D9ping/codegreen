//-----------------------------------------------------------------------
// <copyright file="DropText.cs" company="GNU">
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
    using System.Collections.Generic;
    using System.Text;
    using System.Drawing;

    public class DropText
    {
        private string text;
        private Brush color;
        private Point location;

        /// <summary>
        /// Initializes a new instance of DropText class.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        /// <param name="locX"></param>
        public DropText(string text, Brush color, int locX)
        {
            this.color = color;
            this.text = text;
            this.location = new Point(locX, -50);
        }

        /// <summary>
        /// Get 
        /// </summary>
        public string Text
        {
            get
            {
                return this.text;
            }
        }

        /// <summary>
        /// Get 
        /// </summary>
        public Brush Color
        {
            get
            {
                return this.color;
            }
        }

        /// <summary>
        /// Gets or sets
        /// </summary>
        public Point Location
        {
            get
            {
                return this.location;
            }
            set
            {
                this.location = value;
            }
        }
    }
}
