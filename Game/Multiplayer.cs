using System;

namespace Game
{
    class Multiplayer
    {
        public static void Multi()
        {
            Console.Clear();
            int type = 2;
            Hero hero = Hero.Load("hero");
            Console.WriteLine("Create your enemy!\r\n");
            Enemy enemy = new Enemy(2);
            if (enemy == null)
                Hero.Menu();
            else
            {
                Console.WriteLine(hero.Name + "\r\nStr:{0} Dex:{1} Int:{2} \r\nHP:{3} MP:{4}\r\n", hero.GetStrength(), hero.GetDexterity(), hero.GetIntelligence(), hero.HP, hero.MP);
                Console.WriteLine(enemy.Name + "\r\nStr:{0} Dex:{1} Int:{2} \r\nHP:{3} MP:{4}", enemy.GetStrength(), enemy.GetDexterity(), enemy.GetIntelligence(), enemy.HP, enemy.MP);
                Sound.Play("fight");
                Timer.Count(2, "fight", 1000);
                Fight.Start(hero, enemy, type);
            }

        }
    }
}
