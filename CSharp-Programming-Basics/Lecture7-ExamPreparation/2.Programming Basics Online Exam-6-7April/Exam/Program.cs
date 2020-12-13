using System;

namespace Exam1
{
    class Program
    {
        static void Main(string[] args)
        {
            double hallRent = int.Parse(Console.ReadLine());
            double statuePrice = hallRent * 0.70;
            double kateringPrice = statuePrice * 0.85;
            double soundPrice = kateringPrice * 0.50;
            double fullPrice = hallRent + statuePrice + kateringPrice + soundPrice;
            Console.WriteLine($"{fullPrice:f2}");
        }
    }
}
