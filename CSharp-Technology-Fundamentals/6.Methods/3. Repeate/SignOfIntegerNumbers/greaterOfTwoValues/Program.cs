using System;
using System.Collections.Generic;

namespace greaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();

            switch (dataType)
            {
                case "int":
                    int number1 = int.Parse(Console.ReadLine());
                    int number2 = int.Parse(Console.ReadLine());
                    int resultInt = IntCalculation(number1, number2);
                    Console.WriteLine(resultInt);
                    break;
                case "char":
                    char char1 = char.Parse(Console.ReadLine());
                    char char2 = char.Parse(Console.ReadLine());
                    char resultChar = charCalculation(char1, char2);
                    Console.WriteLine(resultChar);
                    break;
                case "string":
                    string input1 = Console.ReadLine();
                    string input2 = Console.ReadLine();
                    string resultString = StringResult(input1, input2);
                    Console.WriteLine(resultString);
                    break;
            }
        }

        private static string StringResult(string input1, string input2)
        {
            string result = string.Empty;

            if (String.Compare(input1, input2) < 0)
            {
                result = input2;
            }
            else
            {
                result = input1;
            }
            return result;
        }

        private static char charCalculation(char char1, char char2)
        {
            int value = char1;
            int value2 = char2;
            char result = ' ';

            if (value >= value2)
            {
                result = char1;
            }
            else
            {
                result = char2;
            }

            return result;
        }

        private static int IntCalculation(int number1, int number2)
        {
            int result = 0;

            if (number1 >= number2)
            {
                result = number1;
            }
            else
            {
                result = number2;
            }
            return result;
        }
    }
}
