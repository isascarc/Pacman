using System;
using System.Windows.Forms;

namespace PacmanGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// 
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (System.IO.File.Exists(MyForms.PathProfiles))
                Application.Run(new FrmMain());
            else
            {
                FrmNewUser NewUser = new FrmNewUser();
                if (NewUser.ShowDialog()  == System.Windows.Forms.DialogResult.OK)
                {
                    Profiles.CreateProfile(NewUser.TxtName.Text, NewUser.CmbLangs.SelectedIndex, NewUser.CmbGender.SelectedIndex, "");
                    Application.Run(new FrmMain());
                }
            }
        }
    }

    public static class MyForms
    {
        public const string PathProfiles = "profiles\\Profiles.txt";
        public static Form f;
        public static void ShowWithAnim(Form frm)
        {
            f = frm;
            Timer tmrShow = new Timer() { Interval = 5 };
            tmrShow.Tick += tmrShow_Tick;
            tmrShow.Start();
        }

        public static void CloseWithAnim(Form frm)
        {
            f = frm;
            Timer tmrClose = new Timer() { Interval = 5 };
            tmrClose.Tick += tmrClose_Tick;
            tmrClose.Start();
        }

        static void tmrClose_Tick(object sender, EventArgs e)
        {
            f.Opacity -= 0.05;
            if (f.Opacity == 0)
                f.Close();
        }

        static void tmrShow_Tick(object sender, EventArgs e)
        {
            f.Opacity += 0.05;
            if (f.Opacity == 1)
                ((Timer)sender).Stop();
        }

    }
}
