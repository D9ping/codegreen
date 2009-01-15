using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGreen
{
    /// <summary>
    /// Deze class handelt de communcatie met de Atmel controller.
    /// </summary>
    class Communication
    {
        #region datavelden
        private int gekozenX = 0;
        private int gekozenY = 0;
        #endregion

        #region constructor
        #endregion

        #region properties
        #endregion

        #region methoden
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void VerwerkData(byte[] data)
        {
            string s = "";
            for (int i = 0; i < data.Length; i++) s += data[i].ToString();
            if (s == "010000000")
            {
                if (gekozenY > 1)
                {
                    if (gekozenX == 3)
                    {
                        gekozenY = gekozenY - 1;
                        //Gekozen();
                    }
                    else
                    {
                        gekozenY = gekozenY - 2;
                        //Gekozen();
                    }
                }
            }
            else if (s == "020000000")
            {
                if (gekozenY < 3)
                {
                    if (gekozenX == 3)
                    {
                        gekozenY = gekozenY + 1;
                        //Gekozen();
                    }
                    else
                    {
                        gekozenY = gekozenY + 2;
                        //Gekozen();
                    }
                }
            }
            else if (s == "040000000")
            {
                if (gekozenX > 1)
                {
                    if (gekozenY == 2)
                    {
                        gekozenY = 1;
                    }
                    gekozenX = gekozenX - 1;
                    //Gekozen();
                }
            }
            else if (s == "080000000")
            {
                if (gekozenX < 3)
                {
                    gekozenX = gekozenX + 1;
                    //Gekozen();
                }
            }
            else if (s == "0160000000")
            {
                Misc ms = new Misc();
                ms.ToonBericht(3);
            }
        }

        /*
        /// <summary>
        /// gekozen huis updaten
        /// </summary>
        public void Gekozen()
        {
            if (gekozenX == 1 && gekozenY == 1)
            {
                //pbHuisX1Y1.Image = HuizenBank.Images[3];
                gekozen = "Huis 1";
            }
            if (gekozenX == 1 && gekozenY == 3)
            {
                //pbHuisX1Y3.Image = HuizenBank.Images[3];
                gekozen = "Huis 2";
            }
            if (gekozenX == 2 && gekozenY == 1)
            {
                //pbMicrosoftX2Y1.Image = Microsoft.Images[1];
                gekozen = "Microsoft Gebouw";
            }
            if (gekozenX == 2 && gekozenY == 3)
            {
                //pbHuisX2Y3.Image = HuizenBank.Images[3];
                gekozen = "Huis 3";
            }
            if (gekozenX == 3 && gekozenY == 1)
            {
                //pbHuisX3Y1.Image = HuizenBank.Images[3];
                gekozen = "Huis 4";
            }
            if (gekozenX == 3 && gekozenY == 2)
            {
                //pbBankX3Y2.Image = HuizenBank.Images[1];
                gekozen = "Bank";
            }
            if (gekozenX == 3 && gekozenY == 3)
            {
                //pbHuisX3Y3.Image = HuizenBank.Images[3];
                gekozen = "Huis 5";
            }
        }

        */
        #endregion
    }
}
