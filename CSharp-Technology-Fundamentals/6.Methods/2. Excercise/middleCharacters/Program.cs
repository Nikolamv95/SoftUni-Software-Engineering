using System;

namespace middleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string result = String.Empty;

            result = Calculation(input);
            Console.WriteLine(result);
        }

        static string Calculation(string input)
        {
            string result = String.Empty;

            if (input.Length % 2 == 0)
            {
                result = input.Substring((input.Length-1) / 2, 2);
            }
            else
            {
                result = input.Substring((input.Length) / 2, 1);
            }

            return result;

        }
    }
}
