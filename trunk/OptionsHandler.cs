//-----------------------------------------------------------------------
// <copyright file="OptionsHandler.cs" company="GNU">
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
    using Microsoft.Win32; //Win32 bibliotheek nodig voor register.

    /// <summary>
    /// Saves and load settings.
    /// 
    /// Class will be decrepit.
    /// </summary>
    /// <remarks>gevaarlijke dingen</remarks>
    public class OptionsHandler
    {
        #region datavelden
        private Misc misc;
        private bool settingSound = false, settingController = false, switchXaxis = false;
        private String vendorID = "03EB", productID = "2013";
        #endregion

        #region constructor
        /// <summary>
        /// Init new instance of ...
        /// </summary>
        public OptionsHandler()
        {
            misc = new Misc();
            
            if (GetSettingBool("Sound") == true) { settingSound = true; }
            else if (GetSettingBool("Sound") == false) { settingSound = false; }

            if (GetSettingBool("Controller") == true) { settingController = true; }
            else if (GetSettingBool("Controller") == false) { settingController = false; }

        }
        #endregion

        #region properties
        public bool sound_enabled
        {
            get { return this.settingSound; }
            //set { setting_sound = value; }
        }
        public bool controller_enabled
        {
            get { return this.settingController; }
            //set { setting_controller = value; }
        }
        public String VendorID
        {
            get { return this.vendorID; }
            set { vendorID = value; }
        }
        public String ProductID
        {
            get { return this.productID; }
            set { productID = value; }
        }
        public bool SwitchXaxis
        {
            get { return this.switchXaxis; }
            set { this.switchXaxis = value; }
        }
        #endregion

        #region methoden
        /// <summary>
        /// Verkrijg register waarde 
        /// </summary>
        /// <param name="regwaarde">de settings van de sleutel</param>
        /// <returns>Geeft true terug als ophalen gelukt is.</returns>
        public bool GetSettingBool(String keysetting)
        {                
		     //regsleutel = Registry.CurrentUser.OpenSubKey("Software\\CodeGreen", true);
             //bool settingbool = Convert.ToBoolean(regsleutel.GetValue(keysetting));
            bool settingbool = false; 
            return settingbool;	                
        }

        /// <summary>
        /// Verander de sound register sleutel, 
        /// DWORD 0000000 voor false en 0000001 voor true.
        /// </summary>
        /// <param name="status">de waarde true of false.</param>
        /// <returns>geeft true terug als het gelukt is.</returns>
        public bool UpdateSetting(String keysetting, bool status)
        {
            try
            {
                RegistryKey regsleutel = Registry.CurrentUser.OpenSubKey("Software\\CodeGreen", true);
                regsleutel.SetValue(keysetting, status);
                switch (keysetting)
                {
                    case "Sound":
                        this.settingSound = status;
                        break;
                    case "Controller":
                        this.settingController = status;
                        break;
                    
                    default:
                        break;
                }
                return true;
            }
            catch (Exception exc)
            {
                misc.ToonError(exc);
                return false;
            }
        }        
        #endregion

    }
}
