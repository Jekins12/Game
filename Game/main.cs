using System;

namespace Game
{
    class main
    {
        static void Main(string[] args)
        {
            //
            IfExist.Json();
            while (true)
            {

                int ans = Hero.Menu();
                switch (ans)
                {
                    case 1:
                        Hero.New();
                        break;

                    case 2:
                        Single.Solo();
                        break;

                    case 3:
                        Multiplayer.Multi();
                        break;

                    case 4:
                        Hero.Stats();
                        break;

                    case 5:
                        Environment.Exit(1);
                        break;
                }
            }
        }
    }
}
