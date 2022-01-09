using System;

namespace Game
{
    class Attack
    {
        public static void attack(Enemy enemy, string atk, Hero hero, int tour, int type)
        {

            bool flag;
            int opt = 0;
            if (tour == 1)
            {
                if (atk == "Intelligence" && hero.MP < 5)
                {
                    Console.WriteLine("Not enough mana, attack melee");
                    atk = "Strength";
                }
            }
            else
            {
                if (atk == "Intelligence" && enemy.MP < 5)
                {
                    Console.WriteLine("Not enough mana, attack melee");
                    atk = "Strength";
                }
            }


            int damage = 0;
            Rand rand = new Rand();

            if (atk == "Strength")
            {
                if (tour == 1)
                {
                    damage = hero.GetStrength() * rand.Run(6, 13) / 10;
                }
                else damage = enemy.GetStrength() * rand.Run(6, 13) / 10;


            }
            else if (atk == "Intelligence")
            {
                if (type == 1)
                {
                    if (tour == 1)
                    {
                        Console.Write("Pick a spell:\n\r" +
                    "[1] Fireball\n\r" +
                    "[2] Frostbite\n\r" +
                    "[3] Heal\n\r" +
                    ": ");
                        opt = Key.Pressed(3);
                    }
                    else
                    {
                        Random rnd = new Random();
                        opt = rnd.Next(1, 4);
                    }
                }

                else
                {
                    Console.Write("Pick a spell:\n\r" +
                    "[1] Fireball\n\r" +
                    "[2] Frostbite\n\r" +
                    "[3] Heal\n\r" +
                    ": ");
                    opt = Key.Pressed(3);
                }


                if (tour == 1)
                {
                    switch (opt)
                    {
                        case 1: damage = hero.GetIntelligence() * rand.Run(6, 13) / 10; hero.MP -= 6; break;

                        case 2: damage = hero.GetIntelligence() * rand.Run(8, 15) / 10; hero.MP -= 8; break;

                        case 3: hero.HP += 5 + hero.GetIntelligence() / 2; hero.MP -= 5; break;

                    }
                }
                else
                {
                    switch (opt)
                    {
                        case 1: damage = enemy.GetIntelligence() * rand.Run(6, 13) / 10; enemy.MP -= 6; break;

                        case 2: damage = enemy.GetIntelligence() * rand.Run(8, 15) / 10; enemy.MP -= 8; break;

                        case 3: enemy.HP += 5 + enemy.GetIntelligence() / 2; enemy.MP -= 5; break;

                    }
                }


            }

            flag = true;
            if (tour == 1 && rand.Run(0, 100) > enemy.GetDexterity())
            {
                flag = false;
                if (opt == 0)
                {
                    Console.WriteLine("Bang!      " + "damage=" + damage);
                    enemy.HP -= damage;
                    Sound.Play("hit");
                    Hero.Exp(1);
                }
                else if (opt == 1)
                {
                    Sound.Play("fireball");
                    Console.WriteLine("Fireball!      " + "damage=" + damage);
                    enemy.HP -= damage;
                    Hero.Exp(1);
                }
                else if (opt == 2)
                {
                    Sound.Play("frostbite");
                    Console.WriteLine("Frostbite!      " + "damage=" + damage);
                    enemy.HP -= damage;
                    Hero.Exp(1);
                }
                else if (opt == 3)
                {
                    Sound.Play("heal");
                    Console.WriteLine("Healed!");
                    Hero.Exp(1);
                }
            }

            else if(tour==1 && flag) Console.WriteLine("Dodge!");


            if (tour == 2 && rand.Run(0, 100) > hero.GetDexterity())
            {
                flag = false;

                if (opt == 0)
                {
                    Console.WriteLine("Bang!      " + "damage=" + damage);
                    hero.HP -= damage;
                    Sound.Play("hit");
                }
                else if (opt == 1)
                {
                    Sound.Play("fireball");
                    Console.WriteLine("Fireball!      " + "damage=" + damage);
                    hero.HP -= damage;
                }
                else if (opt == 2)
                {
                    Sound.Play("frostbite");
                    Console.WriteLine("Frostbite!      " + "damage=" + damage);
                    hero.HP -= damage;
                }
                else if (opt == 3)
                {
                    Sound.Play("heal");
                    Console.WriteLine("Healed!");
                }
            }

            else if(tour==2 && flag) Console.WriteLine("Dodge!");
        }
    }
}
