using System;

namespace MovieTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            for (int i = startNum; i <= endNum-1; i++)
            {
                if (i % 2 != 0)
                {
                    char letter = (char)i;

                    for (int j = 1; j <= n-1; j++)
                    {
                        for (int k = 1; k <= (n / 2) - 1; k++)
                        {
                            if ((j + k + i) % 2 != 0)
                            {
                                Console.WriteLine($"{letter}-{j}{k}{i}");
                            }
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
