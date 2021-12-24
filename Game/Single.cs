using System;


namespace Game
{
    class Single
    {
        public static void Solo()
        {
            Console.Clear();
            int type = 1;
            bool escape = false;
            Hero hero = Hero.Load("hero");
            Console.WriteLine(hero.Name + "\r\nStr:{0} Dex:{1} Int:{2} \r\nHP:{3} MP:{4}\r\n", hero.GetStrength(), hero.GetDexterity(), hero.GetIntelligence(), hero.HP, hero.MP);
            Hero enemy = new Hero("Wataszka Stefan", "sorcerer", 0, 0, 0);
            Console.WriteLine(enemy.Name + "\r\nStr:{0} Dex:{1} Int:{2} \r\nHP:{3} MP:{4}\r\n", enemy.GetStrength(), enemy.GetDexterity(), enemy.GetIntelligence(), enemy.HP, enemy.MP);
            Console.WriteLine("Press any key to fight!");
            Console.WriteLine("Or press Esc if you want to try to escape the fight");

            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                escape = Fight.Escape(hero, enemy);

            if (!escape)
            {
                Console.Clear();
                Sound.Play("fight");
                Timer.Count(2, "fight",1000);
                Fight.Start(hero, enemy, type);
            }
        }
    }
}