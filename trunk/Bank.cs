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
        private int nextRekeningNr;
        
        #endregion

        #region constructor
        public Bank()
        {
            nextRekeningNr = 1;
            accounts = new List<Bankaccount>();
        }
        #endregion

        #region properties
        //n.v.t.
        public String Nr
        {
            get { return Convert.ToString(nextRekeningNr); }
        }

        #endregion

        #region methoden
        /// <summary>
        /// Registreer een account bij de bank, controlleer of die al in lijst voor komt
        /// </summary>
        /// <returns>true als gelukt is.</returns>
        public bool RegistreerAccount(String nm, String reknr, int lenpassw, double money)
        {
            Bankaccount bankaccount;
            bankaccount = new Bankaccount(nm, reknr, lenpassw, money);            
            accounts.Add(bankaccount);
            return true;
        }
        public void initbankaccounts()
        {
            RegistreerAccount("speler", "123.345.567.89", 0, 100);
            RegistreerAccount("naam1", "123.345.567.89", 3, 200);
            RegistreerAccount("naam2", "123.345.567.89", 5, 500);
            RegistreerAccount("naam3", "123.345.567.89", 8, 1000);
            RegistreerAccount("naam4", "123.345.567.89", 8, 2000);
        }

        public Bankaccount GetByRekening(String reknr)
        {
            foreach (Bankaccount bankaccount in accounts)
            {
                if (bankaccount.AccountRekeningnr == reknr) return bankaccount;
            }
            return null;
        }
        public Bankaccount GetByName(String nm)
        {
            foreach (Bankaccount bankaccount in accounts)
            {
                if (bankaccount.AccountNaam == nm) return bankaccount;
            }
            return null;
        }


        #endregion
    }
}