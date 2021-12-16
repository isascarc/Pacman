using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Media;
using System.IO;

namespace PacmanGame
{
    enum Direction { Left, Right, Up, Down, };
    enum ImageToDraw { block, blockTemp, boom, boomer, free, empty, killer, food, key, pacman, enemy, fooded, dollar };

    static class Settings
    {
        /// <summary>
        /// This the Actual Profile.
        /// </summary>
        public static int AP { get; set; }
        public static List<Profile> profiles = new List<Profile>();
        public static List<string> MyLangs = new List<string>();
        public static void loadLangs()
        {
            string[] files = Directory.GetFiles(Application.StartupPath + "\\langs\\");
        }

        public static string ReturnLine(int NumberProfile)
        {
            return
                Settings.profiles[NumberProfile].Name + "|" +
                Settings.profiles[NumberProfile].Language + "|" +
                Settings.profiles[NumberProfile].HighScore[0] + "|" +
                Settings.profiles[NumberProfile].HighScore[1] + "|" +
                Settings.profiles[NumberProfile].HighScore[2] + "|" +
                Settings.profiles[NumberProfile].HighLevel + "|" +
                Settings.profiles[NumberProfile].men + "|" +
                Settings.profiles[NumberProfile].Password + "|" +
                Settings.profiles[NumberProfile].PlayMusic + "|" +
                Settings.profiles[NumberProfile].PlaySound;
        }
    }



    public struct Locaton
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    class Pacman
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int OrginalX { get; set; }
        public int OrginalY { get; set; }
        public Direction direction { get; set; }
        public Direction? DirectionWant { get; set; }
        public Direction IconDirection { get; set; }
        public int[] ChelkeyDirections = new int[2];
    }

    class Enemy
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int OrginalX { get; set; }
        public int OrginalY { get; set; }
        public bool Dead { get; set; }
        public Direction direction { get; set; }
        public int ChelkeyX;
        public int ChelkeyY;
        public List<Direction> OptionalDirections = new List<Direction>();

        public Enemy()
        {
            ChelkeyX = 4;
            ChelkeyY = 4;
        }
    }
}