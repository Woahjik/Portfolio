/*
  Game Console Program

  * * * * *

  Text-based game console that allows you to store user credentials.
  After siging in, you can play 5 different text-based games.
  You can also register a new user or view information about your user profile.
*/

namespace GameConsole;

class Program
{
    //main method
    static void Main(string[] args)
    {
        //clear console for readability
        Console.Clear();

        //declare console name
        string consoleName = "WojBox5000";

        //call landing screen function to display the console name inside a header
        LandingScreen(consoleName);

        //instantiate user object
        User user1 = User.Login();

        //call home screen function
        HomeScreen(user1);
    }

    //landing screen function
    private static void LandingScreen(string consoleName)
    {
        //call header function from UI class with console name passed in
        UI.Header(consoleName);

        //call footer function from UI class with a message passed in that prompts the user to enter a key to continue
        UI.Footer("Press any key to get started...\r\n");

        //program pauses until user inputs something
        Console.ReadLine();
    }

    //home screen method
    private static void HomeScreen(User user1)
    {
        //boolean to keep displaying the menu
        bool continueLoop = true;

        //display menu until conditional is false
        while(continueLoop)
        {
            //clear console for readability
            Console.Clear();

            //call header function and pass in user name
            UI.Header($"Welcome {user1.UserName}!");

            //instantiate games menu, user menu, and system menu
            Menu gameMenu = new Menu(new List<string> {
                "[1] HighLow",
                "[2] TicTacToe",
                "[3] MathChallenge",
                "[4] MasterMind",
                "[5] Hangman"
            });

            Menu userMenu = new Menu(new List<string> {
                "[6] View Profile",
                "[7] Register New User"
            });

            Menu systemMenu = new Menu(new List<string> {
                "[0] Exit"
            });

            //show each menu
            gameMenu.DisplayOptions();
            Console.WriteLine();
            userMenu.DisplayOptions();
            Console.WriteLine();
            systemMenu.DisplayOptions();

            //set loop conditional equal to the menu selection method call
            continueLoop = MenuSelection(user1);
        }
        
        //print goodbye message
        UI.Footer("Thank you for playing, have a great day!");
    }

    //menu selection method
    public static bool MenuSelection(User user)
    {
        //prompt user to choose a game from the list
        UI.Separator();
        Console.Write("Please choose a game: ");

        //program pauses until user inputs something
        int userChoice = Validation.ValidateRange(0, 7);

        //clear console
        Console.Clear();

        //switch statement for options 0 through 7
        switch(userChoice)
        {
            //select highlow game
            case 1:
                //play highlow game
                HighLow hL = new HighLow();
                hL.Play();
                Console.ReadLine();
                break;
            //select tic tac toe game
            case 2:
                //play tictactoe
                TicTacToe tTT = new TicTacToe();
                tTT.Play();
                Console.ReadLine();
                break;
            //select math challenge game
            case 3:
                //play math challenge game
                MathChallenge mC = new MathChallenge();
                mC.Play();
                Console.ReadLine();
                break;
            //select mastermind game
            case 4:
                //play mastermind game
                Mastermind mM = new Mastermind();
                mM.Play();
                Console.ReadLine();
                break;
            //select hangman game    
            case 5:
                //play hangman
                Hangman hM = new Hangman();
                hM.Play();
                Console.ReadLine();
                break;
            //select display current user profile
            case 6:
                UI.Header("User Profile");
                user.DisplayProfile();
                UI.Footer("Please press any key to return to the menu...");
                Console.ReadLine();
                break;
            //select new user registration
            case 7:
                UI.Header("Register New User");
                User.RegisterNewUser();
                UI.Footer("Please press any key to return to the menu...");
                Console.ReadLine();
                break;
            //select exit application and return false
            default:
                return false;
        }
        //return tru to continue menu loop
        return true;
    }
}
