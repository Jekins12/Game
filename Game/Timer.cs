using System;

namespace Game
{
    class Timer
    {
        public static void Count(int x, string print)
        {
            for (int a = x; a >= 0; a--)
            {
                if (print == "fight")
                {
                    Console.Write("\rFight starts in {0:00}", a + 1);
                }

                else if (print == "escape")
                {
                    Console.Clear();
                    switch (a)
                    {
                        case 2: Console.Write("Escaping."); break; 
                        case 1: Console.Write("Escaping.."); break;
                        case 0: Console.Write("Escaping..."); break;

                    }
                }
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
