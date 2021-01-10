using System;

namespace charactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char input1 = char.Parse(Console.ReadLine());
            char input2 = char.Parse(Console.ReadLine());

            string result = charactersInRange(input1, input2);
            Console.WriteLine(result);
        }

        private static string charactersInRange(char input1, char input2)
        {
            string result = String.Empty;

            int charNum1 = input1+1;
            int charNum2 = input2;

            for (int i = charNum1; i < charNum2; i++)
            {
                char currChar = (char)i;

                result += $"{currChar} ";
            }
            return result;
        }
    }
}
