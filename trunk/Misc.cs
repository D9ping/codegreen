using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGreen
{
    /// <summary>
    /// Deze class handelt overige zaken.
    /// </summary>
    public class Misc
    {
        #region datavelden
        private int curlenword;
        private int wait =0;

        private int curintroregel = 0;
        private string[] intro_regel;

        #endregion

        #region properties
        public int Curlenword
        {
            get { return curlenword; }
            set { curlenword = value; }
        }
        #endregion

        #region constructor
        public Misc()
        {
            intro_regel = new String[5];
        }
        #endregion

        #region methoden
        public void ToonBericht(int msgnr)
        {
            switch (msgnr)
            {
                //berichten 01 t/m 10 voor fouten gereseveerd
                case 1:
                    System.Windows.Forms.MessageBox.Show("Fout: Afbeelding niet gevonden.");
                    break;
                case 2:
                    System.Windows.Forms.MessageBox.Show("Fout: onbekende menu knop.");
                    break;
                case 3:
                    System.Windows.Forms.MessageBox.Show("Fout: schrijven naar register mislukt.");
                    break;
                case 4:
                    System.Windows.Forms.MessageBox.Show("Fout: resource kon niet geladen worden.");
                    break;
                case 5:
                    System.Windows.Forms.MessageBox.Show("Fout: geluid niet gevonden.");
                    break;
                case 6:
                    System.Windows.Forms.MessageBox.Show("Fout: kan huizen niet aanmaken.");
                    break;
                case 7:
                    System.Windows.Forms.MessageBox.Show("Fout: kan huis niet vinden.");
                    break;
                case 8:
                    System.Windows.Forms.MessageBox.Show("Fout: kan item niet vinden.");
                    break;
                default:
                    System.Windows.Forms.MessageBox.Show("onbekende fout");
                    break;
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
                    curintroregel++;                   
                }
                return curlenword;
            }
        }

        public String TypeTextIntro()
        {
            intro_regel[0] = "This is your neighourhood.";
            intro_regel[1] = "Your objective is to take the microsoft server down.";
            intro_regel[2] = "To do this, you will need to setup a bot network";
            intro_regel[3] = "by hacking as many house in your neighhood as possible.";
            intro_regel[4] = "It's time to take control of that micr$oft bastards.";

            for (int i = 0; i < intro_regel.Length; i++)
            {
                if (curintroregel == i)
                {
                    return TypeWordEffect(intro_regel[i]);
                }
            }
            return "";
        }


        #endregion
    }
}
