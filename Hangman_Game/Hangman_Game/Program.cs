using System;
using System.Collections.Generic;
class HangmanGame
{
    static void Main()
    {
        Console.WriteLine("Enter the secret word:");
        string secretWord = Console.ReadLine().ToLower();
        List<char> hiddenLetters = new List<char>();
        int guesses = 6;
        char letter;
        bool isCorrect;
        for (int i = 0; i < secretWord.Length; i++)
        {
            hiddenLetters.Add('_');
        }

        while (true)
        {
            isCorrect = false;
            Console.WriteLine("Current progress:");
            foreach (char i in hiddenLetters)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine($"\n You have {guesses} wrong guesses left.");

            Console.Write("Guess a letter: ");
            letter = Console.ReadLine()[0];
            letter = char.ToLower(letter);

            for (int i = 0; i < secretWord.Length; i++)
            {
                if (letter.Equals(secretWord[i]) && !hiddenLetters.Contains(letter))
                {
                    hiddenLetters[i] = secretWord[i];
                    isCorrect = true;
                }
            }

            if (!isCorrect) guesses--;

            if (guesses == 0)
            {
                Console.WriteLine($"Game over! The word was {secretWord}");
                break;
            }

            if (!hiddenLetters.Contains('_'))
            {
                Console.WriteLine($"Congratulations! You've guessed the word: {secretWord}");
                break;
            }
        }
    }
}

