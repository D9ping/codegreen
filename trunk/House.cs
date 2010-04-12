//-----------------------------------------------------------------------
// <copyright file="House.cs" company="GNU">
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
    /// House class.
    /// </summary>
    public class House
    {
        #region datavelden
        /// <summary>
        /// object name
        /// </summary>
        private object huisnaam;

        /// <summary>
        /// people who live here
        /// </summary>
        private string naam;

        /// <summary>
        /// Ip adress and wifi ssid
        /// </summary>
        private string ipadres, wifissid;
        
        /// <summary>
        /// Diffent setting of this house.
        /// </summary>
        private bool wifi, wifiwep, wifiwpa, wepcracked, windowsoutdated, keylogger, bot;
        #endregion

        #region constructor
        /// <summary>
        /// Initializes a new instance of the House class.
        /// </summary>
        /// <param name="huisnaam">The name of the object in gamescreen</param>
        /// <param name="naam">The name of the people living in this house which is also the name of the bankaccount.</param>
        /// <param name="ipadres">The ip adres the people in this house have.</param>
        /// <param name="wifi">this house got wifi?</param>
        /// <param name="wifissid">The ssid of the wifi.</param>
        /// <param name="wifiwep">has wep wifi encryption.</param>
        /// <param name="wifiwpa">has wpa wifi encryption.</param>
        /// <param name="windowsoutdated">windows is outdated</param>
        public House(object huisnaam, string naam, string ipadres, bool wifi, string wifissid, bool wifiwep, bool wifiwpa, bool windowsoutdated)
        {
            this.huisnaam = huisnaam;
            this.naam = naam;
            this.ipadres = ipadres;

            this.wifi = wifi;
            if (wifi == false)
            {
                this.wifissid = String.Empty;
                this.wifiwep = false;
                this.wifiwpa = false;
            }
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
        /// <summary>
        /// Gets the name of the object.
        /// </summary>
        public object Huisobj
        {
            get
            {
                return this.huisnaam;
            }
        }

        /// <summary>
        /// Gets the name of the people who live here.
        /// </summary>
        public string Naam
        {
            get 
            {
                return this.naam;
            }
        }

        /// <summary>
        /// Gets the ip adress the people in this house are using.
        /// </summary>
        public string IPAdres
        {
            get
            {
                return this.ipadres;
            }
        }

        /// <summary>
        /// Gets a value indicating whether wifi is enabled.
        /// </summary>
        public bool Wifi
        {
            get 
            {
                return this.wifi;
            }
        }

        /// <summary>
        /// Gets the wifi ssid.
        /// </summary>
        public string WifiSSID
        {
            get
            {
                return this.wifissid;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this house uses wep encryption for wifi.
        /// </summary>
        public bool WifiWEP
        {
            get
            {
                return this.wifiwep;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this house use wpa encryption for wifi.
        /// </summary>
        public bool WifiWPA
        {
            get
            {
                return this.wifiwpa;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the OS of the pc in this house is updated with the latest patchs.
        /// </summary>
        public bool WindowsOutdated
        {
            get
            {
                return this.windowsoutdated;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the wep wifi key is cracked.
        /// </summary>
        public bool Wepcracked
        {
            get
            {
                return this.wepcracked;
            }

            set
            {
                this.wepcracked = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether a keylogger is running on the pc in this house.
        /// </summary>
        public bool KeyloggerInstalled
        {
            get 
            {
                return this.keylogger;
            }

            set 
            {
                this.keylogger = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the bot is installed on the pc in this house.
        /// </summary>
        public bool IsBot
        {
            get
            {
                return this.bot;
            }

            set
            {
                this.bot = value;
            }
        }
        #endregion

        #region methoden
        #endregion
    }
}
