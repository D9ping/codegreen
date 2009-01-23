using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGreen
{
    class Inventory
    {
        #region datavelden
        private List<Item> allitems;
        public List<Item> youritems;
        
        #endregion

        #region constructor
        public Inventory()
        {             
            allitems = new List<Item>();            
            youritems = new List<Item>();            

            allitems.Add(new Item("wepcracker", 100));
            allitems.Add(new Item("keylogger", 100));            
            allitems.Add(new Item("netwerkscanner", 250));
            allitems.Add(new Item("worm", 250));
            allitems.Add(new Item("coderedvirus", 800));
            
            //allitems.Add(new Item("cookie", 999));
            //allitems.Add(new Item("pizza", 123));
            
        }
        #endregion

        #region properties
        public int numitems
        {
            get { return allitems.Count; }
        }
        #endregion

        #region methoden        
        public bool addItemInventory(String naam)
        {   
                                     
            Item buyitem = getItem(naam);

            //onbestaande items zijn altijd te duur om te kopen.
            if (buyitem == null) { return false; }
            
            //int prijs = buyitem.Prijs;
            //return false;

            youritems.Add(buyitem);
            return true;
        }

        public Item getItem(string naam)
        {
            foreach (Item curitem in allitems)
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
            return allitems[positie];
        }


        #endregion
    }
}
