namespace PacmanGame
{
    partial class FrmNewUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnQuit = new System.Windows.Forms.Button();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbLangs = new System.Windows.Forms.ComboBox();
            this.CmbGender = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.ChbPassword = new System.Windows.Forms.CheckBox();
            this.BtnShowPassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Guttman Kav", 14F);
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(78, 130);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(271, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "הכנס בבקשה את שמך";
            // 
            // BtnStart
            // 
            this.BtnStart.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnStart.Enabled = false;
            this.BtnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.BtnStart.ForeColor = System.Drawing.Color.Coral;
            this.BtnStart.Location = new System.Drawing.Point(149, 406);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(90, 40);
            this.BtnStart.TabIndex = 6;
            this.BtnStart.Text = "התחל";
            this.BtnStart.UseVisualStyleBackColor = true;
            // 
            // BtnQuit
            // 
            this.BtnQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.BtnQuit.ForeColor = System.Drawing.Color.Coral;
            this.BtnQuit.Location = new System.Drawing.Point(53, 406);
            this.BtnQuit.Name = "BtnQuit";
            this.BtnQuit.Size = new System.Drawing.Size(90, 40);
            this.BtnQuit.TabIndex = 7;
            this.BtnQuit.Text = "יציאה";
            this.BtnQuit.UseVisualStyleBackColor = true;
            this.BtnQuit.Click += new System.EventHandler(this.BtnQuit_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(396, 485);
            this.shapeContainer1.TabIndex = 4;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BorderColor = System.Drawing.Color.SteelBlue;
            this.rectangleShape1.BorderWidth = 10;
            this.rectangleShape1.Location = new System.Drawing.Point(1, 1);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(393, 482);
            // 
            // TxtName
            // 
            this.TxtName.BackColor = System.Drawing.SystemColors.Info;
            this.TxtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.TxtName.ForeColor = System.Drawing.Color.Maroon;
            this.TxtName.Location = new System.Drawing.Point(53, 155);
            this.TxtName.MaximumSize = new System.Drawing.Size(290, 33);
            this.TxtName.MaxLength = 20;
            this.TxtName.Name = "TxtName";
            this.TxtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtName.Size = new System.Drawing.Size(290, 23);
            this.TxtName.TabIndex = 0;
            this.TxtName.TextChanged += new System.EventHandler(this.TxtName_TextChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Guttman Kav", 14F);
            this.label2.ForeColor = System.Drawing.Color.Coral;
            this.label2.Location = new System.Drawing.Point(222, 193);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(127, 27);
            this.label2.TabIndex = 5;
            this.label2.Text = "בחר שפה";
            // 
            // CmbLangs
            // 
            this.CmbLangs.ForeColor = System.Drawing.Color.Maroon;
            this.CmbLangs.FormattingEnabled = true;
            this.CmbLangs.Items.AddRange(new object[] {
            "עברית",
            "english"});
            this.CmbLangs.Location = new System.Drawing.Point(222, 218);
            this.CmbLangs.Name = "CmbLangs";
            this.CmbLangs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CmbLangs.Size = new System.Drawing.Size(121, 21);
            this.CmbLangs.TabIndex = 1;
            this.CmbLangs.Text = "עברית";
            // 
            // CmbGender
            // 
            this.CmbGender.ForeColor = System.Drawing.Color.Maroon;
            this.CmbGender.FormattingEnabled = true;
            this.CmbGender.Items.AddRange(new object[] {
            "זכר",
            "נקבה"});
            this.CmbGender.Location = new System.Drawing.Point(223, 278);
            this.CmbGender.Name = "CmbGender";
            this.CmbGender.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CmbGender.Size = new System.Drawing.Size(121, 21);
            this.CmbGender.TabIndex = 2;
            this.CmbGender.Text = "זכר";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Guttman Kav", 14F);
            this.label3.ForeColor = System.Drawing.Color.Coral;
            this.label3.Location = new System.Drawing.Point(222, 254);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(127, 27);
            this.label3.TabIndex = 8;
            this.label3.Text = "בחר מין";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Guttman Kav", 28F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(53, 46);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(290, 41);
            this.label4.TabIndex = 9;
            this.label4.Text = "ברוך הבא לפקמן!";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TxtPassword
            // 
            this.TxtPassword.BackColor = System.Drawing.SystemColors.Info;
            this.TxtPassword.Enabled = false;
            this.TxtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.TxtPassword.ForeColor = System.Drawing.Color.Maroon;
            this.TxtPassword.Location = new System.Drawing.Point(96, 356);
            this.TxtPassword.MaximumSize = new System.Drawing.Size(290, 33);
            this.TxtPassword.MaxLength = 10;
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtPassword.Size = new System.Drawing.Size(249, 23);
            this.TxtPassword.TabIndex = 4;
            this.TxtPassword.UseSystemPasswordChar = true;
            // 
            // ChbPassword
            // 
            this.ChbPassword.AutoSize = true;
            this.ChbPassword.Font = new System.Drawing.Font("Guttman Kav", 14F);
            this.ChbPassword.ForeColor = System.Drawing.Color.Coral;
            this.ChbPassword.Location = new System.Drawing.Point(225, 328);
            this.ChbPassword.Name = "ChbPassword";
            this.ChbPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChbPassword.Size = new System.Drawing.Size(118, 28);
            this.ChbPassword.TabIndex = 3;
            this.ChbPassword.Text = "בחר סיסמא";
            this.ChbPassword.UseVisualStyleBackColor = true;
            this.ChbPassword.CheckedChanged += new System.EventHandler(this.ChbPassword_CheckedChanged);
            // 
            // BtnShowPassword
            // 
            this.BtnShowPassword.Enabled = false;
            this.BtnShowPassword.Image = global::PacmanGame.Properties.Resources.a;
            this.BtnShowPassword.Location = new System.Drawing.Point(53, 356);
            this.BtnShowPassword.Name = "BtnShowPassword";
            this.BtnShowPassword.Size = new System.Drawing.Size(37, 23);
            this.BtnShowPassword.TabIndex = 5;
            this.BtnShowPassword.Tag = "";
            this.BtnShowPassword.UseVisualStyleBackColor = true;
            this.BtnShowPassword.Click += new System.EventHandler(this.BtnShowPassword_Click);
            // 
            // FrmNewUser
            // 
            this.AcceptButton = this.BtnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(396, 485);
            this.Controls.Add(this.BtnShowPassword);
            this.Controls.Add(this.ChbPassword);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbGender);
            this.Controls.Add(this.CmbLangs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.BtnQuit);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNewUser";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnQuit;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        public  System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox CmbLangs;
        public System.Windows.Forms.ComboBox CmbGender;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.CheckBox ChbPassword;
        private System.Windows.Forms.Button BtnShowPassword;

    }
}