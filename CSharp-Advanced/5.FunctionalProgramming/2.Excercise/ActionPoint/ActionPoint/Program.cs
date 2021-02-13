using System;

namespace ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string [] namesInput = Console.ReadLine().Split(' ');
            Action<string> printData = PrintData(namesInput);
            PrintCollection(namesInput, printData);
        }

        private static void PrintCollection(string[] namesInput, Action<string> printData)
        {
            foreach (var item in namesInput)
            {
                printData(item);
            }
        }

        static Action<string> PrintData(string [] namesInput)
        {
            return name =>
            {
                Console.WriteLine($"{name}");
            };
        }
    }
}
