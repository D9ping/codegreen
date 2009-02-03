using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Media; // hier zit soundplayer o.a. in.

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
        SoundPlayer soundplayer;
        #endregion

        #region constructor
        public ResourceHandler()
        {
            misc = new Misc();
            options = new OptionsHandler();       
            soundplayer = new SoundPlayer();
        }
        #endregion

        #region properties
        #endregion

        #region methoden
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
        /// Speelt een geluid wav geluidje af d.m.v. soundplayer object.        
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
                    //FIXME: asynch. afspelen met achtergrondgeluid en effect geluid werkt niet.
                    soundplayer.LoadAsync(); 
                    soundplayer.SoundLocation = "sounds\\" + bestandsnaam;
                    if (herhalen == true) { soundplayer.PlayLooping(); }
                    soundplayer.Play();                    
                    return true;
                    
                }
                catch (Exception) { 
                    //failed to play
                    return false; }
            }            
            return true;
        }

        public void StopSound()
        {
            soundplayer.Stop();
        }
        #endregion

    }
}


