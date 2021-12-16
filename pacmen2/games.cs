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
    public partial class games : Form
    {
        public games()
        {
            InitializeComponent();
        }

        private void BtnOne_Click(object sender, EventArgs e)
        {
            // load this game
            // לפתוח את הקובץ ועל פיו ליצור אינסטנס חדש של הטופס פאקמן עם שלושת ההגדרות על פי המשחק השמור.
            string Name = Settings.profiles[Settings.AP].GamesSaved[(int)(((Button)sender).Tag)];
            string line;
            string[] arr;
            if (System.IO.File.Exists(Application.StartupPath + "\\profiles\\" + Name + ".pgs"))
            {
                string level;
                string life;
                string score;
                using (System.IO.StreamReader sw = new System.IO.StreamReader(Application.StartupPath + "\\profiles\\" + Name + ".pgs"))
                {
                    while (!sw.EndOfStream)
                    {
                        line = sw.ReadLine();
                        arr = line.Split(':');
                        switch (arr[0])
                        {
                            case "level":
                                level = arr[1].Trim();
                                break;
                            case "life":
                                life = arr[1].Trim();
                                break;
                            case "score":
                                score = arr[1].Trim();
                                break;
                        }
                    }
                    ;
                }
            }
        }
    }
}
