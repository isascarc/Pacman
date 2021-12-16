using System;
using System.Windows.Forms;

namespace PacmanGame
{
    public partial class FrmNewUser : Form
    {
        public FrmNewUser()
        {
            InitializeComponent();
            MyForms.ShowWithAnim(this);
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo(1037));
            CmbLangs.SelectedValue = 0;
            TxtName.Focus();
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            MyForms.CloseWithAnim(this);
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            if (TxtName.Text.Trim() != "")
                BtnStart.Enabled = true;
            else
                BtnStart.Enabled = false;
        }

        private void ChbPassword_CheckedChanged(object sender, EventArgs e)
        {
            TxtPassword.Enabled = ChbPassword.Checked;
            BtnShowPassword.Enabled = ChbPassword.Checked;
        }

        private void BtnShowPassword_Click(object sender, EventArgs e)
        {
            if (TxtPassword.UseSystemPasswordChar)
            {
                TxtPassword.UseSystemPasswordChar = false;
                BtnShowPassword.Image = PacmanGame.Properties.Resources.b;
            }
            else
            {
                TxtPassword.UseSystemPasswordChar = true;
                BtnShowPassword.Image = PacmanGame.Properties.Resources.a;
            }
        }
    }
}