using System;

namespace concatNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string nameLast = Console.ReadLine();
            string symbol = Console.ReadLine();

            Console.WriteLine($"{name}{symbol}{nameLast}");
            
        }
    }
}
