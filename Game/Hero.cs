﻿using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Game
{

    public class Hero
    {
        public string Name;
        private int Strength;
        private int Dexterity;
        private int Intelligence;
        public double HP;
        public int MP;
        public int XP;
        public int LVL;

        public static void Stats()
        {
            Hero hero = Hero.Load("hero");
            Console.WriteLine(hero.Name + " Str:{0} Dex:{1} Int:{2} HP:{3} MP:{4} XP:{5} LVL:{6}", hero.GetStrength(), hero.GetDexterity(), hero.GetIntelligence(), hero.HP, hero.MP, hero.XP, hero.LVL);
            Console.ReadKey();
        }

        public static int Menu()
        {
            Console.Clear();
            int answer;
            Console.WriteLine("" +
            "[1] Create new hero\n\r" +
            "[2] Play singleplayer\n\r" +
            "[3] Play multiplayer\n\r" +
            "[4] Show hero stats\n\r" +
            "[5] Exit");
            int.TryParse(Console.ReadLine(), out answer);
            return answer;
        }

        private void Init(int strength = 10, int dexterity = 10, int intelligence = 10)
        {
            this.Strength = strength;
            this.Dexterity = dexterity;
            this.Intelligence = intelligence;
            HP = 50 + strength;
            MP = 10 + (3 * intelligence);
        }

        public static Hero New()
        {
            Hero hero = new Hero("name", "class");
            Console.Write("Name your hero!       (Type 'exit' to return to the main menu)\n\r: ");
            string name = Console.ReadLine();
            if (name == "exit")
            {
                Menu();
            }
            else
            {
                hero.Name = Console.ReadLine();
                Console.WriteLine("Well, now you have 20 points, u can upgrade any stats you want");
                hero.Strength = 5;
                hero.Dexterity = 5;
                hero.Intelligence = 5;
                hero.LVL = 1;
                hero.XP = 0;
                for (int i = 20; i > 0; i--)
                {
                    Console.WriteLine("Str:{0} Dex:{1} Int:{2}", hero.GetStrength(), hero.GetDexterity(), hero.GetIntelligence() + " points left:" + i);
                    Console.WriteLine("[1] Strength" +
                        "  [2] Dexterity" +
                        "  [3] Intelligence");
                    Console.Write(": ");
                    int ans;
                    int.TryParse(Console.ReadLine(), out ans);
                    if (ans == 1)
                        hero.Strength += 1;

                    else if (ans == 2)
                        hero.Dexterity += 1;

                    else
                        hero.Intelligence += 1;

                    Console.Clear();
                }
                Console.WriteLine("Hero created!");
                Console.WriteLine("Str:{0} Dex:{1} Int:{2}", hero.GetStrength(), hero.GetDexterity(), hero.GetIntelligence());
                Save.save(hero.Name, hero.Strength, hero.Dexterity, hero.Intelligence, hero.LVL, hero.XP);
                Console.WriteLine("Press ANY key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            return hero;
        }

        public static Hero Load(string name)
        {
            name = name + ".json";
            string heroString = File.ReadAllText(name);
            JObject heroJson = JObject.Parse(heroString);
            Hero hero = new Hero("name", "class");
            hero.Name = (string)heroJson["Name"];
            hero.Strength = (int)heroJson["Strength"];
            hero.Dexterity = (int)heroJson["Dexterity"];
            hero.Intelligence = (int)heroJson["Intelligence"];
            hero.MP = (int)heroJson["MP"];
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

        public Hero(string name, string myclass)
        {
            Name = name;
            switch (myclass)
            {
                case "warior": Init(15, 10, 5); break;
                case "assassin": Init(15, 15, 5); break;
                case "sorcerer": Init(10, 5, 20); break;
                default: Init(); break;
            }
        }

        public void Attack(Hero enemy, string atk, Hero hero, int tour)
        {
            int opt = 0;

            if (atk == "Intelligence" && MP < 5)
            {
                Console.WriteLine("Not enough mana, attack melee");
                atk = "Strength";
            }

            double damage = 0;
            Rand rand = new Rand();
            if (atk == "Strength")
            {
                damage = Strength * rand.Run(5, 10) / 10;
            }
            else if (atk == "Intelligence")
            {
                if (tour == 1)
                {
                    Console.Write("Pick a spell:\n\r" +
                "[1] Fireball\n\r" +
                "[2] Frostbite\n\r" +
                "[3] Heal\n\r" +
                ": ");
                    int.TryParse(Console.ReadLine(), out opt);
                }
                else
                {
                    Random rnd = new Random();
                    opt = rnd.Next(1, 4);
                }


                switch (opt)
                {
                    case 1: damage = Intelligence * rand.Run(3, 12) / 10; hero.MP -= 6; break;

                    case 2: damage = Intelligence * rand.Run(2, 14) / 10; hero.MP -= 7; break;

                    case 3: hero.HP += 10; hero.MP -= 5; break;

                }

            }


            if (opt == 0 && rand.Run(0, 100) > enemy.GetDexterity())
            {
                Console.WriteLine("Bang!      " + "damage=" + damage);
                enemy.HP -= damage;
                Sound.Play("hit");
                if (tour == 1)
                {
                    exp(1);
                }
            }

            else if (opt == 1 && rand.Run(0, 100) > enemy.GetDexterity())
            {
                Console.WriteLine("Fireball!      " + "damage=" + damage);
                enemy.HP -= damage;
                if (tour == 1)
                {
                    exp(1);
                }
            }

            else if (opt == 2 && rand.Run(0, 100) > enemy.GetDexterity())
            {
                Console.WriteLine("Frostbite!      " + "damage=" + damage);
                enemy.HP -= damage;
                if (tour == 1)
                {
                    exp(1);
                }
            }

            else if (opt == 3)
            {
                Console.WriteLine("Healed!");
                if (tour == 1)
                {
                    exp(1);
                }
            }
            else Console.WriteLine("Dodge!");
        }

        public int exp(int opt)
        {
            if (XP >= (LVL * 1000))
            {
                XP -= (LVL * 1000);
                LevelUp();
            }
            switch (opt)
            {
                case 1: XP += 5; break;
                case 2: XP += 100; break;
                case 3: XP += 30; break;
            }

            return XP;
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
                int opt;
                int.TryParse(Console.ReadLine(), out opt);

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
