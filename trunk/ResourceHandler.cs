//-----------------------------------------------------------------------
// <copyright file="ResourceHandler.cs" company="GNU">
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
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms; // hier zit soundplayer o.a. in.

    /// <summary>
    /// Deze class verzorgt het ophalen van embedded afbeeldingen/resources.
    /// 
    /// Class will be decrepit.
    /// </summary>
    public class ResourceHandler
    {
        #region datavelden
        OptionsHandler options;
        #endregion

        #region constructor
        public ResourceHandler()
        {
            options = new OptionsHandler();
        }
        #endregion

        #region properties
        #endregion

        #region methoden
        [DllImport("winmm.dll")]
        public static extern int sndPlaySound(string sFile, int sMode);

        /// <summary>
        /// Play a sound. (external not compiled)
        /// </summary>
        /// <param name="bestandsnaam">de bestandsnaam in de sound map</param>
        /// <param name="herhalen">laat het geluidje herhalen</param>
        /// <returns>true als afspelen lukt</returns>
        public bool PlaySound(String bestandsnaam, bool herhalen)
        {
            if (options.sound_enabled == true)
            {
                try
                {
                    string sounddir = Application.StartupPath + "\\sounds\\";
                    if (Directory.Exists(sounddir))
                    {
                        string soundfile = Path.Combine(sounddir, bestandsnaam);
                        if (File.Exists(soundfile))
                        {
                            sndPlaySound(soundfile, 1); //1 = Async
                        }
                    }
                    return true;
                }
                catch (Exception)
                { 
                    //failed to play
                    return false;
                }
            }
            return true;
        }
        #endregion

    }
}


