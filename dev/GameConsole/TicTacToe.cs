/*
    TicTacToe Game Class
*/

public class TicTacToe
{
    public void Play()
    {
        //local variables
        string [] spaces = {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
        string winner = null;
        bool staleMate = false;

        string player;
        string marker;

        //display game board
        DisplayBoard(spaces);

        //play until someone wins or a draw occurs
        int turns = 1;
        while(winner == null && !staleMate)
        {
            //select player and marker (x or o)
            player = (turns % 2 == 0) ? "Player 2" : "Player 1";
            marker = (turns % 2 == 0) ? "0" : "X";

            //choose space
            int space = ValidateSpace(spaces, $"[{player}]: Please choose a space...") - 1;
            spaces[space] = marker;

            //refresh board to show selected space
            DisplayBoard(spaces);

            //check for winners
            winner = CheckWinner(spaces, marker);
            staleMate = CheckStaleMate(spaces, winner);

            turns++;
        }

        if(winner != null)
        {
            Console.WriteLine("=====================");
            Console.WriteLine($"Winner: {winner}");
            Console.WriteLine("=====================");
        }
        else if(staleMate)
        {
            Console.WriteLine("=====================");
            Console.WriteLine("Oops! Looks like there is a draw!");
            Console.WriteLine("=====================");
        }
    }

    private int ValidateSpace(string [] spaces, string message)
    {
        Console.WriteLine(message);
        string input = Console.ReadLine();
        int guess;

        //validate input
        while(!(int.TryParse(input, out guess)) || guess < 0 || guess > 9 || spaces[guess - 1] == "X" || spaces[guess - 1] == "0")
        {
            Console.Write("Invalid input, please try again!");
            input = Console.ReadLine();
        }
        return guess;
    }

    private void DisplayBoard(string[] spaces)
    {
        Console.Clear();

        Console.WriteLine("================================================");
        Console.WriteLine(" Tic Tac Toe");
        Console.WriteLine("================================================\r\n");

        Console.WriteLine("\r\n     |     |     ");
        Console.WriteLine($"  {spaces[0]}  |  {spaces[1]}  |  {spaces[2]}");
        Console.WriteLine(" ____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {spaces[3]}  |  {spaces[4]}  |  {spaces[5]}");
        Console.WriteLine(" ____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {spaces[6]}  |  {spaces[7]}  |  {spaces[8]}");
        Console.WriteLine("     |     |     ");
    }

    private string CheckWinner(string[] spaces, string marker)
    {
        string winner = null;
        if(
            //Horizontals
            (spaces[0] == spaces[1] &&spaces[1] == spaces[2])
            || (spaces[3] == spaces[4] &&spaces[4] == spaces[5])
            || (spaces[6] == spaces[7] &&spaces[7] == spaces[8])
            //Verticals
            || (spaces[0] == spaces[3] &&spaces[3] == spaces[6])
            || (spaces[1] == spaces[4] &&spaces[4] == spaces[7])
            || (spaces[2] == spaces[5] &&spaces[5] == spaces[8])
            //Diagonals
            || (spaces[0] == spaces[4] &&spaces[4] == spaces[8])
            || (spaces[2] == spaces[4] &&spaces[4] == spaces[6])
        )
        {
            winner = marker;
        }
        return winner;
    }

    private bool CheckStaleMate(string[] spaces, string winner)
    {
        bool staleMate = false;
        if(winner == null && spaces.Distinct().Count() == 2)
        {
            staleMate = true;
        }
        return staleMate;
    }

}