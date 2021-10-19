using System;
using System.Collections.Generic;
using System.Text;

namespace ScrollMenu
{
    class ScrollMenu<T>
    {
        public delegate void CallBack(List<T> Options, int choice);

        public ScrollMenu(string msg, List<T> argOptions, CallBack argCallBack)
        {
            outputMsg = msg;

            foreach (T str in argOptions)
                options.Add(str);

            callBack = argCallBack;
        }

        public void Start()
        {
            int choice;
            Step(out choice);
            callBack(options, choice);
        }

        private void Step(out int choice)
        {
            Console.WriteLine(outputMsg);

            for (int i = 0; i < options.Count; i++)
            {
                if (i == currentIndex)
                {
                    ConsoleColor prev = Console.ForegroundColor;
                    Console.ForegroundColor = selectedColor;
                    Console.WriteLine(options[i]);
                    Console.ForegroundColor = prev;
                }
                else
                    Console.WriteLine(options[i]);
            }


            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.Enter: break;
                case ConsoleKey.DownArrow:
                    if (currentIndex < options.Count - 1) {  currentIndex++; }
                    Console.Clear();
                    Step(out choice);
                    break;
                case ConsoleKey.UpArrow:
                    if (currentIndex > 0) currentIndex--;
                    Console.Clear();
                    Step(out choice);
                    break;
                default:
                    Console.Clear();
                    Step(out choice);
                    break;
            }


            choice = currentIndex;
        }

        //
        // variables
        //
        
        private string outputMsg = "";
        private int currentIndex = 0;
        private List<T> options = new List<T>();
        private ConsoleColor selectedColor = ConsoleColor.DarkCyan;
        private CallBack callBack;
    }
}
