using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Drawing;

namespace CodeGreen
{
    /// <summary>
    /// Deze class verzorgt het ophalen van embedded afbeeldingen/resources.
    /// </summary>
    public class ResourceHandler
    {
        #region datavelden
        Assembly myAssembly;
        Misc misc;
        #endregion

        #region constructor
        public ResourceHandler()
        {
            misc = new Misc();
        }
        #endregion

        #region properties
        #endregion

        #region methoden
        public Bitmap loadimage(string bestandsnaam)
        {
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("CodeGreen.afb."+bestandsnaam);
            try
            {
                Bitmap bpm = new Bitmap(myStream);
                return bpm;
            }
            catch
            {
                misc.ToonBericht(4);
                return null;
            }
        }

        /// <summary>
        /// Speelt een geluid wav geluid af d.m.v. soundplayer object.        
        /// </summary>
        /// <param name="bestandsnaam">de bestandsnaam in de sound map</param>
        /// <param name="herhalen">laat het geluidje herhalen</param>
        /// <returns>true als afspelen lukt</returns>
        public bool playsound(String bestandsnaam, bool herhalen)
        {
            try
            {
                System.Media.SoundPlayer myPlayer = new System.Media.SoundPlayer();
                myPlayer.SoundLocation = "..\\..\\sounds\\"+bestandsnaam;
                if (herhalen == true) { myPlayer.PlayLooping(); }
                myPlayer.Play();
                return true;
            }
            catch (Exception) { return false; }  
        }


        #endregion

    }
}
