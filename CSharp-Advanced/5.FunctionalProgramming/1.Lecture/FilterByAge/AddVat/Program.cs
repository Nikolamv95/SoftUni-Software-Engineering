using System;
using System.Linq;

namespace AddVat
{
    class Program
    {
        static void Main(string[] args)
        {
            //Functions
            //Func<double, double> addVat = x => x * 1.20;
            //Func<string, double> doubParser = num => Convert.ToDouble(num);
            //double[] numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(doubParser).Select(addVat).ToArray();
            //Console.WriteLine(string.Join(Environment.NewLine, numbers));

            //Или
            Console.ReadLine()
                            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(x =>
                            {
                                double z = double.Parse(x);
                                return z * 1.20;
                            })
                            .ToList()
                            .ForEach(x => Console.WriteLine($"{x:f2}"));
        }
    }
}
