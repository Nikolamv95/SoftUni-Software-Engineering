using System;
using System.Diagnostics.Tracing;

namespace combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int counter = 0;
            int counter2 = 0;

            for (int n1 = 0; n1 <= input; n1++)
            {
                for (int n2 = 0; n2 <= input; n2++)
                {
                    for (int n3 = 0; n3 <= input; n3++)
                    {
                        counter = n1 + n2 + n3;

                        if (counter == input)
                        {
                            counter2 += 1;
                        }
                    }
                }
            }
            Console.WriteLine(counter2);
        }
    }
}
