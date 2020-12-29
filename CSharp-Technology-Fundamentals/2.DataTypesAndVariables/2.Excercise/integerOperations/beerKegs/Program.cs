using System;

namespace beerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberKegs = int.Parse(Console.ReadLine());
            string winner = string.Empty;
            double compareKeg = 0;

            while (numberKegs > 0)
            {
                string kegModel = Console.ReadLine();
                double kegRadius = double.Parse(Console.ReadLine());
                int kegHeight = int.Parse(Console.ReadLine());

                 double sumKeg = Math.PI * (Math.Pow(kegRadius, 2)) * kegHeight;

                if (sumKeg > compareKeg)
                {
                    winner = kegModel;
                    compareKeg = sumKeg;
                }

                numberKegs -= 1;
            }

            Console.WriteLine(winner);
        }
    }
}
