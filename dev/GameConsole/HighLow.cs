/*
   HighLow Game Class
*/

using System.Xml.Schema;

public class HighLow
{
    public void Play()
    {
        //clear console
        Console.Clear();
        
        //game title
        Console.WriteLine("=================================");
        Console.WriteLine("HIGH-LOW");
        Console.WriteLine("=================================");

        //game description and rules
        Console.WriteLine("This game is simple. You will be asked to guess a number. If incorrect, a hint will be provided before asking for another guess. This repeats until you've guessed correctly. Points are awarded based on maximum number and number of guesses.\r\n");

        //prompt for maximum number 
        Console.WriteLine("----------------");
        Console.Write("Maximum number: ");

        //store max number as the return value of the validate method
        int maxNumber = ValidateNum();

        //declare random class and generate a random number between 1 and max number entered by the user
        Random random = new Random();
        int answer = random.Next(1, maxNumber);

        //declare boolean for storing winner
        bool win = false;

        //declare integer to store turns
        int turns = 0;
        while(!win)
        {
            //increment turns
            turns++;

            //prompt user for the first guess
            Console.WriteLine("----------------");
            Console.Write($"Guess [{turns}]: ");

            //decalre int to hold return value of the validate method, which will retun the user's guess
            int userGuess = ValidateNum();

            //check if game has been won
            win = CheckWin(userGuess, answer);
        }

        //declare variable to calculate score based on max number and amount of guesses
        int score = CalculateScore(maxNumber, turns);

        //output score
        Console.WriteLine($"Final score: {score} points!");
        
    }

    //validation function
    private int ValidateNum()
    {
        //declare string to hold user input and declare an int for parsing input
        string numString = Console.ReadLine();
        int userNum;

        //validate input
        while(!(int.TryParse(numString, out userNum)) || userNum < 1)
        {
            //output error and get user input again
            Console.Write("Invalid input! Please try again: ");
            numString = Console.ReadLine();
        }

        //return number
        return userNum;
    }

    //check win function
    private bool CheckWin(int guess, int answer)
    {
        //declare boolean return value
        bool win = false;

        //check if answer and guess are equal
        if(guess < answer)
        {
            //output hint
            Console.WriteLine($"Sorry, {guess} is too low");
        }
        else if(guess > answer)
        {
            //output hint
            Console.WriteLine($"Sorry, {guess} is too high");
        }
        else
        {
            //output winning message and set return value to true
            Console.WriteLine($"Congrats! {guess} is the correct answer!");
            win  = true;
        }

        //return win boolean
        return win;
    }

    private int CalculateScore(int maxNum, int turns)
    {
        //declare score variable
        int score = 0;

        //conditional statements to for score multipliers
        if(turns == 1)
        {
            //super high score if correctly guessed on the first try
            score = maxNum * 50;
        }
        //3 or fewer guesses
        else if(turns <= 3)
        {
            score = maxNum * 10;
        }
        //between 4 and 8 guesses
        else if(turns <= 8)
        {
            score = maxNum * 5;
        }
        //over 8 guesses
        else
        {
            score = maxNum * 2;
        }

        //return score
        return score;
    }
}

