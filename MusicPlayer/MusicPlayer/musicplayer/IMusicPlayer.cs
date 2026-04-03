using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace MusicPlayerApp
{
    public interface IMusicPlayer : IEnumerator<string>
    {
        void LoadLyricsFromFile(string filename);
        List<string> GetLyrics();
    }
}