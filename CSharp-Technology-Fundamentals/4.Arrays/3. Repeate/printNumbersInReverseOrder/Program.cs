using System;

namespace printNumbersInReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            int[] numbers = new int[length];

            for (int i = 0; i < length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());       
            }

            Array.Reverse(numbers);
            Console.WriteLine(String.Join(' ', numbers));

        }
    }
}
