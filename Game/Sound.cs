using System.Media;

namespace Game
{
    class Sound
    {
        public static void Play(string play)
        { 
                SoundPlayer player = new("./sound/" + play + ".wav");

                if (play == "stop")
                    player.Stop();
                else
                {
                    player.Load();
                    player.Play();
                }
        }
    }
}