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
    using System.Drawing;

    /// <summary>
    /// DropText class.
    /// </summary>
    public class DropText
    {
        /// <summary>
        /// The text of the falling text
        /// </summary>
        private string text;

        /// <summary>
        /// The color of the falling text.
        /// </summary>
        private Brush color;

        /// <summary>
        /// The topleft losition of the text
        /// </summary>
        private Point location;

        /// <summary>
        /// Initializes a new instance of the DropText class.
        /// </summary>
        /// <param name="text">The text of the droptext</param>
        /// <param name="color">The color of the droptext</param>
        /// <param name="locX">the x location where the droptext should start</param>
        public DropText(string text, Brush color, int locX)
        {
            this.color = color;
            this.text = text;
            this.location = new Point(locX, -50);
        }

        /// <summary>
        /// Gets the text valeau
        /// </summary>
        public string Text
        {
            get
            {
                return this.text;
            }
        }

        /// <summary>
        /// Gets the color of the falling text
        /// </summary>
        public Brush Color
        {
            get
            {
                return this.color;
            }
        }

        /// <summary>
        /// Gets or sets the top left location of the falling text.
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
