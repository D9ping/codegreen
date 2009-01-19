using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGreen
{
    class Huis
    {
        #region datavelden
        String bewonernaam;
        String bankaccountnaam;
        String ipadres;        
        bool wifi;
        String wifissid;
        bool wifiwep;
        bool wifiwpa;
        bool windowsoutdated;
        bool virusscanner;
        bool bot;     
        #endregion

        #region constructor
        public Huis(String bewonernaam, String bankaccountnaam, String ipadres, bool wifi, String wifissid, bool wifiwep, bool wifiwpa,   
            bool windowsoutdated, bool virusscanner, bool bot)
        {
            this.bewonernaam = bewonernaam;
            this.bankaccountnaam = bankaccountnaam;
            this.ipadres = ipadres;

            this.wifi = wifi;
            this.wifissid = wifissid;            
            this.wifiwep = wifiwep;
            this.wifiwpa = wifiwpa;

            this.windowsoutdated = windowsoutdated;
            this.virusscanner = virusscanner;            
        }
        #endregion

        #region properties
        public String Bewonernaam
        {
            get { return bewonernaam; }
        }
        public String BankAccountnaam
        {
            get { return bankaccountnaam; }
        }
        public String IPAdres
        {
            get { return ipadres; }
        }
        public bool Wifi
        {
            get { return wifi; }
        }
        public String WifiSSID
        {
            get { return wifissid; }
        }
        public bool WifiWEP
        {
            get { return wifiwep; }
        }
        public bool WifiWPA
        {
            get { return wifiwpa; }
        }
        public bool WindowsOutdated
        {
            get { return WindowsOutdated; }
        }
        public bool Virusscanner
        {
            get { return virusscanner; }
        }
        public bool IsBot
        {
            get { return this.bot; }
            set { bot = value; }
        }
        #endregion

        #region methoden

        #endregion
    }
}
