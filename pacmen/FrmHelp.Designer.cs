namespace PacmanGame
{
    partial class FrmHelp
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
            this.TlpMy = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnBack = new System.Windows.Forms.Button();
            this.TlpMy.SuspendLayout();
            this.SuspendLayout();
            // 
            // TlpMy
            // 
            this.TlpMy.ColumnCount = 3;
            this.TlpMy.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TlpMy.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlpMy.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TlpMy.Controls.Add(this.label1, 1, 1);
            this.TlpMy.Controls.Add(this.label2, 1, 2);
            this.TlpMy.Controls.Add(this.BtnBack, 2, 0);
            this.TlpMy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpMy.Location = new System.Drawing.Point(0, 0);
            this.TlpMy.Name = "TlpMy";
            this.TlpMy.RowCount = 3;
            this.TlpMy.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TlpMy.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TlpMy.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.TlpMy.Size = new System.Drawing.Size(506, 384);
            this.TlpMy.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 84F);
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(129, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 76);
            this.label1.TabIndex = 1;
            this.label1.Text = "עזרה";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(129, 133);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(247, 251);
            this.label2.TabIndex = 2;
            this.label2.Text = "- כדי להניע את הפקמן השתמשו בחיצים.\n- כדי לשבור את האבנים האפורות, יש להניח פצצה " +
    "בקרבת האבן ע\"י הקשה על רווח.";
            // 
            // BtnBack
            // 
            this.BtnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBack.BackgroundImage = global::PacmanGame.Properties.Resources.right;
            this.BtnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnBack.Location = new System.Drawing.Point(453, 3);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(50, 50);
            this.BtnBack.TabIndex = 0;
            this.BtnBack.UseVisualStyleBackColor = true;
            // 
            // FrmHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 384);
            this.Controls.Add(this.TlpMy);
            this.Name = "FrmHelp";
            this.Text = "Form2";
            this.TlpMy.ResumeLayout(false);
            this.TlpMy.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        public System.Windows.Forms.TableLayoutPanel TlpMy;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}