using System;

namespace MathRounded
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 4.3132;
            double b = 4.4802;
            double priceOfAandB = a + b;

            //No Formating = 8.7934
            Console.WriteLine($"The price is: {priceOfAandB}"); 
            //F2 cuts all the numbers after the second symbol 8.7934 = 8.79
            Console.WriteLine($"The price is: {priceOfAandB:f2}");
            //Round with Math.Round 8.7934 = 8.79
            Console.WriteLine($"The price is: {Math.Round (priceOfAandB,2)}");
            //Celling with Math.Celling 8.7934 = 9
            Console.WriteLine($"The price is: {Math.Ceiling (priceOfAandB)}");
            //Floor with Math.Floor 8.7934 = 8
            Console.WriteLine($"The price is: {Math.Floor (priceOfAandB)}");


        }
    }
}
