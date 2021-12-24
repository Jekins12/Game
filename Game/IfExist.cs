using System;
using System.IO;

namespace Game
{
    class IfExist
    {
        public static void Json()
        {
            string path = "./hero.json";
            try
            {
                File.ReadAllText(path);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Load file does not exist\r\n");
                Timer.Count(1, null,500);
                Console.WriteLine("Creating new load file...\r\n");
                Timer.Count(1, null,500);
                CreateFile.Load();
                Console.WriteLine("New load file has been created\r\n");
                Timer.Count(1, null,500);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("CREATE A NEW HERO");
                Console.ResetColor();
                Hero.New("hero");
            }
        }
    }
}
