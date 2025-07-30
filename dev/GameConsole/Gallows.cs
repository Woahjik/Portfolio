/*
    Gallows Class for Hangman Game
*/

namespace GameConsole;

public class Gallows
{
    //definition field
    private string _definition;

    //word property
    public string Word {get; set;}

    //constructor
    public Gallows(string word, string definition)
    {
        //set word and definition
        Word = word;
        _definition = definition;
    }

    //display gallows method
    public void DisplayGallows(List<string> letters = null)
    {
        //clear console and display header
        Console.Clear();
        Console.WriteLine("=======================================");
        Console.WriteLine("MASTERMIND");
        Console.WriteLine("=======================================\r\n");

        //print definition hint
        Console.WriteLine($"Hint: {_definition}\r\n");

        //loop through each letter in the word (answer)
        foreach(char i in Word)
        {
            //check if passed in list of letters is not null and the list contains the current letter in the answer
            if(letters != null && letters.Contains(i.ToString()))
            {
                //print letter
                Console.Write($"{i} ");
            }
            else
            {
                //print underscore (hidden letter)
                Console.Write("_ ");
            }
        }
        Console.WriteLine();

    }

    //check win method
    public bool CheckWin(List<string> letters)
    {
        //loop through letters in answer
        foreach(char i in Word)
        {
            //if list of guessed letters doesn't contain the current letter of the answer, return false
            if(!letters.Contains(i.ToString()))
            {
                return false;
            }
        }
        //return true if the end of this method is reached
        return true;
    }

}