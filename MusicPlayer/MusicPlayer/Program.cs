using System;
using MusicPlayerApp;

namespace MusicPlayerApp
{
    class Program
    {
        private static void PrintLyrics(IMusicPlayer player)
        {
            while (player.MoveNext())
            {
                Console.WriteLine(player.Current);
            }
        }

        static void Main(string[] args)
        {
            try
            {
                string fname = "YourPath\\Song.txt";

                IMusicPlayer player1 = MusicPlayerFactory.CreatePlayer(fname, true, false, 0);
                IMusicPlayer player2 = MusicPlayerFactory.CreatePlayer(fname, false, true, 0);
                IMusicPlayer player3 = MusicPlayerFactory.CreatePlayer(fname, true, false, 250);

                Console.WriteLine("Player 1: ");
                // PrintLyrics(player1);

                Console.WriteLine("Player 2: ");
                // PrintLyrics(player2);

                Console.WriteLine("Player 3: ");
                // PrintLyrics(player3);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error loading lyrics: " + e.Message);
            }
        }
    }
}