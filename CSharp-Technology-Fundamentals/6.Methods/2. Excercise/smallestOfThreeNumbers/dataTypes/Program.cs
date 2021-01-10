using System;

namespace dataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string input = Console.ReadLine();

            switch (type)
            {
                case "int":

                    IntOperation(input);
                    break;
                case "real":
                    RealOperation(input);
                    break;
                case "string":
                    StringOperation(input);
                    break;
            }
        }

        private static void IntOperation(string input)
        {
           int number = int.Parse(input);
            number *= 2;
            Console.WriteLine(number);
        }

        private static void StringOperation(string input)
        {
            Console.WriteLine($"${input}$");
        }

        private static void RealOperation(string input)
        {
            double number = double.Parse(input);
            number *= 1.5;
            Console.WriteLine($"{number:f2}");
        }
    }
}
