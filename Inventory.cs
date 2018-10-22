//-----------------------------------------------------------------------
// <copyright file="Inventory.cs" company="GNU">
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

    /// <summary>
    /// The inventory of the player.
    /// </summary>
    public class Inventory
    {
        #region datavelden
        /// <summary>
        /// A list of all shop items and a list of the items the player bought.
        /// </summary>
        private List<Item> shopitems, youritems;
        #endregion

        #region constructor
        /// <summary>
        /// Initializes a new instance of the Inventory class.
        /// </summary>
        public Inventory()
        {
            this.shopitems = new List<Item>();
            this.youritems = new List<Item>();

            Item[] items = new Item[6];
            items[0] = new Item("wepcracker", 75);
            items[1] = new Item("keylogger", 100);
            items[2] = new Item("netwerkscanner", 225);
            items[3] = new Item("worm", 300);
            items[4] = new Item("coderedvirus", 1000);
            items[5] = new Item("pizza", 25);

            this.shopitems.AddRange(items);
        }
        #endregion

        #region properties
        /// <summary>
        /// Gets the number of items in the shop.
        /// </summary>
        public int Numitems
        {
            get
            {
                return this.shopitems.Count; 
            }
        }
        #endregion

        #region methoden

        /// <summary>
        /// Voeg een item van de winkel aan je inventory toe.
        /// </summary>
        /// <param name="naam">item naam: kijk in lijst constructor inventory.</param>
        /// <returns>als gelukt geeft true terug.</returns>
        public bool AddItemInventory(string naam)
        {
            if (this.GetItemShop(naam) != null)
            {
                if (this.GetItemInventory(naam) == null)
                {
                    this.youritems.Add(this.GetItemShop(naam));
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Search for a item in the shop.
        /// </summary>
        /// <param name="naam">The name to search on.</param>
        /// <returns>The item where was searched for.</returns>
        public Item GetItemShop(string naam)
        {
            foreach (Item curitem in this.shopitems)
            {
                if (curitem.NaamItem == naam)
                {
                    return curitem;
                }
            }

            return null;
        }

        /// <summary>
        /// Search for a item in your inventory.
        /// </summary>
        /// <param name="naam">the name of the item to search for.</param>
        /// <returns>The item. Null if not found.</returns>
        public Item GetItemInventory(string naam)
        {
            foreach (Item curitem in this.youritems)
            {
                if (curitem.NaamItem == naam)
                {
                    return curitem;
                }
            }

            return null;
        }

        /// <summary>
        /// Search for a item by it's position in the shop list.
        /// </summary>
        /// <param name="positie">The position in the shop list.</param>
        /// <returns>The item where was searched for.</returns>
        public Item GetItemPos(int positie)
        {
            return this.shopitems[positie];
        }

        /// <summary>
        /// Voegt het item van vriend toe.
        /// </summary>
        public void AddBankaccountnrlist()
        {
            Item bankaccountlist = new Item("listbankaccounts", 0);
            this.youritems.Add(bankaccountlist);
        }

        /// <summary>
        /// Empties your inventory.
        /// </summary>
        public void ResetInventory()
        {
            this.youritems.Clear();
        }
        
        #endregion
    }
}
