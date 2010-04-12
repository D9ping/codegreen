//-----------------------------------------------------------------------
// <copyright file="Bankaccount.cs" company="GNU">
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
    /// Deze class handel zaken af van een account van de bank.
    /// </summary>
    public class Bankaccount
    {
        #region datavelden
        /// <summary>
        /// name, password and accountnumber of account.
        /// </summary>
        private string naam, password, rekeningnr;

        /// <summary>
        /// The saldo of the account
        /// </summary>
        private int saldo;
        #endregion

        #region constructor
        /// <summary>
        /// Initializes a new instance of the Bankaccount class.
        /// </summary>
        /// <param name="nm">the name of the account.</param>
        /// <param name="rekeningnummer">rekening number</param>
        /// <param name="paswlength">new password length</param>
        /// <param name="saldo">the saldo of the account</param>
        public Bankaccount(string nm, string rekeningnummer, int paswlength, int saldo)
        {
            this.naam = nm;
            this.rekeningnr = rekeningnummer;
            this.password = this.MakePassword(paswlength);
            this.saldo = saldo;
        }
        #endregion

        #region properties

        /// <summary>
        /// Gets or sets the name of the account
        /// </summary>
        public string AccountNaam
        {
            get { return this.naam; }
            set { this.naam = value; }
        }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        public string AccountRekeningnr
        {
            get { return this.rekeningnr; }
            set { this.rekeningnr = value; }
        }

        /// <summary>
        /// Gets or sets password of the account.
        /// </summary>
        public string AccountPassword
        {
            get { return this.password; }
            set { this.password = value; }
        }

        /// <summary>
        /// Gets or sets the saldo on account.
        /// </summary>
        public int AccountSaldo
        {
            get { return this.saldo; }
            set { this.saldo = value; }
        }
        #endregion

        #region methoden

        /// <summary>
        /// Neem geld op van deze account.
        /// </summary>
        /// <param name="bedrag">hoeveel er van de rekening moet.</param>
        /// <returns>true als gelukt</returns>
        public bool GeldOpnemen(int bedrag)
        {
            if (this.saldo >= bedrag)
            {
                this.saldo = this.saldo - bedrag;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Add money on the account.
        /// </summary>
        /// <param name="bedrag">Saldo of the account.</param>
        /// <returns>True if saldo is positive.</returns>
        public bool GeldStorten(int bedrag)
        {
            if (bedrag > 0)
            {
                this.saldo = this.saldo + bedrag;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Create a new password.
        /// </summary>
        /// <param name="paswlength">Set new password length</param>
        /// <returns>The new password.</returns>
        private string MakePassword(int paswlength)
        {
            Random generator = new Random();
            for (int i = 0; i < paswlength; i++)
            {
                int rangetal = generator.Next(0, 10);
                this.password += Convert.ToString(rangetal);
            }

            return this.password;
        }
        #endregion
    }
}
