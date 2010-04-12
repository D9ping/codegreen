//-----------------------------------------------------------------------
// <copyright file="Bank.cs" company="GNU">
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
    using System.Text;

    /// <summary>
    /// Bank class
    /// </summary>
    public class Bank
    {
        #region datavelden
        /// <summary>
        /// A list with account of the bank.
        /// </summary>
        private List<Bankaccount> accounts;
        #endregion

        #region constructor
        /// <summary>
        /// Initializes a new instance of the Bank class.
        /// </summary>
        public Bank()
        {
            this.accounts = new List<Bankaccount>();

            this.RegistreerAccount("speler", "999.999.999.999", 0, 200);
            this.RegistreerAccount("Jan de Vries", this.RanBankAccnum() + ".89.57.74", 3, 500);
            this.RegistreerAccount("Marrieke", this.RanBankAccnum() + ".45.56.81", 4, 360);
            this.RegistreerAccount("Pieter", this.RanBankAccnum() + ".35.67.101", 5, 740);
            this.RegistreerAccount("Roel", this.RanBankAccnum() + ".127.57.23", 6, 680);
        }
        #endregion

        #region properties
        /// <summary>
        /// Gets the number of bankaccounts.
        /// </summary>
        public int Numaccount
        {
            get { return this.accounts.Count; }
        }

        #endregion

        #region methoden
        /// <summary>
        /// Register a account by the bank.
        /// </summary>
        /// <param name="nm">The name of the account.</param>
        /// <param name="reknr">Rekening number</param>
        /// <param name="lenpassw">Lengte password</param>
        /// <param name="money">How many geld</param>
        /// <returns>True als gelukt is.</returns>
        public bool RegistreerAccount(string nm, string reknr, int lenpassw, int money)
        {
            try
            {
                Bankaccount bankaccount;
                bankaccount = new Bankaccount(nm, reknr, lenpassw, money);
                this.accounts.Add(bankaccount);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the Bankaccount by bankaccount number.
        /// </summary>
        /// <param name="reknr">the accountnumber</param>
        /// <returns>de bank account</returns>
        public Bankaccount GetByRekening(string reknr)
        {
            foreach (Bankaccount bankaccount in this.accounts)
            {
                if (bankaccount.AccountRekeningnr == reknr)
                {
                    return bankaccount;
                }
            }

            return null;
        }

        /// <summary>
        /// Get bankaccount by a name.
        /// </summary>
        /// <param name="nm">name bank account</param>
        /// <returns>The bank account object.</returns>
        public Bankaccount GetByName(string nm)
        {
            foreach (Bankaccount bankaccount in this.accounts)
            {
                if (bankaccount.AccountNaam == nm)
                {
                    return bankaccount;
                }
            }

            return null;
        }

        /// <summary>
        /// Get a bankaccount from the position in the list.
        /// </summary>
        /// <param name="positie">Get account from position number.</param>
        /// <returns>The Bankaccount object.</returns>
        public Bankaccount GetByPos(int positie)
        {
            return this.accounts[positie];
        }

        /// <summary>
        /// Transfer all the money from one account to an other account.
        /// </summary>
        /// <param name="accountto">The account that get the money</param>
        /// <param name="accountfrom">The account where the money get away from.</param>
        /// <returns>True if succeed.</returns>
        public bool AlHetGeldOvermaken(Bankaccount accountto, Bankaccount accountfrom)
        {
            int geld = accountfrom.AccountSaldo;
            if (accountfrom.GeldOpnemen(geld) == true)
            {
                if (accountto.GeldStorten(geld) == true) 
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            else
            {
                return false; 
            }
        }

        /// <summary>
        /// Random bank account number.
        /// </summary>
        /// <returns>The new bank account number.</returns>
        public string RanBankAccnum()
        {
            Random ran = new Random();
            int getal = ran.Next(1, 256);
            return getal.ToString();
        }

        #endregion
    }
}