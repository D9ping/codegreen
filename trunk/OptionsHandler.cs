using System;
using System.Collections.Generic;
using System.Linq;
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
        private bool setting_sound;
        private bool setting_controller;
        #endregion

        #region constructor
        public OptionsHandler()
        {
            misc = new Misc();

            try
            {
                if (GetSettingBool("Sound") == true) { setting_sound = true; }
                else if (GetSettingBool("Sound") == false) { setting_sound = false; }

                if (GetSettingBool("Controller") == true) { setting_controller = true; }
                else if (GetSettingBool("Controller") == false) { setting_controller = false; }
            }
            catch (Exception)
            {
                misc.ToonBericht(3);                
            }

        }
        #endregion

        #region properties
        public bool sound_enabled
        {
            get { return this.setting_sound; }
            //set { setting_sound = value; }
        }
        public bool controller_enabled
        {
            get { return this.setting_controller; }
            //set { setting_controller = value; }
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
                        this.setting_sound = status;
                        break;
                    case "Controller":
                        this.setting_controller = status;
                        break;
                    
                    default:
                        break;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }        
        #endregion

    }
}
