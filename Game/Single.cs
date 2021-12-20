using System;

namespace Game
{
    class Single
    {
        public static void Solo()
        {
            Console.Clear();
            int type = 1;

            Hero hero = Hero.Load("hero");
            Console.WriteLine(hero.Name + " Str:{0} Dex:{1} Int:{2} HP:{3} MP:{4}", hero.GetStrength(), hero.GetDexterity(), hero.GetIntelligence(), hero.HP, hero.MP);
            Hero enemy = new Hero("Wataszka Stefan", "sorcerer");
            Console.WriteLine(enemy.Name + " Str:{0} Dex:{1} Int:{2} HP:{3} MP:{4}", enemy.GetStrength(), enemy.GetDexterity(), enemy.GetIntelligence(), enemy.HP, enemy.MP);
            Console.WriteLine();
            Console.WriteLine("Press ENTER to fight!");
            Console.ReadLine();
            Sound.Play("fight");
            Timer.Count(3);
            
            Fight.Start(hero, enemy, type);
        }
    }
}