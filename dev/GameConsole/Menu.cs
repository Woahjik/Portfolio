/*
    Menu Class
*/
using System;

namespace GameConsole;

public class Menu
{
    //menu option list property
    public List<string> MenuOptions {get; set;}

    //Constructor
    public Menu(List<string> menuOptions)
    {
        MenuOptions = menuOptions;
    }

    //display menu options
    public void DisplayOptions()
    {
        //loop through list and print each string
        foreach(string option in MenuOptions)
        {
            Console.WriteLine($"{option}");
        }
    }
}