using System;

namespace concatNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();
            string input3 = Console.ReadLine();

            Console.WriteLine($"{input1}{input3}{input2}");
        }
    }
}
