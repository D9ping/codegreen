using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGreen
{
    class Misc
    {
        #region datavelden
        int curlenword;
        #endregion

        #region properties
        public int Curlenword
        {
            get { return curlenword; }
            set { curlenword = value; }
        }
        #endregion

        public void ToonBericht(int msgnr)
        {
            switch (msgnr)
            {
                case 1:
                    System.Windows.Forms.MessageBox.Show("Fout: Afbeelding niet gevonden.");                    
                    break;
                case 2:
                    System.Windows.Forms.MessageBox.Show("Fout: onbekende menu knop.");  
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
        public int get_len_type_text(int maxlenword)
        {
            if (curlenword != maxlenword)
            {
                curlenword++;
                return curlenword;                
            }
            else
            {
                curlenword = 0;                
                return curlenword;
            }
        }

    }
}
