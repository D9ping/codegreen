using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGreen
{
    /// <summary>
    /// Deze class handelt de communicatie met controllers af.
    /// </summary>
    public class Communication
    {
        #region datavelden
        private int gekozenX = 4;
        private int gekozenY = 2;
        private String selectedhuis;
        #endregion

        #region constructor
        public Communication()
        {

        }
        #endregion

        #region properties
        public String GeselecteerdHuis
        {
            get { return this.selectedhuis; }
        }
        #endregion

        #region methoden
        /// <summary>
        /// verwerk binnen gekomen data Atmel controller.
        /// </summary>
        /// <param name="data"></param>
        public void DataAtmelController(byte[] data)
        {                   
            string s = "";
            for (int i = 0; i < data.Length; i++) s += data[i].ToString();
            
            if (s == "010000000")
            {
                if (gekozenY > 1)
                {
                    if (gekozenX == 3) { gekozenY = gekozenY - 1; }
                    else { gekozenY = gekozenY - 2;  }
                }
            }
            else if (s == "020000000")
            {
                if (gekozenY < 3)
                {
                    if (gekozenX == 3) { gekozenY = gekozenY + 1; }
                    else { gekozenY = gekozenY + 2; }
                }
            }
            else if (s == "040000000")
            {
                if (gekozenX > 1)
                {
                    if (gekozenY == 2) { gekozenY = 1; }
                    gekozenX = gekozenX - 1;                    
                }
            }
            else if (s == "080000000")
            {
                if (gekozenX < 3) { gekozenX = gekozenX + 1; }
            }
            else if (s == "0160000000")
            {
               
            }

            UpdateGelecteerdHuis();
        }

                
        /// <summary>
        /// gekozen huis updaten
        /// </summary>
        public void UpdateGelecteerdHuis()
        {
            
        }

        
        #endregion
    }
}
