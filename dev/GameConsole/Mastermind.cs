/*
    Mastermind Game Class
*/

namespace GameConsole;

public class Mastermind
{

    //Fields
    private string _instructions = "What's the sequence? Each  item can be either RED, BLUE, GREEN, or Yellow \r\n";
    private bool _solved;
    private int _size;
    private int _numTries;

    //Constructor
    public Mastermind()
    {
        _solved = false;
        _numTries = 1;
    }

    // Play
    public void Play()
    {
        Console.Clear();
        Console.WriteLine("\r\n=======================================");
        Console.WriteLine("MASTERMIND");
        Console.WriteLine("=======================================");

        //Display instructions
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(_instructions);
        Console.ResetColor();

        //Generate sequence
        Console.WriteLine("----------------");
        _size = ValidateInt("How many colors should the sequence contain?");

        Sequence sequence = new Sequence(_size);
        sequence.Display();

        //play until solved
        while (!_solved)
        {
            Console.Write("Please guess the sequence: ");
            string[] guess = Console.ReadLine().ToUpper().Split();

            //compare sequence to guess
            int numCorrect = sequence.Display(guess);
            if (numCorrect < _size)
            {
                Console.WriteLine($"{numCorrect} Correct, try again");
                Console.WriteLine("=======================================");
                Console.WriteLine("");
                _numTries++;
            }
            else
            {
                _solved = true;
            }
        }
        //solved message
        Console.WriteLine("=======================================");
        Console.WriteLine("Congrats, you solved the seuqence!");
        Console.WriteLine($"Score: {Score(sequence)}");
        Console.WriteLine("=======================================");
    }

    public int ValidateInt(string message)
    {
        Console.WriteLine(message);

        string userString = Console.ReadLine();
        int userInt;

        //validate intput is a number greater than 0
        while (!(int.TryParse(userString, out userInt)) || userInt < 0)
        {
            //output error and catch input again
            Console.Write("Incorrect option, please try again: ");
            userString = Console.ReadLine();
        }

        //return validated integer
        return userInt;
    }

    public int Score(Sequence sequence)
    {
        return (sequence.Size * 1000) / _numTries;
    }

    // End class
}