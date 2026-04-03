using System.IO;

namespace MusicPlayerApp
{
    public static class MusicPlayerFactory
    {
        public static IMusicPlayer CreatePlayer(string filename, bool capitalize, bool repeat, int delayMillis)
        {
            IMusicPlayer player = new SimpleMusicPlayer(filename);

            if (capitalize)
                player = new UppercaseWrapper(player);

            if (repeat)
                player = new RepeatWrapper(player);

            if (delayMillis > 0)
                player = new DelayWrapper(player, delayMillis);

            return player;
        }
    }
}