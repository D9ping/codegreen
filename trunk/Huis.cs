using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGreen
{
    class Huis
    {
        #region datavelden
        String huisnaam;
        String naam;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="huisnaam">ook de naam van het object in gamescreen</param>
        /// <param name="naam">de naam van de bewoner en rekening</param>
        /// <param name="ipadres"></param>
        /// <param name="wifi"></param>
        /// <param name="wifissid"></param>
        /// <param name="wifiwep"></param>
        /// <param name="wifiwpa"></param>
        /// <param name="windowsoutdated"></param>
        /// <param name="virusscanner"></param>
        /// <param name="bot"></param>
        public Huis(String huisnaam, String naam, String ipadres, bool wifi, String wifissid, bool wifiwep, bool wifiwpa,   
            bool windowsoutdated, bool virusscanner, bool bot)
        {
            this.huisnaam = huisnaam;
            this.naam = naam;
            this.ipadres = ipadres;

            this.wifi = wifi;
            if (wifi == false) { this.wifissid = ""; this.wifiwep = false; this.wifiwpa = false; }
            this.wifissid = wifissid;
            this.wifiwep = wifiwep;
            this.wifiwpa = wifiwpa;

            this.windowsoutdated = windowsoutdated;
            this.virusscanner = virusscanner;            
        }
        #endregion

        #region properties
        //huisnaam is hetzelfde als het object naam om het te vinden.
        public String Huisnaam
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
