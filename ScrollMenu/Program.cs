using System;
using System.Collections.Generic;

namespace ScrollMenu
{
    class Program
    {
        static void ColorConsole(string msg, ConsoleColor col) 
        {
            ConsoleColor prev = Console.ForegroundColor;
            Console.ForegroundColor = col;
            Console.WriteLine(msg);
            Console.ForegroundColor = prev;
        }

        static void Callback(List<string> Options, int choice)
        {
            switch (choice)
            {
                case 0: case 1:
                    ColorConsole("valid!!", ConsoleColor.Green);
                    break;
                case 2:
                    ColorConsole("we don't live in 2016 anymore bro...", ConsoleColor.Red);
                    break;
            }
            Console.Read();
        }
        static void Main(string[] args)
        {
            ScrollMenu<string> scrollMenu = new ScrollMenu<string>("select brand:", new List<string> { "gucci", "louis vuitton", "supreme" }, Callback);

            scrollMenu.Start();
        }
    }
}
