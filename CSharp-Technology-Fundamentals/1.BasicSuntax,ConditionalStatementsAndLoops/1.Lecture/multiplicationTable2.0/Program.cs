using System;

namespace multiplicationTable2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var times = int.Parse(Console.ReadLine());
            var result = 0;

            for (int i = number; i == number; i++)
            {
                if (times > 10)
                {
                    for (int n = times; n == times; n++)
                    {
                        result = number * times;

                        Console.WriteLine($"{number} X {times} = {result}");
                    } 
                }
                else
                {
                    for (int z = times; z <= 10; z++)
                    {
                        result = number * times;
                        Console.WriteLine($"{number} X {times} = {result}");
                        times += 1;
                    }
                }
            }
        }
    }
}
