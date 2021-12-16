using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PacmanGame
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            // load profile  file
            List<string> lstsavedGames = new List<string>();
            string[] Lines = System.IO.File.ReadAllLines(MyForms.PathProfiles);
            foreach (string line in Lines)
            {
                // - if this line contains a profile
                if (line.Contains("|"))
                {
                    string[] spli = line.Split('|');
                    Settings.profiles.Add(new Profile
                    {
                        Name = spli[0],
                        Language = int.Parse(spli[1]),
                        HighScore = new string[] { spli[2], spli[3], spli[4] },
                        HighLevel = spli[5],
                        men = spli[6],
                        Password = spli[7],
                        PlayMusic = bool.Parse(spli[8]),
                        PlaySound = bool.Parse(spli[9])
                    });
                }
                // - if this line contains saved game
                else if (line.StartsWith("Saved Game"))
                    lstsavedGames.Add(line.Replace("Saved Game ", ""));
                // - if this line indicates the profile number
                else
                    Settings.AP = int.Parse(line);
            }
            LblName.Text = "!" + Settings.profiles[Settings.AP].Name + ", " +
                (Settings.profiles[Settings.AP].men == "0" ? "ברוך הבא" : "ברוכה הבאה");
            MyForms.ShowWithAnim(this);
        }

        private void BtnNewGame_Click(object sender, EventArgs e)
        {
            FrmPacmen frmPacmen = new FrmPacmen();
            frmPacmen.ShowDialog();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            FrmSettings frmSettings = new FrmSettings();
            tlp1.Hide();
            this.Controls.Add(frmSettings.TlpSettings);
            frmSettings.TlpSettings.Controls["BtnBack"].Focus();
            frmSettings.TlpSettings.Controls["BtnBack"].Click += BackFromSettings;
            frmSettings.panel1.Controls["CmdOk"].Click += BackFromSettings;
        }

        void BackFromSettings(object sender, EventArgs e)
        {
            this.Controls.RemoveAt(this.Controls.Count - 1);
            tlp1.Show();
            BtnSettings.Focus();
        }

        private void BtnProfiles_Click(object sender, EventArgs e)
        {
            tlp1.Hide();
            FrmHighScore frmHighScore = new FrmHighScore();
            this.Controls.Add(frmHighScore.TlpHS);
            frmHighScore.TlpHS.Controls["BtnBack"].Click += BackFromHS;
            System.Text.StringBuilder MyText = new System.Text.StringBuilder("הניקוד הגבוה ביותר:");
            //load all data
            MyText.Append("\n" + "1. " + Settings.profiles[Settings.AP].HighScore[0]);
            if (Settings.profiles[Settings.AP].HighScore[1] != "0")
                MyText.Append("\n" + "2. " + Settings.profiles[Settings.AP].HighScore[1]);
            if (Settings.profiles[Settings.AP].HighScore[2] != "0")
                MyText.Append("\n" + "3. " + Settings.profiles[Settings.AP].HighScore[2]);
            MyText.Append("\n" + "\n" + "השלב הגבוה ביותר:" + "\n" + Settings.profiles[Settings.AP].HighLevel);
            frmHighScore.TlpHS.Controls["LblHS"].Text = MyText.ToString();
            frmHighScore.TlpHS.Controls["BtnBack"].Focus();
        }

        void BackFromHS(object sender, EventArgs e)
        {
            this.Controls.RemoveAt(this.Controls.Count-1);
            tlp1.Show();
            BtnHighScore.Focus();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        void timerClosing_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.05;
            if (this.Opacity == 0)
            {
                Close();
                ((Timer)sender).Stop();
            }
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {
            tlp1.Hide();
            FrmHelp frmhelp = new FrmHelp();
            this.Controls.Add(frmhelp.TlpMy);
            frmhelp.TlpMy.Controls["BtnBack"].Click += BackFromHelp;
            frmhelp.TlpMy.Controls["BtnBack"].Focus();
        }

        void BackFromHelp(object sender, EventArgs e)
        {
            this.Controls.RemoveAt(this.Controls.Count - 1); 
            tlp1.Show();
            BtnHelp.Focus();
        }

        private void BtnProfiles_Click_1(object sender, EventArgs e)
        {
            FrmSelectProfile Selector = new FrmSelectProfile();
            if (Selector.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                LblName.Text = "!" + Settings.profiles[Settings.AP].Name + ", " +
                    (Settings.profiles[Settings.AP].men == "0" ? "ברוך הבא" : "ברוכה הבאה");
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Opacity == 1)
            {
                if (System.Windows.Forms.MessageBox.Show("?האם אתה בטוח שברצונך לצאת", "Pacmen", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    Timer timerClosing = new Timer() { Interval = 5 };
                    timerClosing.Tick += timerClosing_Tick;
                    timerClosing.Start();
                }
                e.Cancel = true;
            }
        }

        private void BtnContinueGame_Click(object sender, EventArgs e)
        {

        }
    }
}
// in start:
// if (Registry.CurrentUser.OpenSubKey("Pacmen", true).GetValue("Mode").ToString() == System.IO.File.ReadAllText("Profiles.txt").GetHashCode().ToString())
// in closing:
// Registry.CurrentUser.OpenSubKey("Pacmen", true).SetValue("Mode", System.IO.File.ReadAllText("Profiles.txt").GetHashCode().ToString());