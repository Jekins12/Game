using System;

namespace Game
{
    class Single
    {
        public static void Solo()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                int tour = 1;

                Hero hero = Hero.Load("hero");
                Console.WriteLine(hero.Name + "Str:{0} Dex:{1} Int:{2} HP:{3} MP:{4}", hero.GetStrength(), hero.GetDexterity(), hero.GetIntelligence(), hero.HP, hero.MP);
                Hero enemy = new Hero("Wataszka Stefan", "sorcerer");
                Console.WriteLine(enemy.Name + " Str:{0} Dex:{1} Int:{2} HP:{3} MP:{4}", enemy.GetStrength(), enemy.GetDexterity(), enemy.GetIntelligence(), enemy.HP, enemy.MP);
                Console.WriteLine();
                Console.WriteLine("Press ENTER to fight!");
                Console.ReadLine();
                Timer.Count(3);
                while (hero.HP > 0 && enemy.HP > 0)
                {
                    Console.Clear();

                    if (tour == 1) Console.WriteLine("Your Turn: " + hero.Name);
                    else Console.WriteLine("Your Turn: " + enemy.Name);
                    int opt = 0;

                    if (tour == 1)
                    {
                        Console.Write("[1]:Attack, [2]:Spell... ");
                        int.TryParse(Console.ReadLine(), out opt);
                    }
                    else
                    {
                        Random rnd = new Random();

                        opt = rnd.Next(1, 3);
                    }


                    switch (opt)
                    {
                        case 1:
                            if (tour == 1) hero.Attack(enemy, "Strength", hero, tour);
                            else enemy.Attack(hero, "Strength", enemy, tour);
                            break;

                        case 2:
                            if (tour == 1) hero.Attack(enemy, "Intelligence", hero, tour);
                            else enemy.Attack(hero, "Intelligence", enemy, tour);
                            break;
                    }
                    Console.WriteLine();
                    Console.WriteLine(hero.Name + " HP:{0} MP:{1}", hero.HP, hero.MP);
                    Console.WriteLine();
                    Console.WriteLine(enemy.Name + " HP:{0} MP:{1}", enemy.HP, enemy.MP);
                    Console.ReadLine();

                    tour++;
                    if (tour > 2) tour = 1;
                }
                if (hero.HP <= 0)
                {
                    Console.WriteLine(enemy.Name + " IS THE WINNER!");
                    hero.exp(3);
                    Save.save("default", hero.GetStrength(), hero.GetDexterity(), hero.GetIntelligence(), hero.LVL, hero.XP);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine(hero.Name + " IS THE WINNER!");
                    hero.exp(2);
                    Save.save("default", hero.GetStrength(), hero.GetDexterity(), hero.GetIntelligence(), hero.LVL, hero.XP);
                    Console.ReadKey();
                }
                Console.Write("Press ENTER to return to the main menu: ");
                Console.ReadKey();
                exit = true;
            }
        }
    }
}