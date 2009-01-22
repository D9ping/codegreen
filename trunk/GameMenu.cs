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
        private List<TextBox> droptexten;
        private int n = 0;
        private Misc misc;
        private ResourceHandler resourcehandler;
        #endregion

        #region constructoren
        public GameMenu()
        {
            InitializeComponent();
            misc = new Misc();
            resourcehandler = new ResourceHandler();
            droptexten = new List<TextBox>();
            timerDropText.Enabled = true;

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
                }
                else if (sender == pbOptions)
                {
                    pbOptions.Image = resourcehandler.loadimage("knop_options_selected.png");                    
                }
                else if (sender == pbHighscore)
                {
                    pbHighscore.Image = resourcehandler.loadimage("knop_highscore_selected.png");                    
                }
                else if (sender == pbExit)
                {
                    pbExit.Image = resourcehandler.loadimage("knop_exit_selected.png");                    
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
                    pbStartGame.Image = resourcehandler.loadimage("knop_start.png");                        
                }
                else if (sender == pbOptions)
                {
                    pbOptions.Image = resourcehandler.loadimage("knop_options.png");                        
                }
                else if (sender == pbHighscore)
                {
                    pbHighscore.Image = resourcehandler.loadimage("knop_highscore.png");                        
                }
                else if (sender == pbExit)
                {
                    pbExit.Image = resourcehandler.loadimage("knop_exit.png");                        
                }
                    //sender not found...
                else { misc.ToonBericht(2); }
            }
            catch
            {
                misc.ToonBericht(1);
            }
        }

        private void newDropText()
        {
            Random ran = new Random();
            int Xnewtextbox = ran.Next(10, 790);
            String ent = "\r\n"; // opmerking: \r is enter en \n is een linefeed.
            
            TextBox newtextbox = new TextBox();            
            newtextbox.AcceptsReturn = true;
            newtextbox.Multiline = true;
            int numcolor = ran.Next(0, 3);
                if(numcolor==0) { newtextbox.ForeColor = Color.Green; }
                else if (numcolor == 1) { newtextbox.ForeColor = Color.LightGreen; }
                else if (numcolor == 2) { newtextbox.ForeColor = Color.DarkGreen; }
                //else if (numcolor == 3) { newtextbox.ForeColor = Color.Lime; }
                else { newtextbox.ForeColor = Color.Green; }            
            newtextbox.BackColor = Color.Black;
            newtextbox.BorderStyle = BorderStyle.None;
            newtextbox.ScrollBars = ScrollBars.None;
            newtextbox.Location = new Point(Xnewtextbox, -139);
            newtextbox.Height = 140;
            newtextbox.Width = 15;
            newtextbox.Cursor = Cursors.Default;
            newtextbox.Text = "N" + ent + "E" + ent + "E" + ent + "R" + ent + "G" + ent + ent + "E" + ent + "D" + ent + "O" + ent + "C";            
            this.Controls.Add(newtextbox);
            droptexten.Add(newtextbox);
        }

        private void updateDropText()
        {
            for (int i = 0; i < droptexten.Count; i++)
            {
                int Xtext = droptexten[i].Location.X;
                int Ytext = droptexten[i].Location.Y + 10;

                if (Ytext > 600) {                     
                    droptexten[i].Dispose();//dit verkomt dat programma steeds meer geheugen gaat verbruiken.
                }
                else { droptexten[i].Location = new Point(Xtext, Ytext); }
            }
        }

        private void timerDropText_Tick(object sender, EventArgs e)
        {
            this.updateDropText();
            n++;
            if (n == 2)
            {
                newDropText();
                n = 0;   
            }
        }


    }
        #endregion methoden
}



