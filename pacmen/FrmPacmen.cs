using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace PacmanGame
{
    public partial class FrmPacmen : Form
    {
        #region load files
        //Declare variables of board
        private Pacman pacman;
        private List<Enemy> enemys = new List<Enemy>();
        private int foods;
        private ImageToDraw[,] ListOfData1;
        //Declare & load icons and sounds
        const string PathImages = "images\\";
        const string PathSound = "sounds\\";
        private Image IconBlock = Image.FromFile(PathImages+"block.png");
        private Image IconBlockTemp = Image.FromFile(PathImages + "block temp.png");
        private Image Iconfooder = Image.FromFile(PathImages + "star.png");
        private Image IconStar = Image.FromFile(PathImages + "bool.png");
        private Image IconPacmenR = Image.FromFile(PathImages + "right.png");
        private Image IconPacmenD = Image.FromFile(PathImages + "down.png");
        private Image IconPacmenL = Image.FromFile(PathImages + "left.png");
        private Image IconPacmenU = Image.FromFile(PathImages + "up.png");
        private Image IconKey = Image.FromFile(PathImages + "key.png");
        private Image IconDollar = Image.FromFile(PathImages + "dollar.png");
        private Image IconEnemy = Image.FromFile(PathImages + "enemy.png");
        private Image IconEnemy2 = Image.FromFile(PathImages + "enemy2.png");
        private Image IconBoom = Image.FromFile(PathImages + "boom.png");
        private System.Media.SoundPlayer SowndFoofing = new System.Media.SoundPlayer(PathSound+"food.wav");
        //declare timers & more components
        private Timer PaintTimer = new Timer() { Interval = 50 };
        private Timer FooderTimer = new Timer() { Interval = 1000 };
        FrmPause Pauser;
        Size SizeScreen;
        List<TimerBoom> MyTimers = new List<TimerBoom>();
        List<Point> p = new List<Point>();
        bool HOver = false;
        bool WOver = false;
        Timer TmrMoveCanvas = new Timer() { Interval = 5, Tag = 0 };
        int CounterIterations = 0;
        #endregion
        
        [DllImport("winmm.dll")]
        public static extern uint mciSendString(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, IntPtr hWndCallback);

        public FrmPacmen()
        {
            BuildClearBoard();
        }

       
        private void BuildClearBoard()
        {
            MyForms.ShowWithAnim(this);
            InitializeComponent();
            this.waiter1 = new Waiter();
            this.Controls.Add(this.waiter1);
            // Init events for timers and waiter
            PaintTimer.Tick += MovePlayer;
            FooderTimer.Tick += FooderTimer_Tick;
            waiter1.VisibleChanged += Waiter_VisibleChanged;
            TmrMoveCanvas.Tick += TmrMoveCanvas_Tick;
            // Init board
            SizeScreen =  new Microsoft.VisualBasic.Devices.Computer().Screen.Bounds.Size;
            waiter1.Location = new Point((SizeScreen.Width / 2) - (waiter1.Width / 2), (SizeScreen.Height / 2) - (waiter1.Height / 2));
        }
        public FrmPacmen(string level, string Lives, string Score)
        {
            BuildClearBoard();
            LblLevel.Text = level;
            lblLives.Text = Lives;
            lblScore.Text = Score;
        }

        void TmrMoveCanvas_Tick(object sender, EventArgs e)
        {
            switch ((int)((Timer)sender).Tag)
            {
                case 1:
                    pbCanvas.Left -= 10;
                    break;
                case 2:
                    pbCanvas.Top += 10;
                    break;
                case 3:
                    pbCanvas.Left += 10;
                    break;
                case 4:
                    pbCanvas.Top -= 10;
                    break;
            }
            if (--CounterIterations < 1)
            {
                ((Timer)sender).Stop();
                PaintTimer.Start();
            }
        }

        void ResetAllGame()
        {
            this.SuspendLayout();
            this.Controls.Clear();
            InitializeComponent();
            this.ResumeLayout();
            waiter1 = new Waiter() { Location = new Point((SizeScreen.Width / 2) - (waiter1.Width / 2), (SizeScreen.Height / 2) - (waiter1.Height / 2)) };
            this.Controls.Add(this.waiter1);
            waiter1.VisibleChanged += Waiter_VisibleChanged;
            // tofix: add stop music.
            //reset the pacmen, and all other objects of the board, and build board.
            foods = 0;
            PaintTimer.Interval = 75;
            pacman = new Pacman();
            enemys.Clear();
            BuildBoard();
        }

        void Waiter_VisibleChanged(object sender, EventArgs e)
        {
            //if waiter load: the board builded in this time; if waiter hide: game showed and started.
            if (waiter1.Visible == false)
            {
                // start play music
                if (Settings.profiles[Settings.AP].PlayMusic)
                {
                    mciSendString(@"open """ + Application.StartupPath + @"\\sounds\\music.mp3"" alias temp_alias", null, 0, IntPtr.Zero);
                    mciSendString("play temp_alias repeat", null, 0, IntPtr.Zero);
                }
                pbCanvas.Show();
                PaintTimer.Start();
                this.Focus();
            }
            else
                BuildBoard();
        }

        private void BuildBoard()
        {
            char[] chars = Properties.Resources.ResourceManager.GetString("level" + LblLevel.Text).ToCharArray();
            ListOfData1 = new ImageToDraw[Array.IndexOf(chars, '\r') + 1, Array.FindAll(chars, NumberOfLines).Length + 1];
            int r = 0, c = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                switch (chars[i])
                {
                    case '1':                                           //load blocks
                        ListOfData1[c, r] = ImageToDraw.block;
                        c++;
                        break;
                    case '0':                                           // load foods
                        ListOfData1[c, r] = ImageToDraw.food;
                        foods++;
                        c++;
                        break;
                    case 'p':                                           // load pacmen
                        ListOfData1[c, r] = ImageToDraw.pacman;
                        pacman = new Pacman { X = c, Y = r, OrginalX = c, OrginalY = r };
                        c++;
                        break;
                    case 'e':                                           // load enemys
                        enemys.Add(new Enemy { X = c, Y = r, OrginalX = c, OrginalY = r });
                        ListOfData1[c, r] = ImageToDraw.food;
                        foods++;
                        c++;
                        break;
                    case 't':                                           // load blocks temporary
                        ListOfData1[c, r] = ImageToDraw.blockTemp;
                        c++;
                        break;
                    case '*':                                           // load fooders
                        ListOfData1[c, r] = ImageToDraw.killer;
                        c++;
                        break;
                    case 'd':
                        ListOfData1[c, r] = ImageToDraw.dollar;
                        c++;
                        break;
                    case '\r':                                          // start new line
                        c = 0;
                        r++;
                        break;
                }
            }
            pbCanvas.Size = new Size { Height = (r + 1) * 40, Width = c * 40 };
            pbCanvas.Top = (SizeScreen.Height / 2) - (pbCanvas.Height / 2);
            pbCanvas.Left = (SizeScreen.Width / 2) - (pbCanvas.Width / 2);
            pacman.ChelkeyDirections[0] = 4;
            pacman.ChelkeyDirections[1] = 4;
            // 
            HOver = SizeScreen.Height < pbCanvas.Height;
            WOver=SizeScreen.Width < pbCanvas.Width;
        }

        private void FooderTimer_Tick(object sender, EventArgs e)
        {
            LblTime.Text = (int.Parse(LblTime.Text) - 1).ToString();
            LblTime.Visible = true;
            if (LblTime.Text == "0")
            {
                PicFooder.Visible = false;
                LblTime.Visible = false;
                FooderTimer.Stop();
            }
        }

        private void NextLevel()
        {
            PaintTimer.Stop();
            FooderTimer.Stop();
            ClearBooms();
            if (Settings.profiles[Settings.AP].PlaySound)
            {
                mciSendString(@"open """ + Application.StartupPath + @"\\sounds\\win.mp3"" alias winner", null, 0, IntPtr.Zero);
                mciSendString("play winner", null, 0, IntPtr.Zero);
            }
            pbCanvas.Hide();
            PaintTimer.Interval -= 5;
            LblLevel.Text = (int.Parse(LblLevel.Text) + 1).ToString();
            //reset all data
            pacman = new Pacman();
            enemys.Clear();
            PicFooder.Visible = false;
            LblTime.Visible = false;
            // reset and show waiter, and start build board
            waiter1.ResetWaiter();
            waiter1.Visible = true;
        }

        /// <summary>
        /// shut doun all timers of booms, and clear all components.
        /// </summary>
        private void ClearBooms()
        {
            for (int i = 0; i < MyTimers.Count; i++)
            {
                MyTimers[i].Boomer.Stop();
                MyTimers[i].ClearBoomer.Stop();
            }
                MyTimers.Clear();
        }

        private void DownLive()
        {
            // GameOver
            if (lblLives.Text == "0")
            {
                if (Settings.profiles[Settings.AP].PlaySound)
                    System.Media.SystemSounds.Exclamation.Play();
                EndGame();
            }
            //The game continue
            else
            {
                if (Settings.profiles[Settings.AP].PlaySound)
                    System.Media.SystemSounds.Beep.Play();
                PaintTimer.Stop();
                ClearBooms();
                MessageBox.Show("לא נורא, נותרו לך עוד " + lblLives.Text + " פסילות");
                lblLives.Text = (int.Parse(lblLives.Text) - 1).ToString();
                pacman.X = pacman.OrginalX;
                pacman.Y = pacman.OrginalY;
                pacman.direction = Direction.Left;
                pacman.ChelkeyDirections[0] = 4;
                pacman.ChelkeyDirections[1] = 4;
                //Reset all enemys to settings orginals, and start game.
                for (int i = 0; i < enemys.Count; i++)
                {
                    enemys[i].X = enemys[i].OrginalX;
                    enemys[i].Y = enemys[i].OrginalY;
                    enemys[i].ChelkeyX = 4;
                    enemys[i].ChelkeyY = 4;
                    enemys[i].Dead = false;
                }
                PaintTimer.Start();
            }
        }

        private void EndGame()
        {
            PaintTimer.Stop();                                                   //break timers
            FooderTimer.Stop();
            ClearBooms();
            bool NewHighScore = false;
            if (int.Parse(Settings.profiles[Settings.AP].HighLevel) < int.Parse(LblLevel.Text))
            {
                Settings.profiles[Settings.AP].HighLevel = LblLevel.Text;
                string[] lines = System.IO.File.ReadAllLines(MyForms.PathProfiles);
                lines[Settings.AP] = Settings.ReturnLine(Settings.AP);
                System.IO.File.WriteAllLines(MyForms.PathProfiles, lines);
            }
            for (int i = 0; i < 3; i++)
            {
                //update file & profile, if score > 
                if (int.Parse(lblScore.Text) > int.Parse(Settings.profiles[Settings.AP].HighScore[i]))
                {
                    string[] lines = System.IO.File.ReadAllLines(MyForms.PathProfiles);
                    int x = 2;
                    while (x > i)
                    {
                        Settings.profiles[Settings.AP].HighScore[x] = Settings.profiles[Settings.AP].HighScore[x - 1];
                        x--;
                    }
                    Settings.profiles[Settings.AP].HighScore[i] = lblScore.Text;
                    lines[Settings.AP] = Settings.ReturnLine(Settings.AP);
                    System.IO.File.WriteAllLines(MyForms.PathProfiles, lines);
                    NewHighScore = true;
                    break;
                }
            }
            FrmSummery sum = new FrmSummery(lblScore.Text, NewHighScore);
            if (sum.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                PaintTimer.Stop();
                FooderTimer.Stop();
                ClearBooms();
                foods = 0;
                ResetAllGame();
            }
            else
                this.Close();
        }
        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (pacman.direction != Direction.Right)
                        pacman.DirectionWant = Direction.Right;
                    break;
                case Keys.Left:
                    if (pacman.direction != Direction.Left)
                        pacman.DirectionWant = Direction.Left;
                    break;
                case Keys.Up:
                    if (pacman.direction != Direction.Up)
                        pacman.DirectionWant = Direction.Up;
                    break;
                case Keys.Down:
                    if (pacman.direction != Direction.Down)
                        pacman.DirectionWant = Direction.Down;
                    break;
                // create boomer
                case Keys.Space:
                    if (int.Parse(lblScore.Text) >= 500)
                    {
                        ListOfData1[pacman.X, pacman.Y] = ImageToDraw.boomer;
                        MyTimers.Add(new TimerBoom()
                        {
                            Boomer = new Timer() { Tag = MyTimers.Count, Interval = 3000 },
                            ClearBoomer = new Timer() { Tag = MyTimers.Count, Interval = 1000 },
                            LocBoom = new Locaton { X = pacman.X, Y = pacman.Y }
                        });
                        MyTimers[MyTimers.Count - 1].Boomer.Tick += Boomer_Tick;
                        MyTimers[MyTimers.Count - 1].ClearBoomer.Tick += ClearBoomer_Tick;
                        MyTimers[MyTimers.Count - 1].Boomer.Start();
                        lblScore.Text = (int.Parse(lblScore.Text) - 500).ToString();
                    }
                    break;
                // pause mode
                case Keys.Escape:
                    PaintTimer.Stop();
                    Pauser = new FrmPause(int.Parse(LblLevel.Text), int.Parse(lblLives.Text), int.Parse(lblScore.Text));
                    DialogResult res = Pauser.ShowDialog();
                    if (res == System.Windows.Forms.DialogResult.Cancel)
                        PaintTimer.Start();
                    else if (res == DialogResult.OK)
                        this.Close();
                    break;
            }
        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            for (int X = 0; X < ListOfData1.GetUpperBound(0); X++)
            {
                for (int Y = 0; Y <= ListOfData1.GetUpperBound(1); Y++)
                {
                    switch (ListOfData1[X, Y])
                    {
                        case ImageToDraw.block:
                            canvas.DrawImage(IconBlock, X * 40, Y * 40, 40, 40);
                            break;
                        case ImageToDraw.food:
                            canvas.DrawImage(IconStar, X * 40 + 12, Y * 40 + 12, 15, 15);
                            break;
                        case ImageToDraw.killer:
                            canvas.DrawImage(Iconfooder, new Rectangle(X * 40 + 5, Y * 40 + 5, 30, 30));
                            break;
                        case ImageToDraw.key:
                            canvas.DrawImage(IconKey, X * 40 + 10, Y * 40 + 2,20,36);
                            break;
                        case ImageToDraw.dollar:
                            canvas.DrawImage(IconDollar, new Rectangle(X * 40 + 5, Y * 40 + 5, 30, 30));
                            break;
                        case ImageToDraw.blockTemp:
                            canvas.DrawImage(IconBlockTemp, new Rectangle(X * 40, Y * 40, 40, 40));
                            break;
                        case ImageToDraw.boom:
                            canvas.DrawImage(IconBoom, new Rectangle(X * 40 + 10, Y * 40 + 10, 20, 20));
                            break;
                        case ImageToDraw.boomer:
                            canvas.DrawImage(IconBoom, new Rectangle((X * 40) + 5, (Y * 40) + 5, 30, 30));
                            break;
                    }
                }
            }
            switch (pacman.direction)
            {
                case Direction.Down:
                    canvas.DrawImage(IconPacmenD, new Rectangle((pacman.X * 40) + ((pacman.ChelkeyDirections[0] - 4) * 10), (pacman.Y * 40) + ((pacman.ChelkeyDirections[1] - 4) * 10), 40, 40));
                    break;
                case Direction.Left:
                    canvas.DrawImage(IconPacmenL, new Rectangle((pacman.X * 40) + ((pacman.ChelkeyDirections[0] - 4) * 10), (pacman.Y * 40) + ((pacman.ChelkeyDirections[1] - 4) * 10), 40, 40));
                    break;
                case Direction.Right:
                    canvas.DrawImage(IconPacmenR, new Rectangle((pacman.X * 40) + ((pacman.ChelkeyDirections[0] - 4) * 10), (pacman.Y * 40) + ((pacman.ChelkeyDirections[1] - 4) * 10), 40, 40));
                    break;
                case Direction.Up:
                    canvas.DrawImage(IconPacmenU, new Rectangle((pacman.X * 40) + ((pacman.ChelkeyDirections[0] - 4) * 10), (pacman.Y * 40) + ((pacman.ChelkeyDirections[1] - 4) * 10), 40, 40));
                    break;
            }
            // draw enemys
            for (int i = 0; i < enemys.Count; i++)
            {
                if (enemys[i] != null && !enemys[i].Dead)
                    canvas.DrawImage(PicFooder.Visible ? IconEnemy2 : IconEnemy, new Rectangle((enemys[i].X * 40) + ((enemys[i].ChelkeyX - 4) * 10) + 5, (enemys[i].Y * 40) + ((enemys[i].ChelkeyY - 4) * 10) + 5, 30, 30));
            }
        }

        private void MovePlayer(object sender, EventArgs e)
        {
            //move pacmen
            if (pacman.DirectionWant == null)
                GoPacmen(pacman.direction, false);
            else
                if (!GoPacmen((Direction)pacman.DirectionWant, true))
                    GoPacmen(pacman.direction, false);
            //check die
            int PacX = (pacman.X * 4) + (pacman.ChelkeyDirections[0] - 4);
            int PacY = (pacman.Y * 4) + (pacman.ChelkeyDirections[1] - 4);
            for (int i = 0; i < enemys.Count; i++)
            {
                if (enemys[i] != null && !enemys[i].Dead)
                {
                    int i1 = ((enemys[i].X * 4) + (enemys[i].ChelkeyX - 4)) - PacX;
                    int i2 = ((enemys[i].Y * 4) + (enemys[i].ChelkeyY - 4)) - PacY;
                    if (i1 > -3 && i1 < 3 && i2 > -3 && i2 < 3)
                        if (PicFooder.Visible == false)
                        {
                            DownLive();
                            break;
                        }
                        else
                        {
                            if (Settings.profiles[Settings.AP].PlaySound)
                                SowndFoofing.Play();
                            enemys[i].Dead = true;
                            lblScore.Text = (int.Parse(lblScore.Text) + 500).ToString();
                        }
                }
            }
            //check die's enemy by boomer
            for (int i = 0; i < enemys.Count; i++)
                if (ListOfData1[enemys[i].X, enemys[i].Y] == ImageToDraw.boom)
                    enemys[i].Dead = true;

            //move enemys
            Random rand = new Random();
            for (int i = 0; i < enemys.Count; i++)
            {
                if (enemys[i] != null && !enemys[i].Dead)
                {
                    if ((int)ListOfData1[enemys[i].X, enemys[i].Y - 1] > 3 && enemys[i].ChelkeyX == 4)
                        enemys[i].OptionalDirections.Add(Direction.Up);
                    if ((int)ListOfData1[enemys[i].X, enemys[i].Y + 1] > 3 && enemys[i].ChelkeyX == 4)
                        enemys[i].OptionalDirections.Add(Direction.Down);
                    if ((int)ListOfData1[enemys[i].X + 1, enemys[i].Y] > 3 && enemys[i].ChelkeyY == 4)
                        enemys[i].OptionalDirections.Add(Direction.Right);
                    if ((int)ListOfData1[enemys[i].X - 1, enemys[i].Y] > 3 && enemys[i].ChelkeyY == 4)
                        enemys[i].OptionalDirections.Add(Direction.Left);
                    // if the enemy possibly to go in orginal direction: done, else: rand all other directions, and go to selected.
                    if (enemys[i].OptionalDirections.Count > 0)
                    {
                        Direction d = (int)enemys[i].direction % 2 == 0 ? (Direction)((int)enemys[i].direction) + 1 : (Direction)((int)enemys[i].direction) - 1;
                        if (enemys[i].OptionalDirections.Contains(d) && enemys[i].OptionalDirections.Contains(enemys[i].direction))
                            enemys[i].OptionalDirections.Remove(d);
                        enemys[i].direction = enemys[i].OptionalDirections[rand.Next(0, enemys[i].OptionalDirections.Count)];
                        enemys[i].OptionalDirections.Clear();
                        switch (enemys[i].direction)
                        {
                            case Direction.Right:
                                {
                                    enemys[i].ChelkeyX++;
                                    if (enemys[i].ChelkeyX == 8)
                                    {
                                        enemys[i].X++;
                                        enemys[i].ChelkeyX = 4;
                                    }
                                }
                                break;
                            case Direction.Left:
                                {
                                    enemys[i].ChelkeyX--;
                                    if (enemys[i].ChelkeyX == 0)
                                    {
                                        enemys[i].X--;
                                        enemys[i].ChelkeyX = 4;
                                    }
                                }
                                break;
                            case Direction.Up:
                                {
                                    enemys[i].ChelkeyY--;
                                    if (enemys[i].ChelkeyY == 0)
                                    {
                                        enemys[i].Y--;
                                        enemys[i].ChelkeyY = 4;
                                    }
                                }
                                break;
                            case Direction.Down:
                                {
                                    enemys[i].ChelkeyY++;
                                    if (enemys[i].ChelkeyY == 8)
                                    {
                                        enemys[i].Y++;
                                        enemys[i].ChelkeyY = 4;
                                    }
                                }
                                break;
                        }
                    }
                }
            }
            //fooding food
            if (ListOfData1[pacman.X, pacman.Y] == ImageToDraw.food)
            {
                ListOfData1[pacman.X, pacman.Y] = ImageToDraw.empty;
                lblScore.Text = (int.Parse(lblScore.Text) + 100).ToString();
                foods--;
                if (Int32.Parse(lblScore.Text) % 10000 == 0)
                    lblLives.Text = (Int32.Parse(lblLives.Text) + 1).ToString();
                if (foods == 0)
                {
                    Point r = GenerateRandomLocation();
                    ListOfData1[r.X, r.Y] = ImageToDraw.key;
                }
            }
            // fooding dollar
            else if (ListOfData1[pacman.X, pacman.Y] == ImageToDraw.dollar)
            {
                ListOfData1[pacman.X, pacman.Y] = ImageToDraw.empty;
                IncreaseScore(500);
            }
            // Fooding 'Killer', and start to mode: fooder enemys.
            else if (ListOfData1[pacman.X, pacman.Y] == ImageToDraw.killer)
            {
                ListOfData1[pacman.X, pacman.Y] = ImageToDraw.empty;
                if (Settings.profiles[Settings.AP].PlaySound)
                    SowndFoofing.Play();
                PicFooder.Visible = true;
                LblTime.Visible = true;
                LblTime.Text = "15";
                FooderTimer.Start();
                IncreaseScore(500);
            }
            // Fooding keys -> end level
            else if (ListOfData1[pacman.X, pacman.Y] == ImageToDraw.key)
            {
                if (LblLevel.Text == "4")
                    EndGame();
                else
                    NextLevel();
            }
            pbCanvas.Invalidate();
        }

        private bool GoPacmen(Direction d, bool want)
        {
            // if 'want' = true: the method try incraese the pacmen to want direction. if  this sucssed return true, else false.
            // if 'want' = false: the method incraese the pacmen to direction.
            switch (d)
            {
                case Direction.Right:
                    if ((int)ListOfData1[pacman.X + 1, pacman.Y] > 3 && pacman.ChelkeyDirections[1] == 4)
                    {
                        pacman.ChelkeyDirections[0]++;
                        if (pacman.ChelkeyDirections[0] == 8)
                        {
                            pacman.X++;
                            pacman.ChelkeyDirections[0] = 4;
                        }
                        if (want)
                        {
                            pacman.DirectionWant = null;
                            pacman.direction = d;
                        }
                        if (WOver)
                        {
                            if (pbCanvas.Left + (pacman.X * 40) + 125 > SizeScreen.Width)
                            {
                                CounterIterations = 40;
                                TmrMoveCanvas.Tag = 1;
                                PaintTimer.Stop(); 
                                TmrMoveCanvas.Start();
                            }
                        }
                        return true;
                    }
                    break;
                case Direction.Left:
                    if ((int)ListOfData1[pacman.X - 1, pacman.Y] > 3 && pacman.ChelkeyDirections[1] == 4)
                    {
                        pacman.ChelkeyDirections[0]--;
                        if (pacman.ChelkeyDirections[0] == 0)
                        {
                            pacman.X--;
                            pacman.ChelkeyDirections[0] = 4;
                        }
                        if (want)
                        {
                            pacman.DirectionWant = null;
                            pacman.direction = d;
                        }
                        if (WOver)
                        {
                            if (pbCanvas.Left + (pacman.X * 40) < 125)
                            {
                                CounterIterations = 40;
                                TmrMoveCanvas.Tag = 3;
                                PaintTimer.Stop();
                                TmrMoveCanvas.Start();
                            }
                        }
                        return true;
                    }
                    break;
                case Direction.Up:
                    if ((int)ListOfData1[pacman.X, pacman.Y - 1] > 3 && pacman.ChelkeyDirections[0] == 4)
                    {
                        pacman.ChelkeyDirections[1]--;
                        if (pacman.ChelkeyDirections[1] == 0)
                        {
                            pacman.Y--;
                            pacman.ChelkeyDirections[1] = 4;
                        }
                        if (want)
                        {
                            pacman.DirectionWant = null;
                            pacman.direction = d;
                        }
                        if (HOver)
                        {
                            if (pbCanvas.Top + (pacman.Y * 40) < 125)
                            {
                                CounterIterations = 40;
                                TmrMoveCanvas.Tag = 2;
                                PaintTimer.Stop();
                                TmrMoveCanvas.Start();
                            }
                        }
                        return true;
                    }
                    break;
                case Direction.Down:
                    if ((int)ListOfData1[pacman.X, pacman.Y + 1] > 3 && pacman.ChelkeyDirections[0] == 4)
                    {
                        pacman.ChelkeyDirections[1]++;
                        if (pacman.ChelkeyDirections[1] == 8)
                        {
                            pacman.Y++;
                            pacman.ChelkeyDirections[1] = 4;
                        }
                        if (want)
                        {
                            pacman.DirectionWant = null;
                            pacman.direction = d;
                        }
                        if (HOver)
                        {
                            if (pbCanvas.Top + (pacman.Y * 40) + 125 > SizeScreen.Height)
                            {
                                CounterIterations = 40;
                                TmrMoveCanvas.Tag = 4;
                                PaintTimer.Stop();
                                TmrMoveCanvas.Start();
                            }
                        }
                        return true;
                    }
                    break;
            }
            return false;
        }

        private Point GenerateRandomLocation()
        {
            // collect all locations legal to draw key, and remove location of pacmen.
            // in finish, return randomal location.
            List<Locaton> LocationLegals = new List<Locaton>();
            for (int y = 0; y < ListOfData1.GetUpperBound(0); y++)
            {
                for (int z = 0; z < ListOfData1.GetUpperBound(1); z++)
                {
                    if (ListOfData1[y, z] == ImageToDraw.empty)
                        LocationLegals.Add(new Locaton { X = y, Y = z });
                }
            }
            if (LocationLegals.IndexOf(new Locaton { X = pacman.X, Y = pacman.Y }) != -1)
                LocationLegals.RemoveAt(LocationLegals.IndexOf(new Locaton { X = pacman.X, Y = pacman.Y }));
            Random rand = new Random();
            int i = rand.Next(0, LocationLegals.Count);
            return new Point { X = LocationLegals[i].X, Y = LocationLegals[i].Y };
        }

        private void FrmPacmen_FormClosing(object sender, FormClosingEventArgs e)
        {
            //stop timer and music
            PaintTimer.Enabled = false;
            waiter1.VisibleChanged -= Waiter_VisibleChanged;
            mciSendString(@"close temp_alias", null, 0, IntPtr.Zero);
        }
        private bool NumberOfLines(char c)
        {
            // if the char is 'enter', return true.
            if (c == '\r')
                return true;
            else
                return false;
        }
        private void IncreaseScore(int Score)
        {
            if ((int.Parse(lblScore.Text) + Score) / 10000 > int.Parse(lblScore.Text) / 10000)
                lblLives.Text = (Int32.Parse(lblLives.Text) + 1).ToString();
            lblScore.Text = (int.Parse(lblScore.Text) + Score).ToString();
        }

        public  class TimerBoom
        {
            public Timer Boomer;
            public Locaton LocBoom;
            public List<Point> ListBooms = new List<Point>();
            public Timer ClearBoomer = new Timer() { Interval = 1000 };
        }

        public void Boomer_Tick(object sender, EventArgs e)
        {
            int a = MyTimers[(int)((Timer)sender).Tag].LocBoom.X;
            int b = MyTimers[(int)((Timer)sender).Tag].LocBoom.Y;
            for (int x = a - 1; x < a + 2; x++)
                for (int y = b - 1; y < b + 2; y++)
                {
                    if (ListOfData1[x, y] == ImageToDraw.food)
                        foods--;
                    if (ListOfData1[x, y] == ImageToDraw.blockTemp || ListOfData1[x, y] == ImageToDraw.empty ||
                        ListOfData1[x, y] == ImageToDraw.dollar || ListOfData1[x, y] == ImageToDraw.food ||
                        ListOfData1[x, y] == ImageToDraw.fooded || ListOfData1[x, y] == ImageToDraw.boom ||
                        ListOfData1[x, y] == ImageToDraw.boomer )
                    {
                        ListOfData1[x, y] = ImageToDraw.boom;
                        MyTimers[(int)((Timer)sender).Tag].ListBooms.Add(new Point(x, y));
                    }
                    if (x == pacman.X && y == pacman.Y)
                    {
                        ((Timer)sender).Stop();
                        DownLive();
                        return;
                    }
                }
            MyTimers[(int)((Timer)sender).Tag].ClearBoomer.Start();
            ((Timer)sender).Stop();
        }

        // convert all location that in list boombs to empty, and shut off the timer sender.
        void ClearBoomer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < MyTimers[(int)((Timer)sender).Tag].ListBooms.Count; i++)
                ListOfData1[MyTimers[(int)((Timer)sender).Tag].ListBooms[i].X, MyTimers[(int)((Timer)sender).Tag].ListBooms[i].Y] = ImageToDraw.empty;
             MyTimers[(int)((Timer)sender).Tag].ClearBoomer.Stop();
        }
    }
}