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

        // Fills the list with a symbols to create an apropriate interface
        foreach (char i in secretWord)
        {
            hiddenLetters.Add('_');
        }

        // Used to prevent letters duplicate
        HashSet<char> usedLetters = new HashSet<char>(); 

        while (guesses > 0)
        {
            isCorrect = false;
            Console.WriteLine("Current progress:");
            Console.WriteLine(string.Join(" ", hiddenLetters));
            Console.WriteLine($"You have {guesses} wrong guesses left.\n Guess a leter: ");

            letter = char.ToLower(Console.ReadLine()[0]);

            // Prevent repeated guesses
            if (usedLetters.Contains(letter))
            {
                Console.WriteLine("You already guessed that letter!");
                Console.ReadKey();
                continue;
            }

            usedLetters.Add(letter);

            // Matchs the letter (main logic)
            for (int i = 0; i < secretWord.Length; i++)
            {
                if (letter.Equals(secretWord[i]))
                {
                    hiddenLetters[i] = secretWord[i];
                    isCorrect = true;
                }
            }

            if (!isCorrect) guesses--;

            // Win condition
            if (!hiddenLetters.Contains('_'))
            {
                Console.WriteLine($"Congratulations! You've guessed the word: {secretWord}");
                return;
            }
        }
        // Lose condition
        Console.WriteLine($"Game over! The word was {secretWord}");
    }
}

