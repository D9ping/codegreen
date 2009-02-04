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
        private int saldo;
        #endregion

        #region constructor
        public Bankaccount(String nm, string rekeningnummer, int paswlength, int saldo)
        {
            this.naam = nm;
            this.rekeningnr = rekeningnummer;
            this.password = MakePassword(paswlength);
            this.saldo = saldo;
        }
        #endregion

        #region properties
        public String AccountPassword
        {
            get { return password; }
            set { password = value; }
        }
        public String AccountNaam
        {
            get { return naam; }
            set { naam = value; }
        }
        public String AccountRekeningnr
        {
            get { return rekeningnr; }
            set { rekeningnr = value; }
        }
        public int AccountSaldo
        {
            get { return saldo; }
            set { saldo = value; }
        }
        #endregion

        #region methoden
        private String MakePassword(int paswlength)
        {
            Random generator = new Random();

            for (int i = 0; i < paswlength; i++)
            {
                int rangetal = generator.Next(0, 10);
                password += Convert.ToString(rangetal); // 0 Tot 9 (niet 10, wel 0)                
            }
            return password;
        }

        /// <summary>
        /// Neem geld op van deze account.
        /// </summary>
        /// <param name="bedrag">hoeveel er van de rekening moet.</param>
        /// <returns>true als gelukt</returns>
        public bool geldopnemen(int bedrag)
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
        /// Geld op een account toevoegen en controlleren of bedrag positief is.
        /// </summary>
        /// <param name="bedrag"></param>
        /// <returns></returns>
        public bool geldstorten(int bedrag)
        {
            if (bedrag>0)
            {
                this.saldo = this.saldo + bedrag;
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
