/*
    User Class
*/

namespace GameConsole;

public class User
{
    //Fields
    private int _age;
    private string _theme;

    //Property so user name can be accessed in the program class
    public string UserName {get; set;}

    //Constructor
    public User(string userName, int age, string theme)
    {
        UserName = userName;
        _age = age;
        _theme = theme;
        SetTheme(_theme);
    }

    //set theme based on user preference
    public void SetTheme(string theme)
    {
        //set console theme to dark
        if(theme.ToLower() == "dark")
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        //set console theme to white
        else
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
        }
    }

    //display user profile
    public void DisplayProfile()
    {
        //display user profile fields
        Console.WriteLine($"[Username]: {UserName}");
        Console.WriteLine($"[Age]: {_age}");
        Console.WriteLine($"[Theme]: {_theme}");
    }

    public static User Login()
    {   
        //null user object
        User user = null;

        //bool that prevents user from logging in unless a correct username and password are entered
        bool isLoggedIn = false;

        //loop until user logs in correctly
        while(!isLoggedIn)
        {
            //clear console and display header
            Console.Clear();
            UI.Header("Please Log In");
        
            //catch and validate username and password
            Console.Write("Username: ");
            string userName = Validation.ValidateString();
            Console.Write("Password: ");
            string password = Validation.ValidateString();

            //create file stream reader
            using(StreamReader sr = new StreamReader("../../../Users.txt"))
            {
                //loop through each line
                string line;
                int age;
                while((line = sr.ReadLine()) != null)
                {
                    //split line and compare the entered username and password with the stored username and password on each line until one matches
                    string [] userInfo = line.Split(",");
                    if(userInfo[0] == userName && userInfo[1] == password)
                    {
                        //convert third line element to integer and set user object to new user with information from file
                        int.TryParse(userInfo[2], out age);
                        user = new User(userInfo[0], age, userInfo[3]);
                        
                        //set while loop conditional to true, ending the login process
                        isLoggedIn = true;
                    }
                }
            }
            //display error if user is not logged in
            if(!isLoggedIn)
            {
                UI.Separator();
                Console.WriteLine("Invalid, try again: ");
                Console.ReadLine();
            }
        }
        //return new user after a valid username and password have been entered
        return user;
    }

    public static void RegisterNewUser()
    {
        //catch and validate username, password, age, and theme
        Console.Write("Username: ");
        string userName = Validation.ValidateString();
        Console.Write("Password: ");
        string password = Validation.ValidateString();
        Console.Write("Age: ");
        int age = Validation.ValidateInt();
        Console.Write("Theme (light/dark): ");
        string theme = Validation.ValidateList(new List<string>{"light", "dark"});

        //create file stream writer using append method
        using(StreamWriter sw = File.AppendText("../../../Users.txt"))
        {
            //append new user information as a new line at the end of the file
            sw.WriteLine($"{userName},{password},{age},{theme}");
        }
    }
    
}