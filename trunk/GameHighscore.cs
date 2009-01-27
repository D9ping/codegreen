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
        public int score;
        private OleDbConnection connection;
        #endregion

        #region contructor
        public GameHighscore()
        {
            InitializeComponent();
            gethighscore();
        }
        #endregion

        #region properties
        #endregion

        #region methoden
        private void gethighscore()
        {
            connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\hiscoren.mdb");

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
                    lbscore.Text = reader["Naam"].ToString()+" - "+reader["Scoren"];
                    lbscore.AutoSize = true;
                    lbscore.ForeColor = Color.Lime;
                    lbscore.Location = new Point(200, ypos);
                    lbscore.TextAlign = ContentAlignment.MiddleCenter;
                    //lbscore.Font = new Font(fontFamily, 16, FontStyle.Regular, GraphicsUnit.Pixel);
                    //e.Graphics.DrawString(""); 
                    ypos = ypos + 30;
                    this.Controls.Add(lbscore);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("fout db ophalen.");
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

        private void GameHighscore_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            /*
            Font myfont = new Font(
            Brush myBrush = Brushes.Black;
            Point mypoint = new Point(20, 100);
            g.DrawString("test", myfont, mybrush, mypoint);
             */
        }

        #endregion
    }
}
