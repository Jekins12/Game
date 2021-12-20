using System;

namespace Game
{
    class Multiplayer
    {
        public static void Multi()
        {
            int type = 2;
            Hero hero = Hero.Load("hero");
            Console.WriteLine(hero.Name + " Str:{0} Dex:{1} Int:{2} HP:{3} MP:{4}", hero.GetStrength(), hero.GetDexterity(), hero.GetIntelligence(), hero.HP, hero.MP);
            Console.WriteLine("\r\nNow create your enemy!\r\n");
            Hero enemy = Hero.New("enemy");
            Sound.Play("fight");
            Timer.Count(2);
            Fight.Start(hero, enemy, type);
        }
    }
}
