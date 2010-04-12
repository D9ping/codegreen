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
        /// <summary>
        /// If errer is already showed and text is showed.
        /// </summary>
        private bool errorshowed = false, showtext = false;

        /// <summary>
        /// The current length of the text,  wait time,  and current line valeau
        /// </summary>
        private int curlenword, wait = 0, curregel = 0;
        
        /// <summary>
        /// Text of blink text and which text to play.
        /// </summary>
        private String blinktext, curtext = "intro";

        /// <summary>
        /// Story text
        /// </summary>
        private String[] introregel;

        /// <summary>
        /// Story text
        /// </summary>
        private String[] friendregel;
        #endregion

        #region constructor
        /// <summary>
        /// Initializes a new instance of the Misc class.
        /// </summary>
        public Misc()
        {
            introregel = new String[7];
            introregel[0] = "You work for microsol as a security expert.";
            introregel[1] = "One day you fell a sleep at the office.";
            introregel[2] = "Your boss does not take it, and fires you.";
            introregel[3] = "It's time take back your job,\r\n by showing off what you are capable to.";
            introregel[4] = "Try to hack as many houses\r\n in your neighbourhood as possible.";
            introregel[5] = "Then let them attack your company main server so your bots\r\nwill generate enough traffic to let the server crash.";            
            introregel[6] = "Now let get hacking.";

            friendregel = new String[4];
            friendregel[0] = "Your friend lives here, he works for The Bank.";
            friendregel[1] = "He is willing to give you a list";
            friendregel[2] = "of all bankaccounts in your neighbourhood.";
            friendregel[3] = "Click on accept, to get the list.";
        }
        #endregion

        #region properties
        /// <summary>
        /// Gets or sets the current length of the text.
        /// </summary>
        public int Curlenword
        {
            get
            {
                return curlenword;
            }

            set
            {
                curlenword = value;
            }
        }

        /// <summary>
        /// Gets or sets the current line of the story text.
        /// </summary>
        public int HuidigeRegel
        {
            get
            {
                return this.curregel;
            }

            set
            {
                this.curregel = value;
            }
        }

        /// <summary>
        /// Gets the current text
        /// </summary>
        public string HuidigeTekst
        {
            get
            {
                return this.curtext;
            }
        }

        /// <summary>
        /// Gets or sets a blink text.
        /// </summary>
        public string BlinkTekst
        {
            set
            {
                this.blinktext = value;
            }

            get
            {
                return blinktext;
            }
        }

        /// <summary>
        /// Gets the current text length.
        /// </summary>
        public int CurTekstLen
        {
            get
            {
                if (this.curtext == "intro")
                {
                    return this.introregel[curregel].Length;
                }
                else
                {
                    return this.friendregel[curregel].Length;
                }
            }
        }
        #endregion

        #region methoden

        /// <summary>
        /// Show a error message if not already showed.
        /// </summary>
        /// <param name="msgnr">The number of the message</param>
        public void ToonBericht(int msgnr)
        {
            if (errorshowed == false)
            {
                errorshowed = true;
                switch (msgnr)
                {
                    case 1:
                        MessageBox.Show("Error: Image not found.");
                        break;

                    case 2:
                        MessageBox.Show("Error: unknow menu button.");
                        break;

                    case 3:
                        MessageBox.Show("Error: couldnot play sound effect.");
                        break;

                    case 4:
                        MessageBox.Show("Error: resource cannot be loaded.");
                        break;

                    case 5:
                        MessageBox.Show("Error: sound file not found.");
                        break;

                    case 6:
                        MessageBox.Show("Error: House cannot be created.");
                        break;

                    case 7:
                        MessageBox.Show("Error: House cannot be found.");
                        break;

                    case 8:
                        MessageBox.Show("Error: Item cannot be found.");
                        break;

                    case 9:
                        MessageBox.Show("Error: item niet in inventory lijst.");
                        break;

                    case 10:
                        MessageBox.Show("Error: Onbekende huidige tekst"); 
                        break;

                    case 12:
                        MessageBox.Show("Error: Kan geld niet overmaken.");
                        break;

                    case 13:
                        MessageBox.Show("Error: Cannot connect with (atmel) controller.");
                        break;

                    default:
                        MessageBox.Show("Unknow error");
                        break;
                }
                errorshowed = false;
            }
        }

        /// <summary>
        /// Show a exception.
        /// </summary>
        /// <param name="exc">the exception object.</param>
        public void ToonError(Exception exc)
        {
            MessageBox.Show("Error: " + exc.Message + "\r\nLocation: " + exc.StackTrace);
        }

        /// <summary>
        /// Gebruik op label text eigenschap om het een ouderwets type effect te geven.
        /// </summary>
        /// <param name="word">the word/sentence to have the effect on.</param>
        /// <returns>the shortende text</returns>
        public string TypeWordEffect(String word)
        {
            curlenword = this.Get_len_type_text(word.Length);

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
        /// <returns>the length of the type text</returns>
        private int Get_len_type_text(int maxlenword)
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

        /// <summary>
        /// Type text on a story text array.
        /// </summary>
        /// <param name="what">what story</param>
        /// <returns>The story text of the currect line at the current length.</returns>
        public string TypeTextFull(string what)
        {
            int max_num_regels = 0;
            if (what == "intro") 
            {
                max_num_regels = introregel.Length;
            }
            else if (what == "friend")
            {
                max_num_regels = friendregel.Length;
            }

            for (int i = 0; i < max_num_regels; i++)
            {
                if (curregel == i)
                {
                    if (what == "intro")
                    {
                        curtext = "intro";
                        return TypeWordEffect(introregel[i]);
                    }
                    else if (what == "friend")
                    {
                        curtext = "friend";
                        return TypeWordEffect(friendregel[i]);
                    }
                }
            }

            return "";
        }

        /// <summary>
        /// Do blink effect on blinktext.
        /// </summary>
        /// <returns>Empty string if blink is on</returns>
        public String BlinkWordEffect()
        {
            wait++;
            if (showtext == true)
            {
                if (wait >= 5) { showtext = false; wait = 0; }
                return this.blinktext;
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
