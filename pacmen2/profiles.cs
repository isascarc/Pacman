using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacmanGame
{
    class Profile
    {
        public string Name { get; set; }
        public string men { get; set; }
        public int Language { get; set; }
        public string Password { get; set; }
        public bool PlayMusic { get; set; }
        public bool PlaySound { get; set; }
        public string[] HighScore = new string[3];
        public string HighLevel { get; set; }
        public List<string> GamesSaved = new List<string>();
    }

    class Profiles
    {
        /// <summary>
        /// create a new profile, with all the parameters about.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="Lang"></param>
        /// <param name="Men"></param>
        /// <param name="pass"></param>
        public static void CreateProfile(string name, int Lang, int Men, string pass)
        {
            Settings.profiles.Add(new Profile
            {
                Name = name,
                HighScore = new string[] { "0", "0", "0" },
                HighLevel = "0",
                Language = Lang,
                men = Men.ToString(),
                Password = pass,
                PlayMusic = true,
                PlaySound = true
            });
            if (System.IO.File.Exists(MyForms.PathProfiles))
            {
                string[] lines = System.IO.File.ReadAllLines(MyForms.PathProfiles);
                lines[lines.Length - 1] = Settings.ReturnLine(Settings.profiles.Count - 1);
                Array.Resize(ref lines, lines.Length + 1);
                lines[lines.Length - 1] = Settings.AP.ToString();
                System.IO.File.WriteAllLines(MyForms.PathProfiles, lines);
            }
            else
                System.IO.File.WriteAllLines(MyForms.PathProfiles, new string[] { Settings.ReturnLine(0), "0" });
        }
        public static void SaveNewGame(int NumProfile, string NameGame)
        {

           
        }
        public static void LoadNewGame(int NumProfile, int NumGame)
        {

        }
        public static void DeleteNewGame(int NumProfile)
        {

        }
    }
}