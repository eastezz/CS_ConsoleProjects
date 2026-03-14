Console.WriteLine("Enter the secrete word:");
string secret_word = Console.ReadLine();
List<char> hidden_letters = new List<char>();
int guesses = 6;
char letter;
bool isCorrect = false;
for(int i = 0; i < secret_word.Length; i++)
{
    hidden_letters.Add('_');
}

while(true)
{
    Console.WriteLine("Current progress:");
    foreach(char i in hidden_letters)
    {
        Console.Write(i + " ");
    }
    Console.WriteLine($"\n You have {guesses} wrong guesses left.");

    Console.Write("Guess a letter: ");
    letter = (char)Console.Read();

    for(int i = 0; i < secret_word.Length; i++)
    {
        if ((int)letter == secret_word[i])
        {
            hidden_letters[i] = (char)secret_word[i];
            isCorrect = true;
        }
    }

    if (!isCorrect) guesses--;
    isCorrect = false;

    for(int i = 0; i < secret_word.Length; i++)
    {
        string final_world = string.Join("",hidden_letters);
    }


    
}

