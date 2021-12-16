using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PacmanGame
{
    public partial class FrmSummery : Form
    {
        public FrmSummery(string s, bool NewHighScore)
        {
            InitializeComponent();
            pictureBox1.Visible = NewHighScore;
            LblHighScore.Visible = !NewHighScore;
            if (NewHighScore)
            {
                LblSummery.Text = " שברת שיא!\nהשיא החדש שלך הוא:\n" + s;
            }
            else
            {
                LblSummery.Text = "הניקוד שלך הוא:\n" + s;
                LblHighScore.Text = "השיא שלך:\n" + Settings.profiles[Settings.AP].HighScore[2];
            }
            MyForms.ShowWithAnim(this);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
