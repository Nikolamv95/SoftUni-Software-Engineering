using System;
using System.Collections.Generic;
using System.Text;

namespace MoreLearing_Calculator
{
    class CalculatorFP
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }

        public int Miltiply(int a, int b)
        {
            return a * b;
        }

        public int Devide(int a, int b)
        {
            return a / b;
        }

        public int Minus(int a, int b)
        {
            return a / b;
        }

        public void PrintResult(int value)
        {
            Console.WriteLine($"The result is: {value}");
        }
    }
}
