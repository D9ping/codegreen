using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace CodeGreen
{
    class Huis
    {
        #region datavelden
        object huisnaam;
        String naam;
        String ipadres;        
        bool wifi;
        String wifissid;
        bool wifiwep;
        bool wifiwpa;
        bool windowsoutdated;
        bool wepcracked;
        bool keylogger;
        bool bot;        
        #endregion

        #region constructor
        /// <summary>
        /// Huis met zijn eigenschappen/zwakheden.
        /// </summary>
        /// <param name="huisnaam">ook de naam van het object in gamescreen</param>
        /// <param name="naam">de naam van de bewoner en rekening</param>
        /// <param name="ipadres"></param>
        /// <param name="wifi">wel of geen wifi (als niet dan WEP, WPA zijn false enn SSID niks)</param>
        /// <param name="wifissid"></param>
        /// <param name="wifiwep"></param>
        /// <param name="wifiwpa"></param>
        /// <param name="windowsoutdated"></param>
        /// <param name="virusscanner"></param>
        /// <param name="bot"></param>
        public Huis(object huisnaam, String naam, String ipadres, bool wifi, String wifissid, bool wifiwep, bool wifiwpa,   
            bool windowsoutdated)
        {
            this.huisnaam = huisnaam;
            this.naam = naam;
            this.ipadres = ipadres;

            this.wifi = wifi;
            if (wifi == false) { this.wifissid = ""; this.wifiwep = false; this.wifiwpa = false; }
            else
            {
                this.wifissid = wifissid;
                this.wifiwep = wifiwep;
                this.wifiwpa = wifiwpa;
            }
            this.wepcracked = false;
            this.keylogger = false;
            this.bot = false;
            this.windowsoutdated = windowsoutdated;
        }
        #endregion

        #region properties
        //huisnaam is hetzelfde als het object naam om het te vinden.
        public object Huisobj
        {
            get { return huisnaam; }
        }
        //naam is het zelfde bij de bank account
        public String Naam
        {
            get { return naam; }
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
            get { return this.windowsoutdated; }
        }
        public bool Wepcracked
        {
            get { return wepcracked; }
            set { this.wepcracked = value; }
        }
        public bool KeyloggerInstalled
        {
            get { return this.keylogger; }
            set { this.keylogger = value; }
        }
        public bool IsBot
        {
            get { return this.bot; }
            set { this.bot = value; }
        }
        #endregion

        #region methoden
        #endregion
    }
}
