using System;

namespace rintPartoftheASCIITable
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int lastNum = int.Parse(Console.ReadLine());

            for (int i = firstNum; i <= lastNum; i++)
            {
                char letter = Convert.ToChar(i);

                Console.Write($"{letter} ");
            }
        }
    }
}
