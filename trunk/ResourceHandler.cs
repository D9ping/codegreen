using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms; // hier zit soundplayer o.a. in.

namespace CodeGreen
{
    /// <summary>
    /// Deze class verzorgt het ophalen van embedded afbeeldingen/resources.
    /// </summary>
    public class ResourceHandler
    {
        #region datavelden
        Misc misc;
        OptionsHandler options;
        //SoundPlayer soundplayer;
        #endregion

        #region constructor
        public ResourceHandler()
        {
            misc = new Misc();
            options = new OptionsHandler();
            //soundplayer = new SoundPlayer();
        }
        #endregion

        #region properties
        #endregion

        #region methoden
        [DllImport("winmm.dll")]
        public static extern int sndPlaySound(string sFile, int sMode);

        /// <summary>
        /// Haalt de afbeelding uit de assembly van de compiled executable.        
        /// </summary>
        /// <param name="bestandsnaam">kijk in afb map voor de bestandsnaam</param>
        /// <returns>bitmap stream</returns>
        public Bitmap loadimage(string bestandsnaam)
        {
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("CodeGreen.afb." + bestandsnaam);
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
        /// Speelt een geluidje af.
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

                    //soundplayer.LoadAsync();
                    //String bestandlocatie = System.Windows.Forms.Application.StartupPath;
                    //soundplayer.SoundLocation = Path.Combine(bestandlocatie, Path.Combine("sounds", bestandsnaam));
                    //if (herhalen == true) 
                    //{
                    //    soundplayer.PlayLooping();
                    //}
                    //else if (herhalen == false)
                    //{
                    //    soundplayer.Play();
                    //}
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


