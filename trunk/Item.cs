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
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Item class.
    /// </summary>
    class Item
    {
        #region datavelden
        //int pos;
        //object pbitem;
        String naamitem;
        int prijs;
        bool active;
        #endregion

        #region constructor
        public Item(String naamitem, int prijs)
        {
            this.naamitem = naamitem;
            this.prijs = prijs;
            this.active = false;
        }
        #endregion

        #region properties
        
        public String NaamItem
        {
            get { return this.naamitem; }
        }
        public int Prijs
        {
            get { return this.prijs; }
        }
        public bool Active
        {
            get { return this.active; }
            set { this.active = value; }
        }

        #endregion

        #region methoden
        #endregion
    }
}
