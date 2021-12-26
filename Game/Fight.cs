using System;

namespace Game
{
    class Fight
    {
        public static void Start(Hero hero, Enemy enemy, int type)
        {
            int tour = 1;
            while (hero.HP > 0 && enemy.HP > 0)
            {

                Console.Clear();
                Console.Write(hero.Name + " HP:{0} MP:{1}", hero.HP, hero.MP);
                Console.WriteLine("          " + enemy.Name + " HP:{0} MP:{1}\r\n", enemy.HP, enemy.MP);
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (tour == 1) Console.WriteLine("Your Turn: " + hero.Name);
                else Console.WriteLine("Your Turn: " + enemy.Name);
                Console.ForegroundColor = ConsoleColor.White;
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
                        if (tour == 1) attack.Attack(enemy, "Strength", hero, tour, type);
                        else attack.Attack(enemy, "Strength", hero, tour, type);
                        break;

                    case 2:
                        if (tour == 1) attack.Attack(enemy, "Intelligence", hero, tour, type);
                        else attack.Attack(enemy, "Intelligence", hero, tour, type);
                        break;
                }


                if (type == 1)
                    Timer.Count(1, null, 500);
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
                Hero.exp(3, hero.Name);
                Save.save("default", hero.GetStrength(), hero.GetDexterity(), hero.GetIntelligence(), hero.LVL, hero.XP);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Sound.Play("fatality");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(hero.Name + " IS THE WINNER!");
                Hero.exp(2, hero.Name);
                Save.save("default", hero.GetStrength(), hero.GetDexterity(), hero.GetIntelligence(), hero.LVL, hero.XP);
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.Write("Press ENTER to return to the main menu: ");
            Console.ReadKey();
        }

        public static bool Escape(Hero hero, Enemy enemy)
        {
            Rand rand = new Rand();
            Timer.Count(2, "escape", 1000);
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
