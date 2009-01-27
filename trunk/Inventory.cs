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
        
        #endregion

        #region constructor
        public Inventory()
        {             
            shopitems = new List<Item>();            
            youritems = new List<Item>();            

            shopitems.Add(new Item("wepcracker", 100));
            shopitems.Add(new Item("keylogger", 100));            
            shopitems.Add(new Item("netwerkscanner", 250));
            shopitems.Add(new Item("worm", 250));
            shopitems.Add(new Item("coderedvirus", 800));
            
            //shopitems.Add(new Item("metal detector", 50));
            //shopitems.Add(new Item("cookie", 999));
            //shopitems.Add(new Item("pizza", 123));            
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
                youritems.Add(getItemShop(naam));
                return true;
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
