using System;

namespace Game
{
    class Timer
    {
        public static void Count(int x)
        {
            for (int a = x; a >= 0; a--)
            {
                Console.Write("\rFight starts in {0:00}", a);
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
