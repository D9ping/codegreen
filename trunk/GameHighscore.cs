using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CodeGreen
{
    public partial class GameHighscore : Form
    {
        #region datavelden
        private int score;
        private OleDbConnection connection;
        private Misc misc;
        #endregion

        #region contructor
        public GameHighscore()
        {
            InitializeComponent();
            misc = new Misc();
            connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\hiscoren.mdb");
            

            gethighscore();
            gbxHighscoren.Visible = true;
        }
        public GameHighscore(int timemin, int timesec, int geldover)
        {
            InitializeComponent();

            connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\hiscoren.mdb");

            berekenscore(timemin, timesec, geldover);
            //gethighscore();
            gbxNewHighscore.Visible = true;
        }
        #endregion

        #region properties
        #endregion

        #region methoden
        private void berekenscore(int timemin, int timesec, int geldover)
        {            
            if (timemin < 20)
            {
                score = 1200 - (timemin * 60) - timesec + geldover;
            }
            else
            {
                score = geldover;
            }
        }

        private void gethighscore()
        {

            try
            {
                connection.Open();
                String query = "SELECT * FROM scoren";

                OleDbCommand selectcommand = new OleDbCommand(query, connection);

                OleDbDataReader reader;
                reader = selectcommand.ExecuteReader();

                int ypos = 80;
                while (reader.Read())
                {
                    Label lbscore = new Label();
                    lbscore.Text = reader["Naam"].ToString() + " - " + reader["Scoren"];
                    lbscore.AutoSize = true;
                    lbscore.ForeColor = Color.Lime;
                    lbscore.Location = new Point(50, ypos);
                    lbscore.TextAlign = ContentAlignment.MiddleCenter;
                    ypos = ypos + 30;
                    this.gbxHighscoren.Controls.Add(lbscore);
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("fout db ophalen.: " + exc.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btAddHighscore_Click(object sender, EventArgs e)
        {            
            if ((tbName.Text!=null) || (tbName.Text!=""))
            {                
                gbxHighscoren.Text = DateTime.Now.ToString();
                //todo add score, datetime
            }
        }

        public void addscore(int score)
        {
            try
            {
                connection.Open();

                String query = "INSERT INTO SPELERS ()";
                OleDbCommand InsertCommand = new OleDbCommand(query, connection);
                InsertCommand.ExecuteNonQuery();
            }

            catch (Exception)
            {
                misc.ToonBericht(11);
            }
            finally
            {
                connection.Close();
            }
        }

        private void GameHighscore_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pbBackMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameMenu menu = new GameMenu();
            menu.Show();
        }


        #endregion
    }
}