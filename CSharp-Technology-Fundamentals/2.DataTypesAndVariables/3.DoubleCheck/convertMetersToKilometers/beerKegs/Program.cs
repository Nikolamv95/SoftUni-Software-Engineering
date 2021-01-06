using System;

namespace beerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            string winner = string.Empty;
            double constant = int.MinValue;

            for (int i = 0; i < lines; i++)
            {
                string kegName = Console.ReadLine();
                double radisuKeg = double.Parse(Console.ReadLine());
                double heightKeg = double.Parse(Console.ReadLine());

                double result = Math.PI * Math.Pow(radisuKeg, 2) * heightKeg;

                if (result > constant)
                {
                    constant = result;
                    winner = kegName;
                }
            }
            Console.WriteLine(winner);
        }
    }
}
