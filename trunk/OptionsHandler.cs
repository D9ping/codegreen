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
        private bool soundsetting;
        private bool controllersetting;
        #endregion

        #region constructor
        public OptionsHandler()
        {
            if (GetSetting("Sound") == true && GetSetting("Controller") == true)
            {
                soundsetting = GetSetting("Sound");
                controllersetting = GetSetting("Controller");
            }
        }
        #endregion

        #region properties
        public bool sound_enabled
        {
            get { return this.soundsetting; }            
        }
        public bool controller_enabled
        {
            get { return this.soundsetting; }
        }
        #endregion

        #region methoden
        /// <summary>
        /// Verkrijg register waarde 
        /// </summary>
        /// <param name="regwaarde">de settings van de sleutel</param>
        /// <returns>Geeft true terug als ophalen gelukt is.</returns>
        public bool GetSetting(String keysetting)
        {
            try 
	        {	        
		        regsleutel = Registry.CurrentUser.OpenSubKey("Software\\CodeGreen");
                soundsetting = (bool)regsleutel.GetValue(keysetting);
                return true;
	        }
	        catch (Exception)
	        {
		        return false;		
	        }            
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
