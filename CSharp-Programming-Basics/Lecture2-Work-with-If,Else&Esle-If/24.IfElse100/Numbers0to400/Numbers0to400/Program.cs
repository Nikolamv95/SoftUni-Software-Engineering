using System;

namespace Numbers0to400
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());

            if (number < 100)
            {
                Console.WriteLine("Less than 100");
            }
            else if (number < 200)
            {
                Console.WriteLine("Greater than 100 and less than 200");
            }
            else if (number <= 400)
            {
                Console.WriteLine("Between 200 and 400");
            }
            else if (number > 400)
            {
                Console.WriteLine("Greater than 400");
            }
        }
    }
}
