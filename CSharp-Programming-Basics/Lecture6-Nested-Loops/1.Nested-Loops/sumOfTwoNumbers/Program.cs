using System;
using System.Diagnostics.Tracing;

namespace sumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberStart = int.Parse(Console.ReadLine());
            int numberFinish = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            int counter = 0;
            int sum = 0;
            bool flag = false;


            for (int n = numberStart; n <= numberFinish; n++)
            {
                for (int n2 = numberStart; n2 <= numberFinish; n2++)    
                {
                    counter += 1;
                    sum = n + n2;

                    if (magicNumber == sum)
                    {
                        Console.WriteLine($"Combination N:{counter} ({n} + {n2} = {magicNumber})");
                        flag = true;
                        break;
                    }
                }

                if (flag)
                {
                    break;
                }
            }

            if (!flag)
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicNumber}");
            }
            
        }
    }
}
