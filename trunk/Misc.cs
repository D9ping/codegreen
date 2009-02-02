using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeGreen
{
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
        #endregion

        #region constructor
        public Misc()
        {
            intro_regel = new String[5];
            intro_regel[0] = "This is your neighourhood.";
            intro_regel[1] = "Your objective is to take the microsoft server down.";
            intro_regel[2] = "To do this, you will need to setup a bot network";
            intro_regel[3] = "by hacking as many house in your neighhood as possible.";
            intro_regel[4] = "It's time to take control of that micr$oft bastards.";

            friend_regel = new String[4];
            friend_regel[0] = "Your friend lives here, he works for Pabobank.";
            friend_regel[1] = "He is willing to give you a list";
            friend_regel[2] = "of all bankaccounts in your neighbourhood.";
            friend_regel[3] = "Click on accept, to get the list.";
        }
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
                        MessageBox.Show("Error: geluid niet gevonden.");
                        break;
                    case 6:
                        MessageBox.Show("Fout: kan huizen niet aanmaken.");
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
                    default:
                        MessageBox.Show("Unknow error");
                        break;                                        
                }
                errorshowed = false;
            }
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
                if (wait == 20)
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
