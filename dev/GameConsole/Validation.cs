/*
    Validation Class for Validating User Input
*/
using System;

namespace GameConsole;

public class Validation
{
    //string validation function
    public static string ValidateString()
    {
        //catch user input
        string userString = Console.ReadLine();

        while(string.IsNullOrWhiteSpace(userString))
        {
            //output error and catch input again
            Console.Write("Incorrect option, please try again: ");
            userString = Console.ReadLine();
        }

        //return validated integer
        return userString;
    }

    //int validation function
    public static int ValidateInt()
    {
        //catch user input and decalre undefined int
        string userString = Console.ReadLine();
        int userInt;

        //validate intput is a number greater than 0
        while(!(int.TryParse(userString, out userInt)) || userInt < 0)
        {
            //output error and catch input again
            Console.Write("Incorrect option, please try again: ");
            userString = Console.ReadLine();
        }

        //return validated integer
        return userInt;
    }

    //range validation function
    public static int ValidateRange(int lowerLimit, int upperLimit)
    {
        //reuse intger validation method to catch input
        int userInt = ValidateInt();

        //validate that input is within the specified range
        while(userInt < lowerLimit || userInt > upperLimit)
        {
            //output error and catch input again
            Console.Write("Incorrect option, please try again: ");
            userInt = ValidateInt();
        }

        //return validated integer
        return userInt;
    }

    //validate list method
    public static string ValidateList(List<string> options)
    {
        //catch user input
        string userString = Console.ReadLine();

        //validate string is not null and is inside of the options list
        while(string.IsNullOrWhiteSpace(userString) || !options.Contains(userString))
        {
            //output error and catch input again
            Console.Write("Incorrect option, please try again: ");
            userString = Console.ReadLine();
        }

        //return string
        return userString;
    }

}
