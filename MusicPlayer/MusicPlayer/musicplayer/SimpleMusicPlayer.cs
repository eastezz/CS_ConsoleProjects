using System.Collections.Generic;
using System.IO;

namespace MusicPlayerApp
{
    public class SimpleMusicPlayer : IMusicPlayer
    {
        private List<string> lyrics = new List<string>();
        private int index = -1;

        public SimpleMusicPlayer(string filename)
        {
            LoadLyricsFromFile(filename);
        }

        public void LoadLyricsFromFile(string filename)
        {
            lyrics = new List<string>(File.ReadAllLines(filename));
            index = -1;
        }

        public List<string> GetLyrics()
        {
            return lyrics;
        }

        public bool MoveNext()
        {
            index++;
            return index < lyrics.Count;
        }

        public void Reset()
        {
            index = -1;
        }

        public string Current => lyrics[index];

        object System.Collections.IEnumerator.Current => Current;

        public void Dispose() { }
    }
}