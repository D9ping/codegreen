using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeGreen
{
    public partial class frmMenu : Form
    {
        #region datavelden        
        Misc misc;
        #endregion

        #region constructoren
        public frmMenu()
        {
            InitializeComponent();
            misc = new Misc();

        }
        #endregion

        #region methoden


        private void Timer_Tick(object sender, EventArgs e)
        {            
            //lbStartgame.Text = TypeWordEffect("Start game");                                   
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbStartgame_Click(object sender, EventArgs e)
        {
            GameScreen frmGame = new GameScreen();
            frmGame.Show();
            this.Hide();
        }

        private void lbOptions_Click(object sender, EventArgs e)
        {
            //Form frmOptions = new GameOptions();
        }

        private void lbHighscore_Click(object sender, EventArgs e)
        {
            //todo
        }
   
        private void pbStartGame_Click(object sender, EventArgs e)
        {
            Form frmGame = new GameScreen();
            frmGame.Show();
            this.Hide();
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
                    pbStartGame.Image = Image.FromFile("..\\..\\afb\\knop_start_selected.png");
                }
                else if (sender == pbOptions)
                {
                    pbOptions.Image = Image.FromFile("..\\..\\afb\\knop_options_selected.png");
                }
                else if (sender == pbHighscore)
                {
                    pbHighscore.Image = Image.FromFile("..\\..\\afb\\knop_highscore_selected.png");
                }
                else if (sender == pbExit)
                {
                    pbExit.Image = Image.FromFile("..\\..\\afb\\knop_exit_selected.png");
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
            try
            {
                if (sender == pbStartGame)
                {
                    pbStartGame.Image = Image.FromFile("..\\..\\afb\\knop_start.png");
                }
                else if (sender == pbOptions)
                {
                    pbOptions.Image = Image.FromFile("..\\..\\afb\\knop_options.png");
                }
                else if (sender == pbHighscore)
                {
                    pbHighscore.Image = Image.FromFile("..\\..\\afb\\knop_highscore.png");
                }
                else if (sender == pbExit)
                {
                    pbExit.Image = Image.FromFile("..\\..\\afb\\knop_exit.png");
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

        public void GameShutdown(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pbOptions_Click(object sender, EventArgs e)
        {
            GameOptions frmOptions = new GameOptions();
            frmOptions.Show();
            this.Hide();
        }

    }
        #endregion methoden
}



