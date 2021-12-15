using System.IO;
using Newtonsoft.Json.Linq;


namespace Game
{
    class Save
    {
        public static void save(string name, int str, int dex, int intl, int lvl, int xp)
        {
            string data = File.ReadAllText("./hero.json");
            JObject Hero = JObject.Parse(data);
            if (name != "default")
            {
                Hero["Name"] = name;
            }
            Hero["Strength"] = str;
            Hero["Dexterity"] = dex;
            Hero["Intelligence"] = intl;
            Hero["XP"] = xp;
            Hero["LVL"] = lvl;
            File.WriteAllText("./hero.json", Hero.ToString());

        }
    }
}
