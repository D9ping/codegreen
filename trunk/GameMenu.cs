//-----------------------------------------------------------------------
// <copyright file="GameMenu.cs" company="GNU">
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
    using System.Drawing;
    using System.Windows.Forms;

    public partial class GameMenu : Form
    {
        #region datavelden
        //private List<TextBox> droptexten;
        private List<DropText> droptexten;
        private int n = 0;
        private Misc misc;
        private int speed = 7;
        #endregion

        #region constructoren
        public GameMenu()
        {
            InitializeComponent();
            misc = new Misc();
            droptexten = new List<DropText>();
            timerDropText.Enabled = true;
        }
        #endregion

        #region methoden

        private void pbStartGame_Click(object sender, EventArgs e)
        {
            Form frmGame = new GameScreen();
            this.timerDropText.Enabled = false;
            frmGame.Show();
            this.Hide();
        }

        private void pbOptions_Click(object sender, EventArgs e)
        {
            GameOptions frmOptions = new GameOptions();
            this.timerDropText.Enabled = false;
            frmOptions.Show();
            this.Hide();
        }

        public void GameShutdown(object sender, EventArgs e)
        {
            timerDropText.Enabled = false;
            Application.Exit();
        }

        /// <summary>
        /// Laat een knop van het menu van plaatje veranderen.
        /// </summary>
        /// <param name="sender">de knop</param>
        /// <param name="e"></param>
        public void knop_hover(object sender, EventArgs e)
        {
            try
            {
                if (sender == pbStartGame)
                {
                    this.speed = 12;
                    pbStartGame.Image = CodeGreen.Properties.Resources.knop_start_selected;
                }
                else if (sender == pbOptions)
                {
                    this.speed = 10;
                    pbOptions.Image = CodeGreen.Properties.Resources.knop_options_selected; //resourcehandler.loadimage("knop_options_selected.png");
                }
                else if (sender == pbHighscore)
                {
                    this.speed = 8;
                    pbHighscore.Image = CodeGreen.Properties.Resources.knop_highscore_selected; //resourcehandler.loadimage("knop_highscore_selected.png");
                }
                else if (sender == pbExit)
                {
                    this.speed = 3;
                    pbExit.Image = CodeGreen.Properties.Resources.knop_exit_selected; //resourcehandler.loadimage("knop_exit_selected.png");
                }
                else
                {
                    misc.ToonBericht(2);
                }
            }
            catch
            {
                misc.ToonBericht(1);
            }
        }

        /// <summary>
        /// Dit zet de menu knop weer naar de niet highlight knop.
        /// </summary>
        /// <param name="sender">de knop</param>
        /// <param name="e"></param>
        public void knop_normal(object sender, EventArgs e)
        {
            this.speed = 7;

            try
            {
                if (sender == pbStartGame)
                {
                    pbStartGame.Image = CodeGreen.Properties.Resources.knop_start; //resourcehandler.loadimage("knop_start.png");
                }
                else if (sender == pbOptions)
                {
                    pbOptions.Image = CodeGreen.Properties.Resources.knop_options; //resourcehandler.loadimage("knop_options.png");
                }
                else if (sender == pbHighscore)
                {
                    pbHighscore.Image = CodeGreen.Properties.Resources.knop_highscore; //resourcehandler.loadimage("knop_highscore.png");
                }
                else if (sender == pbExit)
                {
                    pbExit.Image = CodeGreen.Properties.Resources.knop_exit; //resourcehandler.loadimage("knop_exit.png");
                }
                else 
                {
                    misc.ToonBericht(2); 
                }
            }
            catch
            {
                misc.ToonBericht(1);
            }
        }

        /// <summary>
        /// Maak een nieuwe vallende tekst, met willekeuige kleur 
        /// op willekeurige positie bovenaan.
        /// </summary>
        private void newDropText()
        {
            if (this.droptexten.Count < 100)
            {
                DropText newdroptext;
                Random ran = new Random();
                int locX = ran.Next(10, this.ClientRectangle.Width - 10);
                int ncolor = ran.Next(0, 3);
                string strcodegreen = "N\r\nE\r\nE\r\nR\r\nG\r\n\r\nE\r\nD\r\nO\r\nC";
                switch (ncolor)
                {
                    case 0:
                        newdroptext = new DropText(strcodegreen, Brushes.Green, locX);
                        break;
                    case 1:
                        newdroptext = new DropText(strcodegreen, Brushes.LightGreen, locX);
                        break;
                    case 2:
                        newdroptext = new DropText(strcodegreen, Brushes.DarkGreen, locX);
                        break;
                    default:
                        newdroptext = new DropText(strcodegreen, Brushes.Green, locX);
                        break;
                }
                this.droptexten.Add(newdroptext);
            }
        }

        private void updateDropText()
        {
            for (int i = 0; i < this.droptexten.Count; i++)
            {
                this.droptexten[i].Location = new Point(this.droptexten[i].Location.X, this.droptexten[i].Location.Y + this.speed);
                if (this.droptexten[i].Location.Y + 20 > this.ClientRectangle.Height)
                {
                    this.droptexten.Remove(this.droptexten[i]);
                }
            }
            this.Refresh();
        }

        private void timerDropText_Tick(object sender, EventArgs e)
        {
            this.updateDropText();
            n++;
            if (n == 4)
            {
                newDropText();
                n = 0;
            }
        }

        private void GameShutdown(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pbHighscore_Click(object sender, EventArgs e)
        {
            this.Hide();
            lbHighscoreInfo highscore = new lbHighscoreInfo();
            highscore.Show();
        }

        private void GameMenu_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Font font = new Font("Arail", 10);
            for (int i = 0; i < this.droptexten.Count; i++)
            {
                if (i < 100)
                {
                    g.DrawString(this.droptexten[i].Text, font, this.droptexten[i].Color, this.droptexten[i].Location);
                } 
            }
        }

    }
        #endregion methoden
}



