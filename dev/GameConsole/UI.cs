/*
    UI Class for Program Formatting/Readability
*/
using System;

namespace GameConsole;

public class UI
{
    //header function
    public static void Header(string text)
    {
        //convert passed in string to uppercase
        string headerText = text.ToUpper();

        //output uppercase text inside of two double lines
        Console.WriteLine("=======================================");
        Console.WriteLine(headerText);
        Console.WriteLine("=======================================\r\n");
        }

    //footer function
    public static void Footer(string text)
    {
        //output text underneath one set of double lines above
        Console.WriteLine("\r\n=======================================");
        Console.Write(text);
    }

    //separator function
    public static void Separator()
    {
        //output single line for spacing
        Console.WriteLine("\r\n---------------------------------------");
    }

}
