namespace PacmanGame
{
    partial class games
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
            this.BtnOne = new System.Windows.Forms.Button();
            this.Btn2 = new System.Windows.Forms.Button();
            this.BtnThree = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Guttman Kav", 24F);
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(82, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 41);
            this.label1.TabIndex = 6;
            this.label1.Text = "בחר משחק";
            // 
            // BtnOne
            // 
            this.BtnOne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(222)))));
            this.BtnOne.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnOne.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.BtnOne.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BtnOne.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BtnOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.BtnOne.ForeColor = System.Drawing.Color.Blue;
            this.BtnOne.Location = new System.Drawing.Point(73, 145);
            this.BtnOne.Name = "BtnOne";
            this.BtnOne.Size = new System.Drawing.Size(178, 35);
            this.BtnOne.TabIndex = 8;
            this.BtnOne.Tag = "1";
            this.BtnOne.Text = "משחק 1";
            this.BtnOne.UseVisualStyleBackColor = false;
            this.BtnOne.Click += new System.EventHandler(this.BtnOne_Click);
            // 
            // Btn2
            // 
            this.Btn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(222)))));
            this.Btn2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Btn2.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.Btn2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(170)))));
            this.Btn2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.Btn2.ForeColor = System.Drawing.Color.Blue;
            this.Btn2.Location = new System.Drawing.Point(73, 213);
            this.Btn2.Name = "Btn2";
            this.Btn2.Size = new System.Drawing.Size(178, 35);
            this.Btn2.TabIndex = 9;
            this.Btn2.Tag = "2";
            this.Btn2.Text = "משחק 2";
            this.Btn2.UseVisualStyleBackColor = false;
            // 
            // BtnThree
            // 
            this.BtnThree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(222)))));
            this.BtnThree.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnThree.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.BtnThree.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(170)))));
            this.BtnThree.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BtnThree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnThree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.BtnThree.ForeColor = System.Drawing.Color.Blue;
            this.BtnThree.Location = new System.Drawing.Point(73, 281);
            this.BtnThree.Name = "BtnThree";
            this.BtnThree.Size = new System.Drawing.Size(178, 35);
            this.BtnThree.TabIndex = 10;
            this.BtnThree.Tag = "3";
            this.BtnThree.Text = "משחק 3";
            this.BtnThree.UseVisualStyleBackColor = false;
            // 
            // games
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 376);
            this.Controls.Add(this.BtnThree);
            this.Controls.Add(this.Btn2);
            this.Controls.Add(this.BtnOne);
            this.Controls.Add(this.label1);
            this.Name = "games";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "games";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnOne;
        private System.Windows.Forms.Button Btn2;
        private System.Windows.Forms.Button BtnThree;
    }
}