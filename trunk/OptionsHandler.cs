using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using Microsoft.Win32; //Win32 bibliotheek nodig voor register handelingen.

namespace CodeGreen
{
    /// <summary>
    /// Saves and load settings.
    /// </summary>
    /// <remarks>gevaarlijke dingen</remarks>
    public class OptionsHandler
    {
        #region datavelden
        private RegistryKey regsleutel;
        private Misc misc;
        private bool settingSound;
        private bool settingController;
        private String vendorID = "03EB";
        private String productID = "2013";
        private bool switchXaxis = false;
        #endregion

        #region constructor
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
		     regsleutel = Registry.CurrentUser.OpenSubKey("Software\\CodeGreen", true);
             bool settingbool = Convert.ToBoolean(regsleutel.GetValue(keysetting));
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
