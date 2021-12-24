using System;

namespace Game
{
    class Key
    {
        public static int Pressed(int num)
        {
            int opt = 0;
            while (opt == 0)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1: opt = 1; break;

                    case ConsoleKey.D2: opt = 2; break;

                    case ConsoleKey.D3: opt = 3; break;

                    case ConsoleKey.D4: opt = 4; break;

                    case ConsoleKey.D5: opt = 5; break;
                }
                if (opt > num)
                {
                    Console.WriteLine("Error, try again...");
                    opt = 0;
                }
            }
            return opt;
        }
    }
}
