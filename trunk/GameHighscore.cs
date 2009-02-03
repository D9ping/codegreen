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
    public partial class lbHighscoreInfo : Form
    {
        #region datavelden
        private int score;
        private OleDbConnection connection;
        private Misc misc;        
        #endregion

        #region contructor
        public lbHighscoreInfo()
        {
            InitializeComponent();
            misc = new Misc();
            connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\hiscoren.mdb");

            setGroupboxen();
            gethighscore();
            gbxHighscoren.Visible = true;
        }
        public lbHighscoreInfo(int timemin, int timesec, int geldover)
        {
            InitializeComponent();
            setGroupboxen();
            misc = new Misc();
            connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\hiscoren.mdb");
            
            berekenscore(timemin, timesec, geldover);            
            gbxNewHighscore.Visible = true;
            misc.Curlenword = 0;
            timerTextEffect.Enabled = true;
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

        private void setGroupboxen()
        {
            gbxHighscoren.Location = new Point(10, 10);            
            gbxHighscoren.Size = new Size(760, 480);
            gbxNewHighscore.Location = new Point(10, 10);
            gbxNewHighscore.Size = new Size(760, 480);
        }
        private void gethighscore()
        {

            try
            {
                connection.Open();
                String query = "SELECT * FROM scoren ORDER BY Score DESC";

                OleDbCommand selectcommand = new OleDbCommand(query, connection);

                OleDbDataReader reader;
                reader = selectcommand.ExecuteReader();
                int positie = 1;
                int ypos = 50;
                int fontsize = 24;
                while (reader.Read())
                {
                    if (positie < 11)
                    {
                        Label lbscore = new Label();
                        lbscore.Font = new Font(lbscore.Font.FontFamily, fontsize);
                        lbscore.Text = positie.ToString() + ". " + reader["Naam"].ToString() + "  (" + reader["Score"] + "points)";
                        lbscore.AutoSize = true;
                        lbscore.ForeColor = Color.Lime;
                        lbscore.Location = new Point(300, ypos);
                        lbscore.TextAlign = ContentAlignment.MiddleCenter;
                        ypos = ypos + 40;
                        fontsize = fontsize - 2;                        
                        this.gbxHighscoren.Controls.Add(lbscore);
                    }
                    positie++;
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
                if (addscore(tbName.Text, score) == true)
                {
                    gethighscore();
                    gbxHighscoren.Visible = true;
                }
            }
        }

        public bool addscore(String naam, int score)
        {
            bool sqladdsucces = false;
            try
            {
                connection.Open();

                String query = "INSERT INTO scoren (Naam, Score) VALUES ('" + naam + "', '" + score + "')";
                OleDbCommand InsertCommand = new OleDbCommand(query, connection);
                InsertCommand.ExecuteNonQuery();
                sqladdsucces = true;
            }

            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                sqladdsucces = false;
            }
            finally
            {
                connection.Close();
            }
            return sqladdsucces;
        }

        private void timerTextEffect_Tick(object sender, EventArgs e)
        {
            
            this.lbHighscorenInfo.Text = misc.TypeWordEffect("Congratulations you have overloaded the microsoft server.");
        }

        private void tbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btAddHighscore_Click(sender, e);
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