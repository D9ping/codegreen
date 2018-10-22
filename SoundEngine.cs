namespace CodeGreen
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Media;

    /// <summary>
    /// The sound engine class uses directX DirectSound to able to play sound Simultaneously.
    /// </summary>
    public class SoundEngine
    {
        private SoundPlayer musicplayer;
        private Misc misc;
        /// <summary>
        /// Initializes a new instance of SoundEngine class.
        /// </summary>
        public SoundEngine()
        {
            misc = new Misc();
        }

        /// <summary>
        /// Plays a background music.(can only be 1 music file at once)
        /// </summary>
        /// <param name="bestandsnaam">the filename</param>
        /// <param name="loop">true if it has to loop</param>
        /// <returns>true if succeed to play.</returns>
        public bool PlayMusic(String bestandsnaam, bool loop)
        {
            try
            {
                string sounddir = Application.StartupPath + "\\sounds\\";
                if (Directory.Exists(sounddir))
                {
                    string soundfile = Path.Combine(sounddir, bestandsnaam);
                    if (File.Exists(soundfile))
                    {
                        musicplayer = new SoundPlayer(soundfile);
                        if (loop)
                        {
                            musicplayer.PlayLooping();
                        }
                        else
                        {
                            musicplayer.Play();
                        }
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Stops the music.
        /// </summary>
        public void StopMusic()
        {
            if (musicplayer != null)
            {
                musicplayer.Stop();
            }
        }

        /// <summary>
        /// Play a (small) sound  file, by calling a process.
        /// This sound file will not abort the music.
        /// </summary>
        /// <returns>true is succeed.</returns>
        public bool PlaySoundEffect(string soundfile)
        {
            string appdir = Application.StartupPath;
            if (Directory.Exists(appdir))
            {
                string soundfilepath = Path.Combine(appdir, "sounds") + "\\" + soundfile;
                string helperapppath = appdir + "\\soundhelper.exe";
                try
                {
                    System.Diagnostics.Process.Start(helperapppath, "\"" + soundfilepath + "\"");
                    return true;
                }
                catch (Exception exc)
                {
                    misc.ToonError(exc);
                    return false;
                }
            }
            else
            {
                misc.ToonBericht(3);
                return false;
            }
        }
    }
}
