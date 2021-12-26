using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace Game
{

    public class Hero
    {

        public string Name;
        private int Strength = 0;
        private int Dexterity = 0;
        private int Intelligence = 0;
        public int HP;
        public int MP;
        public int XP;
        public int LVL;


        public static void Stats()
        {
            Console.Clear();
            Hero hero = Hero.Load("hero");
            Console.WriteLine(hero.Name + "\r\nStr:{0} Dex:{1} Int:{2} \r\nHP:{3} MP:{4} XP:{5} LVL:{6}", hero.GetStrength(), hero.GetDexterity(), hero.GetIntelligence(), hero.HP, hero.MP, hero.XP, hero.LVL);
            Console.Write("\r\nPress Enter to return to the main menu...");
            while (Console.ReadKey().Key != ConsoleKey.Enter) ;
        }

        public static int Menu()
        {
            Console.Clear();
            int answer;
            Console.Write("" +
            "[1] Create new hero\n\r" +
            "[2] Play singleplayer\n\r" +
            "[3] Play multiplayer\n\r" +
            "[4] Show hero stats\n\r" +
            "[5] Exit\n:");
            answer = Key.Pressed(5);
            return answer;
        }

        public static Hero New()
        {
            Console.Write("Name your hero!       (Press 'Esc' to return to the main menu)\n\r: ");
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                return null;

            string name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Well, now you have 20 points, u can upgrade any stats you want");
            int Strength = 5;
            int Dexterity = 5;
            int Intelligence = 5;

            for (int i = 20; i > 0; i--)
            {
                Console.WriteLine("Str:{0} Dex:{1} Int:{2}", Strength, Dexterity, Intelligence + " points left:" + i);
                Console.WriteLine("[1] Strength" +
                    "  [2] Dexterity" +
                    "  [3] Intelligence");

                int ans = Key.Pressed(3);

                if (ans == 1)
                    Strength += 1;

                else if (ans == 2)
                    Dexterity += 1;

                else
                    Intelligence += 1;

                Console.Clear();
            }

            Hero hero = new Hero(name, Strength, Dexterity, Intelligence);
            hero.LVL = 1;
            hero.XP = 0;
            Console.WriteLine("Hero created!");
            Console.WriteLine("Str:{0} Dex:{1} Int:{2} HP:{3}", hero.GetStrength(), hero.GetDexterity(), hero.GetIntelligence(), hero.HP);
            Save.save(hero.Name, hero.Strength, hero.Dexterity, hero.Intelligence, hero.LVL, hero.XP);
            Console.WriteLine("Press ANY key to continue...");
            Console.ReadKey();
            Console.Clear();
            return hero;
        }

        public static Hero Load(string name)
        {
            name = name + ".json";
            Hero hero = new Hero("name", 0, 0, 0);

            string heroString = File.ReadAllText(name);
            JObject heroJson = JObject.Parse(heroString);
            hero.Name = (string)heroJson["Name"];
            hero.Strength = (int)heroJson["Strength"];
            hero.Dexterity = (int)heroJson["Dexterity"];
            hero.Intelligence = (int)heroJson["Intelligence"];
            hero.HP = 50 + hero.Strength * 2;
            hero.MP = 30 + hero.Intelligence * 3;
            hero.XP = (int)heroJson["XP"];
            hero.LVL = (int)heroJson["LVL"];
            return hero;
        }

        public int GetStrength() { return Strength; }

        public int GetDexterity() { return Dexterity; }

        public int GetIntelligence() { return Intelligence; }

        public void UpStrength() { this.Strength += 1; this.HP += 5; }

        public void UpDexterity() { this.Dexterity += 1; }

        public void UpIntelligence() { this.Intelligence += 1; this.MP += (3 * this.Intelligence); }

        public Hero(string name, int str, int dex, int intl)
        {

            Name = name;
            Strength = str;
            Dexterity = dex;
            Intelligence = intl;
            HP = 50 + Strength * 2;
            MP = 30 + Intelligence * 3;
        }

        public static int exp(int opt, string name)
        {
            Hero hero = Load("hero");
            if (hero.XP >= (hero.LVL * 1000))
            {
                hero.XP -= (hero.LVL * 1000);
                hero.LevelUp();
            }
            switch (opt)
            {
                case 1: hero.XP += 5; break;
                case 2: hero.XP += 100; break;
                case 3: hero.XP += 30; break;
            }

            return hero.XP;
        }

        public void LevelUp()
        {
            LVL += 1;
            Console.WriteLine("Level up!" +
                "\n\rYou have 3 points, choose wisely!");
            for (int i = 3; i > 0; i--)
            {
                Console.Write(i + " points left");
                Console.Write("  1:Strength, 2:Dexterity, 3:Intelligence ... ");
                int opt = 0;
                opt = Key.Pressed(3);

                switch (opt)
                {
                    case 1: UpStrength(); break;
                    case 2: UpDexterity(); break;
                    case 3: UpIntelligence(); break;
                }

                Console.Clear();
            }

        }

    }
}

