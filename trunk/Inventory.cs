using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGreen
{
    class Inventory
    {
        #region datavelden
        private List<Item> shopitems;
        public List<Item> youritems;
        //private void int[] i;
        #endregion

        #region constructor
        public Inventory()
        {             
            shopitems = new List<Item>();            
            youritems = new List<Item>();            

            Item[] items = new Item[5];
            items[0] = new Item("wepcracker", 75);
            items[1] = new Item("keylogger", 100);
            items[2] = new Item("netwerkscanner", 200);
            items[3] = new Item("worm", 300);
            items[4] = new Item("coderedvirus", 1000);
            //items[5] = new Item("pizza", 25);

            shopitems.AddRange(items);
        }
        #endregion

        #region properties
        public int numitems
        {
            get { return shopitems.Count; }
        }
        #endregion

        #region methoden
        /// <summary>
        /// Voeg een item van de winkel aan je inventory toe.
        /// </summary>
        /// <param name="naam">item naam: kijk in lijst constructor inventory.</param>
        /// <returns>als gelukt geeft true terug.</returns>
        public bool addItemInventory(String naam)
        {
            if (getItemShop(naam) != null)
            {
                if (getItemInventory(naam) == null)
                {
                    youritems.Add(getItemShop(naam));
                    return true;
                }
                else { return false; }
            }
            else
            { return false; }
        }

        public Item getItemShop(string naam)
        {
            foreach (Item curitem in shopitems)
            {
                if (curitem.NaamItem == naam)
                {
                    return curitem;
                }
            }
            return null;
        }

        public Item getItemInventory(string naam)
        {
            foreach (Item curitem in youritems)
            {
                if (curitem.NaamItem == naam)
                {
                    return curitem;
                }
            }
            return null;
        }

        public Item getItemPos(int positie)
        {
            return shopitems[positie];
        }

        /// <summary>
        /// Voegt het item van vriend toe.
        /// </summary>
        public void addBankaccountnrlist()
        {
            Item Bankaccountlist = new Item("listbankaccounts", 0);
            youritems.Add(Bankaccountlist);
        }        
        
        #endregion
    }
}
