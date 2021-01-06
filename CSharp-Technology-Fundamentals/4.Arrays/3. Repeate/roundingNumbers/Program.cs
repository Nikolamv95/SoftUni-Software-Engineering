using System;
using System.Linq;

namespace roundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine()
                           .Split()
                           .Select(double.Parse)
                           .ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine($"{Convert.ToDecimal(input[i])} => {Math.Round(Convert.ToDecimal(input[i]), MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
