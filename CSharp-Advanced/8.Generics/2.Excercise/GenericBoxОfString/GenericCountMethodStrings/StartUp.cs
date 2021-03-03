using System;
using System.Collections.Generic;

namespace GenericCountMethodStrings
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            BoxStore<string> boxesList = new BoxStore<string>();

            for (int i = 0; i < rows; i++)
            {
                string input = Console.ReadLine();
                Box<string> currBox = new Box<string>(input);
                boxesList.AddBox(currBox);
            }
            boxesList.SwapBoxes(1, 2);

            string argument = Console.ReadLine();
            int result = boxesList.CountBiggerValues(argument);
            Console.WriteLine(result);
            
            
        }
    }  
}
