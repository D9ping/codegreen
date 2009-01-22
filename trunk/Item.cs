using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGreen
{
    class Item
    {
        #region datavelden
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
