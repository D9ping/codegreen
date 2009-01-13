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
        public bool RegistreerAccount(String nm, String reknr, int password, double money)
        {
            Bankaccount bankaccount;
            bankaccount = new Bankaccount(nm,reknr,password,money);
            bankaccount.AccountNaam = nm;
            bankaccount.AccountRekeningnr = reknr;
            bankaccount.AccountPassword = Convert.ToString(password);
            bankaccount.AccountSaldo = money;
            accounts.Add(bankaccount);
            return true;
        }
        public Bankaccount GetRekening(String nr)
        {
            foreach (Bankaccount bankaccount in accounts)
            {
                if (bankaccount.AccountRekeningnr == nr) return bankaccount;
            }
            return null;

        #endregion
        }
    }
}