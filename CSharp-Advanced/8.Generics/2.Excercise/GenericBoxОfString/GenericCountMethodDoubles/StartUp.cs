using System;
using System.Collections.Generic;

namespace GenericCountMethodStrings
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            BoxStore<double> boxesList = new BoxStore<double>();

            for (int i = 0; i < rows; i++)
            {
                double input = double.Parse(Console.ReadLine());
                Box<double> currBox = new Box<double>(input);
                boxesList.AddBox(currBox);
            }
            boxesList.SwapBoxes(1, 2);

            double argument = double.Parse(Console.ReadLine());
            int result = boxesList.CountBiggerValues(argument);
            Console.WriteLine(result);
            
            
        }
    }  
}
