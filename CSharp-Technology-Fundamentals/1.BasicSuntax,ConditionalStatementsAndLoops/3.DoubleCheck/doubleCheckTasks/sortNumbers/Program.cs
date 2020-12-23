using System;

namespace sortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double number1 = double.Parse(Console.ReadLine());
            double number2 = double.Parse(Console.ReadLine());
            double number3 = double.Parse(Console.ReadLine());

            for (int i = 1; i <= 3; i++)
            {
                if (number1 >= number2 && number1 >= number3)
                {
                    Console.WriteLine(number1);
                    number1 = double.MinValue;
                }
                else if (number2 >= number3 && number2 >= number1)
                {
                    Console.WriteLine(number2);
                    number2 = double.MinValue;
                }
                else if (number3 >= number2 && number3 >= number1)
                {
                    Console.WriteLine(number3);
                    number3 = double.MinValue;
                }
            }
        }
    }
}
