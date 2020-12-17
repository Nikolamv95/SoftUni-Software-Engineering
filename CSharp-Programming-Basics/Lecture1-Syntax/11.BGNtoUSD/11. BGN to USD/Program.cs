using System;

namespace _11._BGN_to_USD
{
    class Program
    {
        static void Main(string[] args)
        {
            //static number в случай, че курса варира
            double usdStaticCurrentCourse = 1.79549;

            // input
            double usd = double.Parse(Console.ReadLine());

            // calculation
            double bgn = usd * usdStaticCurrentCourse;

            // output
            Console.WriteLine($" {bgn:f2}");
        }
    }
}
