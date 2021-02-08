using System;

namespace MoreLearing_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            string operation = Console.ReadLine();
            var calculator = new CalculatorFP();
            
            switch (operation)
            {
                case "sum":
                    calculator.PrintResult(calculator.Sum(a, b));
                    break;
                case "minus":
                    calculator.PrintResult(calculator.Minus(a, b));
                    break;
                case "multiply":
                    calculator.PrintResult(calculator.Miltiply(a, b));
                    break;
                case "devide":
                    calculator.PrintResult(calculator.Devide(a, b));
                    break;
            }
        }
    }
}
