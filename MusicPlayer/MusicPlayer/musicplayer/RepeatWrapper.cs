using System.Collections.Generic;

namespace MusicPlayerApp
{
    public class RepeatWrapper : IMusicPlayer
    {
        private readonly IMusicPlayer player;

        public RepeatWrapper(IMusicPlayer player)
        {
            this.player = player;
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
            if (!player.MoveNext())
            {
                player.Reset();
                return player.MoveNext();
            }
            return true;
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