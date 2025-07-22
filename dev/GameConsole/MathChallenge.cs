/*
    Math Challenge Game Class
*/

namespace GameConsole;

public class MathChallenge
{
    //Fields
    private string _title;
    private int _score;
    private int _level;
    private List<string> _instructions = new List<string>
    {
        "Are you good at math? Put your wits to the test! This game is simple... you will be provided with a math problem. Answer correctly and move on to the next level.",
        "Solutions are rounded down.",
        "Points are awarded based on the number of correct answers."
    };

    //Constructor
    public MathChallenge()
    {
        _score = 0;
        _level = 1;
    }

    //Play method
    public void Play()
    {
        //clear console and show game title
        Console.Clear();
        Console.WriteLine("=======================================");
        Console.WriteLine("MASTERMIND");
        Console.WriteLine("=======================================\r\n");

        //display game instructions
        Instructions();

        //boolean to store whether or not the user enters a correct number
        bool correct = true;

        //store number of problems

        //loop while the user keeps answering correctly
        while(correct)
        {
            //declare problem object
            Problem problem = new Problem();

            //print spacing, then print level and expression
            Console.WriteLine("\r\n------------------");
            Console.Write($"[{_level}]: {problem.Expression} = ");

            //catch user input
            int answer = ValidateAnswer();

            //if answer was correct
            if(answer == problem.Solution)
            {
                //print correct, call add score method and increase the level count
                Console.WriteLine("Correct!");
                AddScore();
                _level++;
            }
            //if answer was incorrect
            else
            {
                //print incorrect, set loop boolean to false
                Console.WriteLine("Sorry, that is incorrect!");
                correct = false;
            }
        }
        //print score
        Console.WriteLine("\r\n=======================================");
        Console.WriteLine($"Your score: {_score}");
        Console.WriteLine("=======================================\r\n");
}

    //show instructions method
    private void Instructions()
    {
        //loop through list of instructions and print them
        foreach(string step in _instructions)
        {
            Console.WriteLine(step);
        }
    }

    //validate answer method
    private int ValidateAnswer()
    {
        //catch user input and declare int to hold number
        string userAnswerString = Console.ReadLine();
        int userAnswer;

        //validate that user entered a whole number, positive or negative
        while(!(int.TryParse(userAnswerString, out userAnswer)))
        {
            //print error and catch user input again
            Console.Write("Invalid, try again: ");
            userAnswerString = Console.ReadLine();
        }

        //return user answer
        return userAnswer;
    }

    //add score method
    private void AddScore()
    {
        //add 10 to score for every correct answer
        _score += 10;
    }

}