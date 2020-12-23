using System;

namespace multiplicationTable2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int times = int.Parse(Console.ReadLine());
            int result = 0;

            for (int i = number; i == number; i++)
            {
                if (times > 10)
                {
                    for (int k = times; k <= times; k++)
                    {
                        result = i * k;

                        Console.WriteLine($"{i} X {k} = {result}");
                        break;
                    }
                    break;
                }

                for (int j = times; j <= 10; j++)
                {
                    result = i * j;

                    Console.WriteLine($"{i} X {j} = {result}");
                }
            }
        }
    }
}
