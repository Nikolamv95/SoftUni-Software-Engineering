using System;

namespace MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double number = double.Parse(Console.ReadLine());
            string unit = (Console.ReadLine());
            string convertedUnit = (Console.ReadLine());

            //Calculations
            if (unit == "mm" && convertedUnit == "m")
            {
                number = number / 1000;
            }
            else if (unit == "mm" && convertedUnit == "cm")
            {
                number = number / 10;
            }
            else if (unit == "cm" && convertedUnit == "m")
            {
                number = number / 100;
            }
            else if (unit == "cm" && convertedUnit == "mm")
            {
                number = number * 10;
            }
            else if (unit == "m" && convertedUnit == "mm")
            {
                number = number * 1000;
            }
            else if (unit == "m" && convertedUnit == "cm")
            {
                number = number * 100;
            }
            Console.WriteLine($"{number:f3}");
        }
    }
}
