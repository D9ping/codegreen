using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGreen
{
    class Bank
    {
        #region datavelden
        private List<Bankaccount> accounts;        
        #endregion

        #region constructor
        public Bank()
        {
            accounts = new List<Bankaccount>();
        }
        #endregion

        #region properties
        //n.v.t.
        #endregion

        #region methoden
        /// <summary>
        /// Registreer een account bij de bank, controlleer of die al in lijst voor komt
        /// </summary>
        /// <returns>true als gelukt is.</returns>
        public bool RegistreerAccount()
        {


            return true;
        }


        #endregion
    }
}
