using System;

namespace numberSequence
    {
        class Program
        {
            static void Main(string[] args)
            {
                int numbers = int.Parse(Console.ReadLine());
                int maxNum = int.MinValue;
                int minNum = int.MaxValue;

                for (int i = 0; i < numbers; i++)
                {
                    int addedNumber = int.Parse(Console.ReadLine());

                    if (maxNum < addedNumber)
                    {
                        maxNum = addedNumber;
                    }
                    if (minNum > addedNumber)
                     {
                        minNum = addedNumber;
                     }
                }

                Console.WriteLine($"Max number: {maxNum}");
                Console.WriteLine($"Min number: {minNum}");
            }
        }
    }