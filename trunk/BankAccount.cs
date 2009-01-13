using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGreen
{
    /// <summary>
    /// Deze class handel zaken af van een account van de bank.
    /// </summary>
    class Bankaccount
    {
        #region datavelden
        private String naam;
        private String password;
        private String rekeningnr;
        private double saldo;
        #endregion

        #region constructor
        public Bankaccount(String naam, string rekeningnummer, int paswlength, double saldo)
        {
            this.naam = naam;
            this.rekeningnr = rekeningnummer;
            this.password = MakePassword(paswlength);
            this.saldo = saldo;
        }
        #endregion

        #region properties
        public String AccountPassword
        {           
            get { return password; }
        }
        public String AccountNaam
        {
            get { return naam; }
        }
        public String AccountRekeningnr
        {
            get { return rekeningnr; }
            set { rekeningnr = value; }
        }        
        #endregion

        #region methoden
        private String MakePassword(int paswlength)
        {
            Random generator = new Random();

            for (int i = 0; i < paswlength; i++)
            {
                password += Convert.ToString(generator.Next(0, 10)); // 0 Tot 9 (niet 10, wel 0)
            }
            return password;
        }

        /// <summary>
        /// Neem geld op van deze account.
        /// </summary>
        /// <param name="bedrag">hoeveel er van de rekening moet.</param>
        /// <returns>true als gelukt</returns>
        public bool geldopnemen(double bedrag)
        {
            if (this.saldo >= bedrag)
            {
                this.saldo = this.saldo - bedrag;
                return true;
            }
            else
            { return false;
            }           
        }
        #endregion
    }
}
