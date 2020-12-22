using System;
using System.ComponentModel.DataAnnotations;

namespace sortNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 3; i++)
            {
                if (number1 >= number2 & number1 >= number3)
                {
                    Console.WriteLine(number1);
                    number1 =int.MinValue;
                }
                else if (number2 >= number1 & number2 >= number3)
                {
                    Console.WriteLine(number2);
                    number2 = int.MinValue;
                }
                else if (number3 >= number1 & number3 >= number2)
                {
                    Console.WriteLine(number3);
                    number3 = int.MinValue;
                }
            }
        }
    }
}
