using System;

namespace IfElse_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int number = int.Parse(Console.ReadLine());

            //If function - If number is less than 100 -> from 99 to 0
            if (number < 100)
            {
                Console.WriteLine("Less than 100");
            }
            //else if function - If number is between 100 & 200
            else if (number <= 200)
            {
             Console.WriteLine("Between 100 and 200");
            }
            //else if function - If number is greater than 200
            else if (number >= 200)
            {
                Console.WriteLine("Greater than 200");
            }
        }
    }
}
