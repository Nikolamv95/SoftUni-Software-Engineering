using System;

namespace ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] namesInput = Console.ReadLine().Split(' ');
            Action<string> printData = name =>
            {
                Console.WriteLine($"Sir {name}");
            };

            PrintCollection(namesInput, printData);
        }

        private static void PrintCollection(string[] namesInput, Action<string> printData)
        {
            foreach (var item in namesInput)
            {
                printData(item);
            }
        }
    }
}
