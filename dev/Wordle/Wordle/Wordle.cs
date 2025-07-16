using System.Collections.Generic;
using System.IO;

namespace Wordle;

public class Wordle
{
    //play (main gameplay method)
    public static void Play()
    {
        //clear console for readability
        Console.Clear();

        //declare file path name, select a random line number, and select the word on that line
        string fileName = "/Users/alex/Documents/Personal Projects/C#/Wordle/Wordle/words.txt";
        Random random = new Random();
        int lineNum = random.Next(0, File.ReadLines(fileName).Count());
        string answer = File.ReadLines(fileName).Skip(lineNum).Take(1).First();
        
        //list to store guess history, empty guesss variable, boolean for winner conditional
        List<char[]> guessHistory = new List<char[]>();
        string guess = "";
        bool winner = false;

        //populate list with _ to denote blank spaces
        FillBlanks(guessHistory);

        //loop 6 times (6 guesses)
        for(int i = 0; i < 6; i++)
        {
            //display game board with guess history and hint spaces for each letter
            BuildBoard(guessHistory, answer);

            //user enters input
            Console.Write("\r\nPlease enter a 5-letter word: ");
            guess = Console.ReadLine();

            //validate guess
            while(!ValidateGuess(guess))
            {
                Console.Write("Invalid input! Please only enter a 5-letter word: ");
                guess = Console.ReadLine();
            }

            //add va;lidated guess to guess history and remove blank spaces
            guessHistory.Insert(i, guess.ToCharArray());
            guessHistory.RemoveAt(i + 1);

            //break loop if answer is entered
            if(guess == answer)
            {
                winner = true;
                break;
            }
        }

        //build board one last time
        BuildBoard(guessHistory, answer);

        //display output if user won or lost
        if(winner)
        {
            Console.WriteLine("\r\n============================================");
            Console.WriteLine($"\r\nCongratulations! {guess} was the correct answer!\r\nPlease press any key to continue...");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("\r\n============================================");
            Console.WriteLine($"\r\nYou lose! {answer} was the correct answer!\r\nPlease press any key to continue...");
            Console.ReadLine();
        } 
        
    }

    //validate guess
    private static bool ValidateGuess(string guess)
    {
        //user cannot enter a blank string and must enter 5 letters exactly
        if(string.IsNullOrWhiteSpace(guess) || guess.Length != 5)
            return false;
        //user can only enter a-z
        foreach(char c in guess.ToCharArray())
        {
            if(!char.IsLetter(c))
                return false;
        }
        return true;
    }

    //build board method
    private static void BuildBoard(List<char[]> guessHistory, string answer)
    {
        //readability
        Console.Clear();

        //split answer into character array
        char[] answerLetters = answer.ToCharArray();

        Console.WriteLine("You have entered the words: ");

        //nested for/foreach loop that will print 5 separate characters 6 times
        foreach(char[] letters in guessHistory)
        {
            //display hint for each letter - ! is right letter right space, ? is right letter wrong space, blank is not in answer
            for(int i = 0; i < 5; i++)
            {
                if(letters[i] == answerLetters[i])
                    Console.Write("! ");
                else if(answerLetters.Contains(letters[i]))
                    Console.Write("? ");
                else
                    Console.Write("  ");
            }
            Console.WriteLine();
            
            //print letter for guess
            foreach(char letter in letters)
            {
                Console.Write($"{letter} ");
            }
            Console.WriteLine();
        }
        
    }
    //fill blank method
    private static void FillBlanks(List<char[]> guessHistory)
    {
        //fill guess history list with _ for each character
        for(int i = 0; i < 6; i++)
        {
            guessHistory.Add(new char[] {'_', '_', '_', '_', '_'});
        }
    }
}