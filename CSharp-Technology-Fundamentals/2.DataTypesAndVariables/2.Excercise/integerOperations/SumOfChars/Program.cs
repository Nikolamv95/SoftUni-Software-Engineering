using System;

namespace SumOfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int SumOfChars = 0;

            for (int i = 1; i <= lines; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                int letterNum = Convert.ToInt32(letter);
                SumOfChars += letterNum;
            }
            Console.WriteLine($"The sum equals: {SumOfChars}");
        }
    }
}
