//-----------------------------------------------------------------------
// <copyright file="Item.cs" company="GNU">
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

    /// <summary>
    /// Item class.
    /// </summary>
    public class Item
    {
        #region datavelden
        /// <summary>
        /// name of the item.
        /// </summary>
        private string naamitem;

        /// <summary>
        /// The price of the item.
        /// </summary>
        private int prijs;

        /// <summary>
        /// Is the valeau active
        /// </summary>
        private bool active;
        #endregion

        #region constructor
        /// <summary>
        /// Initializes a new instance of the Item class.
        /// </summary>
        /// <param name="naamitem">The name of the item.</param>
        /// <param name="prijs">The price of the item.</param>
        public Item(string naamitem, int prijs)
        {
            this.naamitem = naamitem;
            this.prijs = prijs;
            this.active = false;
        }
        #endregion

        #region properties
        
        /// <summary>
        /// Gets the name of the item.
        /// </summary>
        public string NaamItem
        {
            get
            {
                return this.naamitem; 
            }
        }

        /// <summary>
        /// Gets the price of the item.
        /// </summary>
        public int Prijs
        {
            get
            {
                return this.prijs;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the item is actived.
        /// </summary>
        public bool Active
        {
            get 
            {
                return this.active; 
            }

            set
            { 
                this.active = value;
            }
        }

        #endregion

        #region methoden
        #endregion
    }
}
