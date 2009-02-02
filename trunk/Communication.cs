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

            String boven = "010000000";
            String onder = "020000000";
            String rechts = "040000000";
            String links = "080000000";

            if (s == boven)
            {
                if (gekozenY > 1)
                {
                    if (gekozenX == 3) { gekozenY = gekozenY - 1; }
                    else if (gekozenX == 4) { gekozenY = gekozenY - 1; }
                    else if ((gekozenX==1) || (gekozenX==2))
                    { gekozenX = 3;
                      gekozenY--; }
                }
            }
            else if (s == onder)
            {
                if (gekozenY < 3)
                {
                    if (gekozenX == 3) { gekozenY = gekozenY + 1; }
                    else if (gekozenX == 4) { gekozenY = gekozenY + 1; }
                }
            }
            else if (s == rechts)
            {
                if ((gekozenX > 0) && gekozenX <4)
                {                    
                    gekozenX = gekozenX + 1;
                }
            }
            else if (s == links)
            {
                if ((gekozenY == 3) && (gekozenX >1)) { gekozenX = gekozenX - 1; }
                else if (gekozenX > 3) { gekozenX = gekozenX - 1; }
            }            

            UpdateGelecteerdHuis();
        }

                
        /// <summary>
        /// gekozen huis updaten
        /// </summary>
        public void UpdateGelecteerdHuis()
        {
            switch (gekozenY)
            {
                case 1:
                    if (gekozenX==3) { selectedhuis = "pbHuis2"; }
                    else if (gekozenX==4) { selectedhuis = "pbHuis4"; }
                    break;
	            case 2:
                    if (gekozenX==3) { selectedhuis = "pbHuis3"; }
                    else if (gekozenX==4) { selectedhuis = "pbHuis1"; }
                    break;
                case 3:
                    switch (gekozenX)
	                {
		                case 1:
                            selectedhuis = "pbBank";
                            break;
                        case 2:
                            selectedhuis = "pbShop";
                            break;
                        case 3:
                            selectedhuis = "pbHuis5";
                            break;
                        case 4:
                            selectedhuis = "pbHuisVriend";
                            break;
                	}
                    break;
            }            
        }

        

        
        #endregion
    }
}
