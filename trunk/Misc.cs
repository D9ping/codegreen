//-----------------------------------------------------------------------
// <copyright file="Misc.cs" company="GNU">
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
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Deze class handelt overige zaken.
    /// </summary>
    public class Misc
    {
        #region datavelden
        private bool errorshowed = false;
        private bool showtext = false;
        private int curlenword;
        private int wait = 0;
        private int curregel = 0;
        private String blinktext;
        private String curtext = "intro";
        private String[] intro_regel;
        private String[] friend_regel;
        #endregion

        #region constructor
        public Misc()
        {
            intro_regel = new String[7];
            intro_regel[0] = "You work for microsol as a security expert.";
            intro_regel[1] = "One day you fell a sleep at the office.";
            intro_regel[2] = "Your boss does not take it, and fires you.";
            intro_regel[3] = "It's time take back your job,\r\n by showing off what you are capable to.";
            intro_regel[4] = "Try to hack as many houses\r\n in your neighbourhood as possible.";
            intro_regel[5] = "Then let them attack your company main server so your bots\r\nwill generate enough traffic to let the server crash.";            
            intro_regel[6] = "Now let get hacking.";

            friend_regel = new String[4];
            friend_regel[0] = "Your friend lives here, he works for The Bank.";
            friend_regel[1] = "He is willing to give you a list";
            friend_regel[2] = "of all bankaccounts in your neighbourhood.";
            friend_regel[3] = "Click on accept, to get the list.";
        }
        #endregion

        #region properties
        public int Curlenword
        {
            get { return curlenword; }
            set { curlenword = value; }
        }
        public int HuidigeRegel
        {
            get { return this.curregel; }
            set { this.curregel = value; }
        }
        public String HuidigeTekst
        {
            get { return curtext; }
        }
        public String BlinkTekst
        {
            set { this.blinktext = value; }
            get { return blinktext; }
        }
        public int CurTekstLen
        {
            get
            {
                if (this.curtext == "intro")
                {
                    return this.intro_regel[curregel].Length;
                }
                else
                {
                    return this.friend_regel[curregel].Length;
                }
            }
        }
        /*
        public int NumOfIntroRegels
        {
            get { return intro_regel.Length; }
        }
         */
        #endregion

        #region methoden

        /// <summary>
        /// Deze methode handelt alle mogelijke fout meldingen af. 
        /// </summary>
        /// <param name="msgnr"></param>
        public void ToonBericht(int msgnr)
        {
            if (errorshowed == false)
            {
                errorshowed = true;
                switch (msgnr)
                {
                    //TODO: moet naar Engels vertaald worden.
                    case 1:
                        MessageBox.Show("Error: Afbeelding niet gevonden.");
                        break;
                    case 2:
                        MessageBox.Show("Error: onbekende menu knop.");
                        break;
                    case 3:
                        MessageBox.Show("Error: schrijven naar register mislukt.");
                        break;
                    case 4:
                        MessageBox.Show("Error: resource kon niet geladen worden.");
                        break;
                    case 5:
                        MessageBox.Show("Error: sound file not found.");
                        break;
                    case 6:
                        MessageBox.Show("Error: kan huizen niet aanmaken.");
                        break;
                    case 7:
                        MessageBox.Show("Error: kan huis niet vinden.");
                        break;
                    case 8:
                        MessageBox.Show("Error: kan item niet vinden.");
                        break;
                    case 9:
                        MessageBox.Show("Error: item niet in inventory lijst.");
                        break;
                    case 10: 
                        MessageBox.Show("Error: Onbekende huidige tekst"); 
                        break;
                    case 11:
                        MessageBox.Show("Error: kan item niet in database stoppen");
                        break;
                    case 12:
                        MessageBox.Show("Error: Kan geld niet overmaken.");
                        break;
                    case 13:
                        MessageBox.Show("Error: Kan niet met atmel controller verbinden.");
                        break;
                    default:
                        MessageBox.Show("Unknow error");
                        break;
                }
                errorshowed = false;
            }
        }

        public void ToonError(Exception exc)
        {
            MessageBox.Show("Error: "+exc.Message+"\r\nLocation: "+exc.StackTrace);
        }

        /// <summary>
        /// Gebruik op label text eigenschap om het een ouderwets type effect te geven.
        /// </summary>
        /// <param name="word">woord met type effect.</param>
        /// <returns>tekst</returns>
        public String TypeWordEffect(String word)
        {
            curlenword = get_len_type_text(word.Length);

            for (int i = 0; i <= word.Length; i++)
            {
                if (i == curlenword)
                {
                    if (curlenword <= word.Length)
                    {
                        return word.Substring(0, curlenword) + "_"; 
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// Bepaalde hoelang de type text moet zijn.
        /// </summary>
        /// <param name="maxlenword">max lengte te typen</param>
        /// <returns>positie</returns>
        private int get_len_type_text(int maxlenword)
        {
            if (curlenword < maxlenword)
            {
                curlenword++;
                return curlenword;
            }
            else
            {
                wait++;
                if (wait == 50)
                {
                    curlenword = 0;
                    wait = 0;
                    curregel++;
                }
                return curlenword;
            }
        }

        public String TypeTextFull(String what)
        {
            int max_num_regels = 0;
            if (what == "intro") 
            {
                max_num_regels = intro_regel.Length;
            }
            else if (what == "friend")
            {
                max_num_regels = friend_regel.Length;
            }
            for (int i = 0; i < max_num_regels; i++)
            {
                if (curregel == i)
                {
                    if (what == "intro")
                    {
                        curtext = "intro";
                        return TypeWordEffect(intro_regel[i]);
                    }
                    else if (what == "friend")
                    {
                        curtext = "friend";
                        return TypeWordEffect(friend_regel[i]);
                    }
                }
            }
            return "";
        }

        public String BlinkWordEffect()
        {
            wait++;
            if (showtext == true)
            {
                if (wait >= 5) { showtext = false; wait = 0; }
                return blinktext;
            }
            else
            {
                if (wait >= 5) { showtext = true; wait = 0; }
                return "";
            }
        }

        #endregion
    }
}
