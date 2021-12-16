using Microsoft.VisualBasic;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PacmanGame
{
    public partial class FrmSelectProfile : Form
    {
        public FrmSelectProfile()
        {
            InitializeComponent();
            for (int i = 0; i < Settings.profiles.Count(); i++)
                LbxProfiles.Items.Add(Settings.profiles[i].Name);
            LbxProfiles.SelectedIndex = Settings.AP;
            LbxProfiles.Focus();
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(System.Globalization.CultureInfo.GetCultureInfo(1037));
        }

        private void CmmdOk_Click(object sender, EventArgs e)
        {
            // write to file the 'profil actuali' new.
            Settings.AP = LbxProfiles.SelectedIndex;
            string[] lines = System.IO.File.ReadAllLines(MyForms.PathProfiles);
            lines[lines.Length - 1] = Settings.AP.ToString();
            System.IO.File.WriteAllLines(MyForms.PathProfiles, lines);
            this.Close();
        }

        private void CmdDelete_Click(object sender, EventArgs e)
        {
            if (Settings.profiles.Count > 1)
            {
                if (LbxProfiles.SelectedIndex != Settings.AP)
                {
                    if (MessageBox.Show("האם אתה בטוח שברצונך למחוק את הפרופיל " + LbxProfiles.Text, "סנייק", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        string[] lines = System.IO.File.ReadAllLines(MyForms.PathProfiles);

                        System.IO.StreamWriter file = new System.IO.StreamWriter(MyForms.PathProfiles);

                        for (int i = 0; i < lines.Length; i++)
                        {
                            if (i != LbxProfiles.SelectedIndex)
                                file.WriteLine(lines[i]);
                        }
                        file.Close();

                        Settings.profiles.Remove(Settings.profiles[LbxProfiles.SelectedIndex]);
                        LbxProfiles.Items.Remove(LbxProfiles.Text);
                        LbxProfiles.SetSelected(0, true);
                    }
                }
                else
                    MessageBox.Show("אין באפשרותך למחוק את הפרופיל " + LbxProfiles.SelectedItem.ToString() + " כל זמן שהוא פתוח");
            }
        }

        private void CmdNew_Click(object sender, EventArgs e)
        {
            // show input box to enter name of player,
            // and update the file 'profiles.txt' with data of new player.
            FrmNewUser NewUser = new FrmNewUser();
            if (NewUser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Profiles.CreateProfile(NewUser.TxtName.Text, NewUser.CmbLangs.SelectedIndex, NewUser.CmbGender.SelectedIndex, "");
                LbxProfiles.Items.Add(Settings.profiles[Settings.profiles.Count - 1].Name);
            }
        }

        private void CmdRename_Click(object sender, EventArgs e)
        {
        InputNewName:
            string NewName = Interaction.InputBox("הכנס שם חדש", "שינוי שם פרופיל", LbxProfiles.Text);
            if (string.IsNullOrWhiteSpace(NewName))
            {
                MessageBox.Show("נא הכנס שם חדש");
                goto InputNewName;
            }
            else
            {
                Settings.profiles[LbxProfiles.SelectedIndex].Name = NewName;
                LbxProfiles.Items[LbxProfiles.SelectedIndex] = NewName;
                string[] lines = System.IO.File.ReadAllLines(MyForms.PathProfiles);
                lines[LbxProfiles.SelectedIndex] = Settings.ReturnLine(LbxProfiles.SelectedIndex);
                System.IO.File.WriteAllLines(MyForms.PathProfiles, lines);
            }
        }

        private void CmdPassword_Click(object sender, EventArgs e)
        {
            if (Settings.profiles[LbxProfiles.SelectedIndex].Password != null)
            {
                string res = Interaction.InputBox("הפרופיל מוגן באמצות סיסמא, נא הכנס כאן את הסיסמא שלך");
                if (res == Settings.profiles[LbxProfiles.SelectedIndex].Password)
                {
                    string pas = Interaction.InputBox("הסיסמא נכונה. נא הכנס את הסיסמא החדשה שברצונך לבחור");
                    Settings.profiles[LbxProfiles.SelectedIndex].Password = pas;

                    string[] lines = System.IO.File.ReadAllLines(MyForms.PathProfiles);
                    lines[LbxProfiles.SelectedIndex] = Settings.profiles[LbxProfiles.SelectedIndex].Name + "|" +
                        Settings.profiles[LbxProfiles.SelectedIndex].Language.ToString() + "|" +
                        Settings.profiles[LbxProfiles.SelectedIndex].HighScore + "|" +
                        Settings.profiles[LbxProfiles.SelectedIndex].men +
                        (pas == "" ? "" : "|" + Settings.profiles[LbxProfiles.SelectedIndex].Password);
                    System.IO.File.WriteAllLines(MyForms.PathProfiles, lines);

                    MessageBox.Show("הסיסמא שונתה בהצלחה");
                }
                else
                    MessageBox.Show("הסיסמא שהזנת אינה נכונה");
            }
            else
            {
                if (MessageBox.Show("?לפרופיל זה לא קיימת סיסמא. האם ברצונך ליצור סיסמא חדשה", "Pacmen", MessageBoxButtons.YesNo) 
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    string res = Interaction.InputBox("הכנס כאן את הסיסמא שלך");
                    if (!string.IsNullOrEmpty(res))
                    {
                        Settings.profiles[LbxProfiles.SelectedIndex].Password = res;

                        string[] lines = System.IO.File.ReadAllLines(MyForms.PathProfiles);
                        lines[LbxProfiles.SelectedIndex] = Settings.profiles[LbxProfiles.SelectedIndex].Name + "|" +
                            Settings.profiles[LbxProfiles.SelectedIndex].Language.ToString() + "|" +
                            Settings.profiles[LbxProfiles.SelectedIndex].HighScore + "|" +
                            Settings.profiles[LbxProfiles.SelectedIndex].men + "|"+
                            Settings.profiles[LbxProfiles.SelectedIndex].Password;
                        System.IO.File.WriteAllLines(MyForms.PathProfiles, lines);
                        MessageBox.Show("הסיסמא נוצרה בהצלחה");
                    }
                }
            }
        }
    }
}