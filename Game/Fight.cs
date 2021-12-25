﻿using System;

namespace Game
{
    class Fight
    {
        public static void Start(Hero hero, Hero enemy, int type)
        {
            int tour = 1;
            while (hero.HP > 0 && enemy.HP > 0)
            {
                Console.Clear();

                if (tour == 1) Console.WriteLine("Your Turn: " + hero.Name);
                else Console.WriteLine("Your Turn: " + enemy.Name);
                int opt = 0;

                if (type == 1)
                {
                    if (tour == 1)
                    {
                        Console.WriteLine("[1]:Attack, [2]:Spell... ");
                        opt = Key.Pressed(2);

                    }
                    else
                    {
                        if (enemy.GetStrength() - enemy.GetIntelligence() >= 10)
                            opt = 1;

                        else if (enemy.GetIntelligence() - enemy.GetStrength() >= 10)
                            opt = 2;
                        
                        else
                        {
                            Random rnd = new Random();
                            opt = rnd.Next(1, 3);
                        }
                        
                    }
                }

                else
                {
                    Console.WriteLine("[1]:Attack, [2]:Spell... ");
                    opt = Key.Pressed(2);
                }


                switch (opt)
                {
                    case 1:
                        if (tour == 1) hero.Attack(enemy, "Strength", hero, tour, type);
                        else enemy.Attack(hero, "Strength", enemy, tour, type);
                        break;

                    case 2:
                        if (tour == 1) hero.Attack(enemy, "Intelligence", hero, tour, type);
                        else enemy.Attack(hero, "Intelligence", enemy, tour, type);
                        break;
                }
                Console.WriteLine();
                Console.WriteLine(hero.Name + " HP:{0} MP:{1}", hero.HP, hero.MP);
                Console.WriteLine();
                Console.WriteLine(enemy.Name + " HP:{0} MP:{1}", enemy.HP, enemy.MP);
                if (type == 1)
                    Timer.Count(1, null,1000);
                else
                    Console.ReadLine();

                tour++;
                if (tour > 2) tour = 1;
            }

            if (hero.HP <= 0)
            {
                Sound.Play("fatality");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(enemy.Name + " IS THE WINNER!");
                hero.exp(3);
                Save.save("default", hero.GetStrength(), hero.GetDexterity(), hero.GetIntelligence(), hero.LVL, hero.XP);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Sound.Play("fatality");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(hero.Name + " IS THE WINNER!");
                hero.exp(2);
                Save.save("default", hero.GetStrength(), hero.GetDexterity(), hero.GetIntelligence(), hero.LVL, hero.XP);
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.Write("Press ENTER to return to the main menu: ");
            Console.ReadKey();
        }

        public static bool Escape(Hero hero, Hero enemy)
        {
            Rand rand = new Rand();
            Timer.Count(2, "escape",1000);
            if (hero.GetDexterity() >= enemy.GetDexterity() / 5 * rand.Run(1, 16))
            {
                Console.WriteLine("You successfully escaped!");
                Console.Write("Press any key to return to the main menu...");
                Console.ReadKey();
                return true;
            }
            Console.WriteLine("Failed!");
            Console.Write("Press any key to fight!");
            Console.ReadKey();
            return false;
        }
    }
}
