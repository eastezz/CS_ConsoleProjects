using System.Collections.Generic;

namespace MusicPlayerApp
{
    public class UppercaseWrapper : IMusicPlayer
    {
        private readonly IMusicPlayer player;

        public UppercaseWrapper(IMusicPlayer player)
        {
            this.player = player;
        }

        public void LoadLyricsFromFile(string filename)
        {
            player.LoadLyricsFromFile(filename);
        }

        public List<string> GetLyrics()
        {
            var original = player.GetLyrics();
            var upper = new List<string>();

            foreach (var line in original)
                upper.Add(line.ToUpper());

            return upper;
        }

        public bool MoveNext()
        {
            return player.MoveNext();
        }

        public void Reset()
        {
            player.Reset();
        }

        public string Current => player.Current.ToUpper();

        object System.Collections.IEnumerator.Current => Current;

        public void Dispose() { }
    }
}