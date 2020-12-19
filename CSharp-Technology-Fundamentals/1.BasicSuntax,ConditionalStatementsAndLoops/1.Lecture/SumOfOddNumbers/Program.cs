using System;

namespace SumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var sum = 0;
            var loops = 1;
            var oddOrEven = 1;


            while (loops <= number)
            {
                if (oddOrEven % 2 == 1)
                {
                    Console.WriteLine(oddOrEven);
                    sum += oddOrEven;
                    oddOrEven += 2;
                }
                loops += 1;
            }

            Console.WriteLine($"Sum: {sum}");

        } 
    }
}
