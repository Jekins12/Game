using Newtonsoft.Json;
using System.IO;


namespace Game
{
    class CreateFile
    {
        public static void Load()
        {
            string path = "./hero.json";
            var myData = new
            {
                Name = "",
                Strength = 0,
                Dexterity = 0,
                Intelligence = 0,
                HP = 0,
                MP = 0,
                XP = 0,
                LVL = 0
            };
            string jsonData = JsonConvert.SerializeObject(myData);
            File.WriteAllText(path, jsonData);

        }
    }
}
