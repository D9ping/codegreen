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
namespace SoundHelper
{
    using System;
    using System.IO;
    using System.Media;
    using System.Windows.Forms;

    class Play
    {
        static void Main(string[] args)
        {
            
            if (String.IsNullOrEmpty(args[0]))
            {
                MessageBox.Show("No argument passed to soundhelper.exe.\r\nDon't launch this file directly.");
                return;
            }

            if (File.Exists(args[0]))
            {
                SoundPlayer soundplayer = new SoundPlayer(args[0]);
                soundplayer.PlaySync();
            }
            else
            {
                MessageBox.Show("soundfile not found.\r\n" + args[0]);
            }
        }
    }
}
