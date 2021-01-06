using System;

namespace sumOfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            int nLines = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= nLines; i++)
            {
                char letter = char.Parse(Console.ReadLine());

                sum += (int)letter;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
