 using System.Collections.Generic;

namespace Wordle;

class Program
{
    static void Main(string[] args)
    {
        //welcome message
        //Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("Hello and welcome to Wordle!");

        bool continueLoop = true;

        //call game method while bool is true
        while(continueLoop)
        {
            Wordle.Play();

            //set while loop conditional to return value of play again method
            continueLoop = PlayAgain();
        }

        //goodbye message
        Console.WriteLine("Thanks for playing...\r\nGoodbye!");
        
    }

    //method to determine whether or not the game is played again
    private static bool PlayAgain()
    {
        //ask user if they want to play again
        Console.WriteLine("Would you like to play again? [yes/no]");
        string again = Console.ReadLine();

        //validate user entered either yes or no - no other input will be accepted
        while(again.ToLower() != "yes" && again.ToLower() != "no")
        {
            Console.Write("Please only enter yes or no!");
            again = Console.ReadLine();
        }

        //return bool
        return again.ToLower() == "yes" ? true : false;
    }
}
