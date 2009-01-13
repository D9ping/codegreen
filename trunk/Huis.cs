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
        Bankaccount bankaccount;
        bool wifi;
        bool wifisecure;
        String IPadres;
        bool windowsoutdated;
        bool virusscanner;
        string ssid;
        bool microsoftserver;
        #endregion

        #region constructor
        public Huis(String bewonernaam, Bankaccount bankaccount, bool wifi, bool wifisecure, String IPadres, 
            bool windowsoutdated, bool virusscanner, string ssid, bool microsoftserver )
        {
            this.bewonernaam = bewonernaam;
            this.bankaccount = bankaccount;
            this.wifi = wifi;
            this.wifisecure = wifisecure;
            this.IPadres = IPadres;
            this.windowsoutdated = windowsoutdated;
            this.virusscanner = virusscanner;
            this.ssid = ssid;
            this.adsl = adsl;
            this.microsoftserver = microsoftserver;
        }
        #endregion

        #region properties
        public String Bewonernaam
        {
            get { return bewonernaam; }
        }
        public Bankaccount BankAccount
        {
            get { return bankaccount; }
        }
        public bool Wifi
        {
            get { return wifi; }
        }
        public bool Wifisecure
        {
            get { return wifisecure; }
        }
        public string IPADRES
        {
            get { return IPadres; }
        }
        public bool WindowsOutdated
        {
            get { return WindowsOutdated; }
        }
        public bool Virusscanner
        {
            get { return virusscanner; }
        }
        public string Ssid
        {
            get { return ssid; }
        }
        public bool MicrosoftServer
        {
            get { return microsoftserver; }
        }
        #endregion

        #region methoden
        #endregion
    }
}
