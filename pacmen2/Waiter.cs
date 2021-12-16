using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PacmanGame
{
    public partial class Waiter : UserControl
    {
        private Image ImageStar = Image.FromFile(Application.StartupPath + "\\images\\PacmenToWaiter.png");
        private Image ImageEnemy = Image.FromFile(Application.StartupPath + "\\images\\enemy.png");
        Timer TimerClose = new Timer() { Interval = 900 };
        int Rotation = 0;
        int times = 0;

        public Waiter()
        {
            InitializeComponent();
            TimerClose.Tick += TimerClose_Tick;
            TimerClose.Start();
        }

        public void ResetWaiter()
        {
            TimerClose.Interval = 900;
            Rotation = 0;
            times = 0;
            TimerClose.Start();
        }

        void TimerClose_Tick(object sender, EventArgs e)
        {
            switch (TimerClose.Interval)
            {
                case 25:
                    this.Visible = true;
                    Pic1.Invalidate();
                    if (++Rotation == 56)
                        TimerClose.Interval = 500;
                    break;
                case 900:
                    TimerClose.Interval = 25;
                    break;
                case 500:
                    this.Visible = false;
                    TimerClose.Stop();
                    break;
            }
        }

        private void Pic1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(ImageEnemy, (times * 3) - 32, 20);
            e.Graphics.DrawImage(ImageStar, 300 - (times * 3), 60);
            times++;
        }
    }
}