using Newtonsoft.Json.Linq;
using System.IO;


namespace Game
{
    class Save
    {
        public static void save(string name, int str, int dex, int intl, int lvl, int xp)
        {
            string path = "./hero.json";
            string data = File.ReadAllText(path);
            JObject Hero = JObject.Parse(data);
            if (name != "default") Hero["Name"] = name;
            Hero["Strength"] = str;
            Hero["Dexterity"] = dex;
            Hero["Intelligence"] = intl;
            Hero["XP"] = xp;
            Hero["LVL"] = lvl;
            File.WriteAllText("./hero.json", Hero.ToString());
        }
    }
}
