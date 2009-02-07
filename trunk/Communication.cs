using System;
using System.Collections.Generic;
//using System.Linq;
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
        private String selectedhuis = "Your";
        private OptionsHandler options;
        #endregion

        #region constructor
        public Communication()
        {
            options = new OptionsHandler();            
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
            String rechts = "080000000";
            String links = "040000000";

            if (options.SwitchXaxis == true)
            {
                rechts = "040000000";
                links = "080000000";
            }                            

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
                else if ((gekozenX == 3) && (gekozenY == 2)) { gekozenY = 3; gekozenX = 2; }
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
                    if (gekozenX == 3) { selectedhuis = "Jan de Vries"; }
                    else if (gekozenX == 4) { selectedhuis = "Pieter"; }
                    break;
	            case 2:
                    if (gekozenX == 3) { selectedhuis = "Marrieke"; }
                    else if (gekozenX==4) { selectedhuis = "Your"; }
                    break;
                case 3:
                    switch (gekozenX)
	                {
		                case 1:
                            selectedhuis = "Bank";
                            break;
                        case 2:
                            selectedhuis = "Shop";
                            break;
                        case 3:
                            selectedhuis = "Roel";
                            break;
                        case 4:
                            selectedhuis = "HuisVriend";
                            break;
                	}
                    break;
            }            
        }

        public byte[] Roodledje1(bool status)
        {
            byte[] data = new byte[9];
            data[0] = 0; //report id
            data[1] = 1; //rood ledje
            if (status == true) { data[2] = 1; } //ledje status
            else if (status==false) { data[2] = 0;}
            //de rest 0
            for (int i = 3; i < 9; i++)
            {
                data[i] = 0;
            }
            return data;
        }

        public byte[] Groenledje1(bool status)
        {
            byte[] data = new byte[9];
            data[0] = 0; //report id
            data[1] = 2; //groen ledje
            if (status == true) { data[2] = 1; } //ledje status
            else if (status == false) { data[2] = 0; }
            //de rest 0
            for (int i = 3; i < 9; i++)
            {
                data[i] = 0;
            }
            return data;
        }

        public byte[] Roodledje2(bool status)
        {
            byte[] data = new byte[9];
            data[0] = 0; //report id
            data[1] = 4; //rood ledje
            if (status == true) { data[2] = 1; } //ledje status
            else if (status == false) { data[2] = 0; }
            //de rest 0
            for (int i = 3; i < 9; i++)
            {
                data[i] = 0;
            }
            return data;
        }
        

        
        #endregion
    }
}
