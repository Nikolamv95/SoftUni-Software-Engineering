using System;

namespace repeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int repeate = int.Parse(Console.ReadLine());

            string result = Calculation(input, repeate);
            Console.WriteLine(result);
        }

        private static string Calculation(string input, int repeate)
        {
            string result = string.Empty;

            for (int i = 0; i < repeate; i++)
            {
                result += input;
            }

            return result;
        }
    }
}
