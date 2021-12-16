using System;
using System.Windows.Forms;

namespace PacmanGame
{
    public partial class FrmPause : Form
    {
        int _level;
        int _life;
        int _score;
        public FrmPause(int level, int life, int score)
        {
            InitializeComponent();
            MyForms.ShowWithAnim(this);
            _level = level;
            _life = life;
            _score = score;
            if (Settings.profiles[Settings.AP].GamesSaved.Count > 2)
                BtnSaveGame.Enabled = false;
        }

        private void BtnSaveGame_Click(object sender, EventArgs e)
        {
            string str = Microsoft.VisualBasic.Interaction.InputBox("שמירת משחק", "הכנס כאן את שם המשחק שלך");
            if (!string.IsNullOrEmpty(str))
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(Application.StartupPath + "\\profiles\\" + str + ".pgs"))
                {
                    sw.WriteLine("level: " + _level);
                    sw.WriteLine("life: " + _life);
                    sw.WriteLine("score: " + _score);
                }
                string[] lines = System.IO.File.ReadAllLines(MyForms.PathProfiles);
                lines[Settings.AP] += "*" + str;
                Settings.profiles[Settings.AP].GamesSaved.Add(str);
                System.IO.File.WriteAllLines(MyForms.PathProfiles, lines);
            }
        }

        private void BtnLoadGame_Click(object sender, EventArgs e)
        {
            games f = new games();
            f.ShowDialog();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}