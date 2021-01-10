using System;

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
                    GetMax(number1, number2);
                    break;
                case "char":
                    char char1 = char.Parse(Console.ReadLine());
                    char char2 = char.Parse(Console.ReadLine());
                    GetMax(char1, char2);
                    break;
                case "string":
                    string string1 = Console.ReadLine();
                    string string2 = Console.ReadLine();
                    GetMax(string1, string2);
                    break;
            }
        }

        static void GetMax(int number1, int number2)
        {
            if (number1 > number2)
            {
                Console.WriteLine(number1);
            }
            else
            {
                Console.WriteLine(number2);
            }
        }
        static void GetMax(char char1, char char2)
        {
            int result1 = Convert.ToInt32(char1);
            int result2 = Convert.ToInt32(char2);

            if (result1 > result2)
            {
                Console.WriteLine($"{Convert.ToChar(result1)}");
            }
            else
            {
                Console.WriteLine($"{Convert.ToChar(result2)}");
            }
        }
        static void GetMax(string string1, string string2)
        {
            if (String.Compare(string1, string2) < 0)
            {
                Console.WriteLine(string2);
            }
            else
            {
                Console.WriteLine(string1);
            }

        }
    }
}
