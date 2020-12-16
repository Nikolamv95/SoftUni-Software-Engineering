using System;

namespace divideWithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            int n2 = 0;
            int n3 = 0;
            int n4 = 0;



            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number % 2 == 0)
                {
                    n2 += 1;
                }
                if (number % 3 == 0)
                {
                    n3 += 1;
                }
                if (number % 4 == 0)
                {
                    n4 += 1;
                }
            }

            double diffN2 = n2 / n * 100;
            double diffN3 = n3 / n * 100;
            double diffN4 = n4 / n * 100;

            Console.WriteLine($"{diffN2:f2}%");
            Console.WriteLine($"{diffN3:f2}%");
            Console.WriteLine($"{diffN4:f2}%");


        }
    }
}
