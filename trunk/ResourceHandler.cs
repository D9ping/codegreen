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
    class ResourceHandler
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

        public bool playsound(String bestandsnaam)
        {
            try
            {
                System.Media.SoundPlayer myPlayer = new System.Media.SoundPlayer();
                myPlayer.SoundLocation = "..\\..\\sounds\\"+bestandsnaam;
                myPlayer.Play();
                return true;
            }
            catch (Exception)
            {
                //misc.ToonBericht(5);
                return false;
            }            

        }
        #endregion

    }
}
