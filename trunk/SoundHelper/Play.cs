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
    using System.Media;
    using System.IO;

    class Play
    {
        static void Main(string[] args)
        {
            
            if (String.IsNullOrEmpty(args[0]))
            {
                System.Console.WriteLine("No argument passed. Dont lauch this file directly. Press enter to exit.");
                System.Console.Read();
                return;
            }
            //System.Console.WriteLine(args[0]);//for testing.

            if (File.Exists(args[0]))
            {
                SoundPlayer soundplayer = new SoundPlayer(args[0]);
                soundplayer.PlaySync();
            }
            else
            {
                System.Console.WriteLine("soundfile not found."+args[0]);
                System.Console.WriteLine("Press enter to exit.");
                System.Console.Read();
            }

            //System.Console.Read();//for testing.
        }
    }
}
