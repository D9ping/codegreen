using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CodeGreen
{
    public class DropText
    {
        private string text;
        private Brush color;
        private Point location;

        /// <summary>
        /// Init. new instance of ...
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
