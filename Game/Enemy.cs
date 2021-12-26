using System;

namespace Game
{
    class Enemy
    {
        public string Name;
        private int Strength = 0;
        private int Dexterity = 0;
        private int Intelligence = 0;
        public int HP;
        public int MP;

        public int GetStrength() { return Strength; }

        public int GetDexterity() { return Dexterity; }

        public int GetIntelligence() { return Intelligence; }

        public Enemy(int type)
        {
            if (type == 1)
            {
                string[] enemies_name = { "Undead Priest", "Dark Paladin", "Asian boy" };
                int[,] enemies_stats =
                {
                {15,7,25},  //Srength,Dexterity,Intelligence
                {25,10,7},
                {15,25,10}
            };
                Rand rand = new Rand();
                int who = rand.Run(0, 2);
                Name = enemies_name[who];
                Strength = enemies_stats[who, 0];
                Dexterity = enemies_stats[who, 1];
                Intelligence = enemies_stats[who, 2];
                HP = 50 + Strength * 2;
                MP = 30 + Intelligence * 3;
            }


            else if (type == 2)
            {

                Console.Write("Name your hero!       (Press 'Esc' to return to the main menu)\n\r: ");
                if (Console.ReadKey(true).Key == ConsoleKey.Escape) Hero.Menu();

                string name = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Well, now you have 20 points, u can upgrade any stats you want");
                Name = name;
                Strength = 5;
                Dexterity = 5;
                Intelligence = 5;

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
                HP = 50 + Strength * 2;
                MP = 30 + Intelligence * 3;
                Console.WriteLine("Hero created!");
                Console.WriteLine("Str:{0} Dex:{1} Int:{2} MP:{3} HP:{4}", Strength, Dexterity, Intelligence, MP, HP);
                Console.WriteLine("Press ANY key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            else Console.WriteLine("Something went wrong...");
        }
    }
}
