using System;
using System.Collections.Generic;
using System.Text;

namespace StaticClasses
{
    class BankHelper
    {
        public static string Name { get; set; }
        public static void CalculateDebt(double income)
        {
            Console.WriteLine("Too much debt");
        }
    }
}
