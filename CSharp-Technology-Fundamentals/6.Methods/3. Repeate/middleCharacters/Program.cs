using System;

namespace middleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] charArray = input.ToCharArray();

            string result = GetMiddleChar(charArray);
            Console.WriteLine(result);
        }

        private static string GetMiddleChar(char[] charArray)
        {
            string result = string.Empty;
            

            if (charArray.Length % 2 == 0)
            {
                int numToPrint = charArray.Length / 2;
                result = $"{charArray[numToPrint - 1]}{charArray[numToPrint]}";
            }
            else
            {
                int numToPrint = charArray.Length / 2;
                result = $"{charArray[numToPrint]}";
            }

            return result;
        }
    }
}
