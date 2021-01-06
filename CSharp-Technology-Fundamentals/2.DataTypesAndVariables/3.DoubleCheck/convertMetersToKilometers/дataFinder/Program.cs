using System;

namespace дataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            while (input != "END")
            {
                if (Int32.TryParse(input, out _))
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (float.TryParse(input, out _))
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (bool.TryParse(input, out _))
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else if (Char.TryParse(input, out _))
                {
                    Console.WriteLine($"{input} is character type");
                }
                else
                {
                    Console.WriteLine($"{input} is string type");
                }
                input = Console.ReadLine();
            }
        }
    }
}
