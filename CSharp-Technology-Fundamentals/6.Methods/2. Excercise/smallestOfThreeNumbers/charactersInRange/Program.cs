using System;

namespace charactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char char1 = char.Parse(Console.ReadLine());
            char char2 = char.Parse(Console.ReadLine());

            Calculation(char1, char2);    
        }

        static void Calculation(char char1, char char2)
        {
            int numberToChar1 = Convert.ToInt32(char1);
            int numberToChar2 = Convert.ToInt32(char2);

            char result;

            if (numberToChar1 < numberToChar2)
            {
                numberToChar1 += 1;
                for (int i = numberToChar1; i < numberToChar2; i++)
                {
                    result = Convert.ToChar(i);
                    Console.Write($"{result} ");
                }
            }
            else
            {
                numberToChar2 += 1;
                for (int i = numberToChar2; i < numberToChar1; i++)
                {
                    result = Convert.ToChar(i);
                    Console.Write($"{result} ");
                }
            }
        }
    }
}
