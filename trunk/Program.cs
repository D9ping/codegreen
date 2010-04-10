//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="GNU">
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
    using System.Windows.Forms;
    using System.IO;
    using System.Runtime.InteropServices;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameMenu());
        }

        [DllImport("winmm.dll")]
        public static extern int sndPlaySound(string sFile, int sMode);

        public static bool PlaySoundFile(string naam)
        {
            try
            {
                string sounddir = Application.StartupPath + "\\sounds\\";
                if (Directory.Exists(sounddir))
                {
                    string soundfile = Path.Combine(sounddir, naam);
                    if (File.Exists(soundfile))
                    {
                        sndPlaySound(soundfile, 1); //1 = Async
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
