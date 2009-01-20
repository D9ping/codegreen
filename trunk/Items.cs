using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGreen
{
    class Items
    {
        #region datavelden
        String naamitem;
        /*
        bool wepcracker;
        bool keylogger;
        bool netwerkscanner;
        bool coderedvirus;
        bool trojanhorse;
        bool worm;
         */
        #endregion

        #region constructor
        public Items(String naamitem)            
            //(bool webcracker, bool keylogger, bool netwerkscanner, bool coderedvirus, bool trojanhorse, bool worm)
        {
        /*
            this.wepcracker = wepcracker;
            this.keylogger = keylogger;
            this.netwerkscanner = netwerkscanner;
            this.coderedvirus = coderedvirus;
            this.trojanhorse = trojanhorse;
            this.worm = worm;
        */
        }
        #endregion

        #region properties
        public bool Wepcracker
        {
            get { return wepcracker; }
        }
        public bool Keylogger
        {
            get { return keylogger; }
        }
        public bool Netwerkscanner
        {
            get { return netwerkscanner; }
        }
        public bool Coderedvirus
        {
            get { return coderedvirus; }
        }
        public bool Trojanhorse
        {
            get { return trojanhorse; }
        }
        public bool Worm
        {
            get { return worm; }
        }
        #endregion

        #region methoden
        #endregion
    }
}
