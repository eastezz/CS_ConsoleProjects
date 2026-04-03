using System.Collections.Generic;
using System.Threading;

namespace MusicPlayerApp
{
    public class DelayWrapper : IMusicPlayer
    {
        private readonly IMusicPlayer player;
        private readonly int delayMillis;

        public DelayWrapper(IMusicPlayer player, int delayMillis)
        {
            this.player = player;
            this.delayMillis = delayMillis;
        }

        public void LoadLyricsFromFile(string filename)
        {
            player.LoadLyricsFromFile(filename);
        }

        public List<string> GetLyrics()
        {
            return player.GetLyrics();
        }

        public bool MoveNext()
        {
            var result = player.MoveNext();
            if (result)
                Thread.Sleep(delayMillis);

            return result;
        }

        public void Reset()
        {
            player.Reset();
        }

        public string Current => player.Current;

        object System.Collections.IEnumerator.Current => Current;

        public void Dispose() { }
    }
}