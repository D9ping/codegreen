//-----------------------------------------------------------------------
// <copyright file="Communication.cs" company="GNU">
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

    /// <summary>
    /// Initializes a new instance of Communication class.
    /// </summary>
    public class Communication
    {
        #region datavelden
        /// <summary>
        /// choicen house X and Y coordinates.
        /// </summary>
        private int gekozenX = 4, gekozenY = 2;

        /// <summary>
        /// Name of the selectedhouse.
        /// </summary>
        private string selectedhuis = "Your";

        #endregion

        #region constructor
        /// <summary>
        /// Initializes a new instance of the Communication class.
        /// </summary>
        public Communication()
        {
        }
        #endregion

        #region properties
        /// <summary>
        /// Gets the selected house as string.
        /// </summary>
        public string GeselecteerdHuis
        {
            get { return this.selectedhuis; }
        }
        #endregion

        #region methoden
        /// <summary>
        /// verwerk binnen gekomen data Atmel controller.
        /// </summary>
        /// <param name="data">raw data from the controller.</param>
        public void DataAtmelController(byte[] data)
        {
            string s = string.Empty;
            for (int i = 0; i < data.Length; i++)
            {
                s += data[i].ToString();
            }

            string boven = "010000000";
            string onder = "020000000";
            string rechts = "080000000";
            string links = "040000000";

            if (CodeGreen.Properties.Settings.Default.controllerSwitchXasix)
            {
                rechts = "040000000";
                links = "080000000";
            }

            if (s == boven)
            {
                if (this.gekozenY > 1)
                {
                    if (this.gekozenX == 3)
                    {
                        this.gekozenY = this.gekozenY - 1;
                    }
                    else if (this.gekozenX == 4)
                    {
                        this.gekozenY = this.gekozenY - 1;
                    }
                    else if ((this.gekozenX == 1) || (this.gekozenX == 2))
                    {
                        this.gekozenX = 3;
                        this.gekozenY--;
                    }
                }
            }
            else if (s == onder)
            {
                if (this.gekozenY < 3)
                {
                    if (this.gekozenX == 3) 
                    {
                        this.gekozenY = this.gekozenY + 1;
                    }
                    else if (this.gekozenX == 4) 
                    {
                        this.gekozenY = this.gekozenY + 1;
                    }
                }
            }
            else if (s == rechts)
            {
                if ((this.gekozenX > 0) && this.gekozenX < 4)
                {
                    this.gekozenX = this.gekozenX + 1;
                }
            }
            else if (s == links)
            {
                if ((this.gekozenY == 3) && (this.gekozenX > 1))
                {
                    this.gekozenX = this.gekozenX - 1;
                }
                else if (this.gekozenX > 3)
                {
                    this.gekozenX = this.gekozenX - 1;
                }
                else if ((this.gekozenX == 3) && (this.gekozenY == 2))
                {
                    this.gekozenY = 3;
                    this.gekozenX = 2;
                }
            }

            this.UpdateGelecteerdHuis();
        }

        /// <summary>
        /// gekozen huis updaten
        /// </summary>
        public void UpdateGelecteerdHuis()
        {
            switch (this.gekozenY)
            {
                case 1:
                    if (this.gekozenX == 3) 
                    {
                        this.selectedhuis = "Jan de Vries"; 
                    }
                    else if (this.gekozenX == 4) 
                    {
                        this.selectedhuis = "Pieter"; 
                    }

                    break;

                case 2:
                    if (this.gekozenX == 3) 
                    {
                        this.selectedhuis = "Marrieke"; 
                    }
                    else if (gekozenX == 4) 
                    {
                        this.selectedhuis = "Your"; 
                    }

                    break;

                case 3:
                    switch (this.gekozenX)
                    {
                        case 1:
                            this.selectedhuis = "Bank";
                            break;
                        case 2:
                            this.selectedhuis = "Shop";
                            break;
                        case 3:
                            this.selectedhuis = "Roel";
                            break;
                        case 4:
                            this.selectedhuis = "HuisVriend";
                            break;
                    }

                    break;
            }
        }

        /// <summary>
        /// Enable or disable the red led.
        /// </summary>
        /// <param name="status">Switch the let on or off.</param>
        /// <returns>the data as bytes.</returns>
        public byte[] Roodledje1(bool status)
        {
            byte[] data = new byte[9];
            data[0] = 0;
            data[1] = 1;
            if (status == true) 
            {
                data[2] = 1; ////ledje status
            }
            else if (status == false)
            {
                data[2] = 0; 
            }

            for (int i = 3; i < 9; i++)
            {
                data[i] = 0;
            }

            return data;
        }

        /// <summary>
        /// Enable or disable green led.
        /// </summary>
        /// <param name="status">Switch the let on or off.</param>
        /// <returns>the data as bytes.</returns>
        public byte[] Groenledje1(bool status)
        {
            byte[] data = new byte[9];
            data[0] = 0; ////report id
            data[1] = 2; ////groen ledje
            if (status == true) 
            {
                data[2] = 1;
            }
            else if (status == false) 
            {
                data[2] = 0;
            }
            
            for (int i = 3; i < 9; i++)
            {
                data[i] = 0;
            }

            return data;
        }

        /// <summary>
        /// Enable or disable second red led.
        /// </summary>
        /// <param name="status">Switch the let on or off.</param>
        /// <returns>the data as bytes</returns>
        public byte[] Roodledje2(bool status)
        {
            byte[] data = new byte[9];
            data[0] = 0; ////report id
            data[1] = 4; ////red led
            if (status == true) 
            {
                data[2] = 1; ////led status
            }
            else if (status == false)
            {
                data[2] = 0;
            }

            for (int i = 3; i < 9; i++)
            {
                data[i] = 0;
            }

            return data;
        }

        #endregion
    }
}
