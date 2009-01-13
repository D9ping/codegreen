using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace CodeGreen
{
    public partial class GameMenu : Form
    {
        #region datavelden        
        Misc misc;
        ResourceHandler resourcehandler;
        #endregion

        #region constructoren
        public GameMenu()
        {
            InitializeComponent();
            misc = new Misc();
            resourcehandler = new ResourceHandler();

        }
        #endregion

        #region methoden

        private void pbStartGame_Click(object sender, EventArgs e)
        {
            Form frmGame = new GameScreen();
            frmGame.Show();
            this.Hide();
        }

        private void pbOptions_Click(object sender, EventArgs e)
        {
            GameOptions frmOptions = new GameOptions();
            frmOptions.Show();
            this.Hide();
        }

        public void GameShutdown(object sender, EventArgs e)
        {
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
                    pbStartGame.Image = resourcehandler.loadimage("knop_start_selected.png");
                    //pbStartGame.Image = Image.FromFile("..\\..\\afb\\knop_start_selected.png");
                }
                else if (sender == pbOptions)
                {
                    pbOptions.Image = resourcehandler.loadimage("knop_options_selected.png");
                    //pbOptions.Image = Image.FromFile("..\\..\\afb\\knop_options_selected.png");
                }
                else if (sender == pbHighscore)
                {
                    pbHighscore.Image = resourcehandler.loadimage("knop_highscore_selected.png");
                    //pbHighscore.Image = Image.FromFile("..\\..\\afb\\knop_highscore_selected.png");
                }
                else if (sender == pbExit)
                {
                    pbExit.Image = resourcehandler.loadimage("knop_exit_selected.png");
                    //pbExit.Image = Image.FromFile("..\\..\\afb\\knop_exit_selected.png");
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

    }
        #endregion methoden
}



