namespace PacmanGame
{
    partial class FrmPause
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
            this.BtnContinue = new System.Windows.Forms.Button();
            this.BtnToMainMenu = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.BtnSaveGame = new System.Windows.Forms.Button();
            this.BtnLoadGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Guttman Kav", 24F);
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(26, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "?מה ברצונך לעשות";
            // 
            // BtnContinue
            // 
            this.BtnContinue.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.BtnContinue.ForeColor = System.Drawing.Color.Coral;
            this.BtnContinue.Location = new System.Drawing.Point(67, 105);
            this.BtnContinue.Name = "BtnContinue";
            this.BtnContinue.Size = new System.Drawing.Size(180, 40);
            this.BtnContinue.TabIndex = 0;
            this.BtnContinue.Text = "המשך";
            this.BtnContinue.UseVisualStyleBackColor = true;
            // 
            // BtnToMainMenu
            // 
            this.BtnToMainMenu.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnToMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.BtnToMainMenu.ForeColor = System.Drawing.Color.Coral;
            this.BtnToMainMenu.Location = new System.Drawing.Point(67, 288);
            this.BtnToMainMenu.Name = "BtnToMainMenu";
            this.BtnToMainMenu.Size = new System.Drawing.Size(180, 40);
            this.BtnToMainMenu.TabIndex = 3;
            this.BtnToMainMenu.Text = "חזור לתפריט הראשי";
            this.BtnToMainMenu.UseVisualStyleBackColor = true;
            // 
            // BtnExit
            // 
            this.BtnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.BtnExit.ForeColor = System.Drawing.Color.Coral;
            this.BtnExit.Location = new System.Drawing.Point(67, 349);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(180, 40);
            this.BtnExit.TabIndex = 4;
            this.BtnExit.Text = "יציאה";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(322, 433);
            this.shapeContainer1.TabIndex = 4;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BorderColor = System.Drawing.Color.SteelBlue;
            this.rectangleShape1.BorderWidth = 10;
            this.rectangleShape1.Location = new System.Drawing.Point(1, 1);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(320, 432);
            // 
            // BtnSaveGame
            // 
            this.BtnSaveGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.BtnSaveGame.ForeColor = System.Drawing.Color.Coral;
            this.BtnSaveGame.Location = new System.Drawing.Point(67, 166);
            this.BtnSaveGame.Name = "BtnSaveGame";
            this.BtnSaveGame.Size = new System.Drawing.Size(180, 40);
            this.BtnSaveGame.TabIndex = 1;
            this.BtnSaveGame.Text = "שמור משחק";
            this.BtnSaveGame.UseVisualStyleBackColor = true;
            this.BtnSaveGame.Click += new System.EventHandler(this.BtnSaveGame_Click);
            // 
            // BtnLoadGame
            // 
            this.BtnLoadGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.BtnLoadGame.ForeColor = System.Drawing.Color.Coral;
            this.BtnLoadGame.Location = new System.Drawing.Point(67, 227);
            this.BtnLoadGame.Name = "BtnLoadGame";
            this.BtnLoadGame.Size = new System.Drawing.Size(180, 40);
            this.BtnLoadGame.TabIndex = 2;
            this.BtnLoadGame.Text = "קרא משחק";
            this.BtnLoadGame.UseVisualStyleBackColor = true;
            this.BtnLoadGame.Click += new System.EventHandler(this.BtnLoadGame_Click);
            // 
            // FrmPause
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(322, 433);
            this.Controls.Add(this.BtnLoadGame);
            this.Controls.Add(this.BtnSaveGame);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnToMainMenu);
            this.Controls.Add(this.BtnContinue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPause";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnContinue;
        private System.Windows.Forms.Button BtnToMainMenu;
        private System.Windows.Forms.Button BtnExit;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.Button BtnSaveGame;
        private System.Windows.Forms.Button BtnLoadGame;


    }
}