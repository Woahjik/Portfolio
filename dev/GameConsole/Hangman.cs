/*
    Hangman Game Class
*/

namespace GameConsole;

public class Hangman
{
    //fields
    private Random _random = new Random();
    private List<string> _words = new List<string>();
    private Dictionary<string, string> _gameDicitonary = new Dictionary<string, string>();
    private List<string> _guesses = new List<string>();
    private List<string> _misses = new List<string>();

    //constructor
    public Hangman()
    {
        //open file containing words and definitions
        using(StreamReader sr = new StreamReader("../../../Dictionary.txt"))
        {
            //read each line, split the line between the word and definition, and add it to the word list and the game dictionary
            string line;
            while((line = sr.ReadLine()) != null)
            {
                string [] data = line.Split(':');
                _words.Add(data[0]);
                _gameDicitonary.Add(data[0], data[1]);
            }
        }
    }

    public void Play()
    {
        //select random word from the game dictionary
        string word = _words[_random.Next(0, _words.Count)];

        //instantiate a gallows object with the random word/definition
        Gallows gallows = new Gallows(word, _gameDicitonary[word]);
        
        //boolean to store game state - whether or not the game has been solved
        bool isSolved = false;

        //loop while the game is not solved and until 6 incorrect letters have been guessed
        while(!isSolved && _misses.Count < 6)
        {
            //display gallows
            gallows.DisplayGallows(_guesses);

            //spacing
            Console.WriteLine("\r\n----------------------------------------");

            //display missed letters
            DisplayMisses();
            Console.WriteLine();

            //get input from guess letter method
            GuessLetter(word);

            //set gmae state boolean to the check win method
            isSolved = gallows.CheckWin(_guesses);
        }

        //call display method a final time to display completed word
        gallows.DisplayGallows(_guesses);

        //winning message
        if(isSolved)
        {
            Console.WriteLine("\r\n=======================================");
            Console.WriteLine("Congratulations! You won!");
        }
        //losing message
        else
        {
            Console.WriteLine("\r\n=======================================");
            Console.WriteLine("Hangman! You lost!");
        }
        //spacing
        Console.WriteLine("=======================================\r\n");
    }

    //display missed/wrong letters method
    public void DisplayMisses()
    {
        //loop through the missed list and output missed letters
        Console.Write("Missed letters: ");
        foreach(string miss in _misses)
        {
            Console.Write($"{miss} ");
        }
    }

    //guess letter method
    public void GuessLetter(string word)
    {
        //prompt user to enter a letter and catch the input
        Console.WriteLine("\r\n=======================================");
        Console.Write("Choose a letter: ");
        string letter = Console.ReadLine().ToUpper();

        //valiadte input
        while(string.IsNullOrWhiteSpace(letter) || _guesses.Contains(letter) || _misses.Contains(letter) || letter.Length != 1)
        {
            //output error and catch input again
            Console.Write("Invalid input, please try again: ");
            letter = Console.ReadLine().ToUpper();
        }

        //if user input is in the answer, add letter to guess list
        if(word.Contains(letter))
            _guesses.Add(letter);
        //if user input is not in the answer and hasn't been sotres in the missed list, add letter to missed list
        else if(!_misses.Contains(letter) && !word.Contains(letter))
            _misses.Add(letter);
    }
}