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
            //nextRekeningNr = 1;
            accounts = new List<Bankaccount>();

            RegistreerAccount("speler", "999.999.999.999", 0, 200);
            RegistreerAccount("Jan de Vries", "34.89.57.74", 3, 500);
            RegistreerAccount("Marrieke", "23.45.56.81", 4, 360);
            RegistreerAccount("Pieter", "56.35.67.101", 4, 740);
            RegistreerAccount("Roel", "78.127.57.23", 5, 680);
        }
        #endregion

        #region properties
        public Int32 numaccount
        {
            get { return accounts.Count; }
        }

        #endregion

        #region methoden
        /// <summary>
        /// Registreer een account bij de bank, controlleer of die al in lijst voor komt
        /// </summary>
        /// <returns>true als gelukt is.</returns>
        public bool RegistreerAccount(String nm, String reknr, int lenpassw, int money)
        {
            try
            {
                Bankaccount bankaccount;
                bankaccount = new Bankaccount(nm, reknr, lenpassw, money);
                accounts.Add(bankaccount);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        /// <summary>
        /// Verkrijg de bankaccount aan de hand van een rekening nummer van de gevraagde bankaccount.
        /// </summary>
        /// <param name="reknr">rekeningnummer</param>
        /// <returns>de bank account</returns>
        public Bankaccount GetByRekening(String reknr)
        {
            foreach (Bankaccount bankaccount in accounts)
            {
                if (bankaccount.AccountRekeningnr == reknr) return bankaccount;
            }
            return null;
        }

        /// <summary>
        /// Verkrijg bankaccount van een bepaalde naam
        /// </summary>
        /// <param name="nm">naam bankaccount</param>
        /// <returns>de bank account</returns>
        public Bankaccount GetByNaam(String nm)
        {
            foreach (Bankaccount bankaccount in accounts)
            {
                if (bankaccount.AccountNaam == nm) return bankaccount;
            }
            return null;
        }

        /// <summary>
        /// Verkrijg account op positie in lijst.
        /// </summary>
        /// <param name="positie"></param>
        /// <returns></returns>
        public Bankaccount GetByPos(int positie)
        {
            return accounts[positie];
        }

        /// <summary>
        /// Maak al het geld over van een account naar de ander account
        /// </summary>
        /// <param name="ontvangeraccount"></param>
        /// <param name="geveraccount"></param>
        public bool AlHetGeldOvermaken(Bankaccount ontvangeraccount, Bankaccount geveraccount)
        {
            int geld = geveraccount.AccountSaldo;
            if (geveraccount.geldopnemen(geld)==true)
            {
                if (ontvangeraccount.geldstorten(geld) == true) { return true; }
                else { return false; }
            }
            else { return false; }
        }


        #endregion
    }
}