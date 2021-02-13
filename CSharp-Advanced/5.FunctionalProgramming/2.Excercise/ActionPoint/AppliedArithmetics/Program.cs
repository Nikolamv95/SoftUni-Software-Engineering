using System;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> customSubtract = x => x - 1;
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = numbers.Select(x => x + 1).ToArray();
                        break;
                    case "multiply":
                        numbers = numbers.Select(x => x * 2).ToArray();
                        break;
                    case "subtract":
                        numbers = numbers.Select(customSubtract).ToArray();
                        break;
                    case "print":
                        Console.WriteLine(string.Join(' ', numbers));
                        break;
                }
            }
        }
    }
}
