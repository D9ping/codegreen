namespace CodeGreen
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Finisar.SQLite;

    public partial class lbHighscoreInfo : Form
    {
        #region datavelden
        private int score;
        //private OleDbConnection connection;
        private SQLiteConnection connection;
        private Misc misc;
        #endregion

        #region contructor
        public lbHighscoreInfo()
        {
            InitializeComponent();
            misc = new Misc();
            //connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\hiscoren.mdb");
            connection = new SQLiteConnection("Data Source=highscoren;Version=3;New=False;Compress=False;");

            setGroupboxen();
            gethighscore();
            gbxHighscoren.Visible = true;
        }
        public lbHighscoreInfo(int timemin, int timesec, int geldover)
        {
            InitializeComponent();
            setGroupboxen();
            misc = new Misc();
            connection = new SQLiteConnection("Data Source=highscoren;Version=3;New=False;Compress=False;");
                //OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\hiscoren.mdb");
            
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

        /// <summary>
        /// Position groupboxs
        /// </summary>
        private void setGroupboxen()
        {
            gbxHighscoren.Location = new Point(10, 10);
            gbxHighscoren.Size = new Size(760, 480);
            gbxNewHighscore.Location = new Point(10, 10);
            gbxNewHighscore.Size = new Size(760, 480);
        }

        /// <summary>
        /// Gets and draws the highscores.
        /// </summary>
        private void gethighscore()
        {
            try
            {
                connection.Open();
                String query = "SELECT * FROM scoren ORDER BY Score DESC";

                //OleDbCommand selectcommand = new OleDbCommand(query, connection);
                SQLiteCommand selectcommand = new SQLiteCommand(query, connection);
                
                SQLiteDataReader reader;
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
                        String naam = Convert.ToString(reader["Naam"]);
                        String getdbscore = Convert.ToString(reader["Score"]);
                        lbscore.Text = positie.ToString() + ". " + naam + " (" + getdbscore + "points)";
                        lbscore.AutoSize = true;
                        lbscore.ForeColor = Color.Lime;
                        lbscore.Location = new Point(280, ypos);
                        lbscore.TextAlign = ContentAlignment.MiddleCenter;
                        ypos = ypos + 40;
                        fontsize = fontsize - 2;
                        this.gbxHighscoren.Controls.Add(lbscore);
                    }
                    positie++;
                }
            }
            catch (SQLiteException exc)
            {
                misc.ToonError(exc);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// User want to submit score, check if name is filled in
        /// then addscore and then show new highscores.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Add a new highscore.
        /// </summary>
        /// <param name="naam"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public bool addscore(String naam, int score)
        {
            bool sqladdsucces = false;
            try
            {
                connection.Open();
                String query = "INSERT INTO scoren (Naam, Score) VALUES ('" + naam + "', '" + score + "')";
                //OleDbCommand InsertCommand = new OleDbCommand(query, connection);
                SQLiteCommand InsertCommand = new SQLiteCommand(query, connection);
                InsertCommand.ExecuteNonQuery();
                sqladdsucces = true;
            }
            catch (SQLiteException exc)
            {
                misc.ToonError(exc);
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

        /// <summary>
        /// Enter key presses then fire tAddHighscore_Click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btAddHighscore_Click(sender, e);
            }
        }

        /// <summary>
        /// Shutdown application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameHighscore_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Back to mainmenu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbBackMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameMenu menu = new GameMenu();
            menu.Show();
        }


        #endregion
    }
}