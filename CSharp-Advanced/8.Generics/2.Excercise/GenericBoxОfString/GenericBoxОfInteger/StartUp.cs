using System;
using System.Collections.Generic;

namespace GenericBoxОfString
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            for (int i = 0; i < rows; i++)
            {
                int input = int.Parse(Console.ReadLine());
                var currBox = new Box<int>(input);
                Console.WriteLine(currBox.ToString()); 
            }
        }
    }
}
