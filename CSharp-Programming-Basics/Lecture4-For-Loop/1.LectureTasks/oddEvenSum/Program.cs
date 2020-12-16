using System;

namespace oddEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int evenNumbers = 0;
            int oddNumbers = 0;

            for (int i = 0; i < n; i++)
            {
                int addNumber = int.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    evenNumbers += addNumber;
                }
                else
                {
                    oddNumbers += addNumber;
                }
            }

            int difference = 0;

            if (evenNumbers == oddNumbers)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {evenNumbers}" );
            }
            else if (evenNumbers > oddNumbers)
            {
                difference = evenNumbers - oddNumbers;
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {difference}");
            }
            else if (evenNumbers < oddNumbers)
            {
                difference = oddNumbers - evenNumbers;
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {difference}");
            }
        }
    }
}
