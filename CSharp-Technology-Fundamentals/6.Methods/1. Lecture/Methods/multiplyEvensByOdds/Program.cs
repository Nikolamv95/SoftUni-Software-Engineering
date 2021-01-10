using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main()
        {
            int inputNum = Math.Abs(int.Parse(Console.ReadLine()));
            int result = FindResult(inputNum);
            Console.WriteLine(result);
        }

        static int FindResult(int number1)
        {
            int resultFinal = SumOfEven(number1) * SumOfOdds(number1);
            return resultFinal;
        }

        static int SumOfEven(int number2)
        {
            int sumOfEven = 0;
            while (number2 != 0)
            {
                int value = number2 % 10;
                if (value % 2 == 0)
                {
                    sumOfEven += value;
                }
                number2 /= 10;
            }
            return sumOfEven;
        }

        static int SumOfOdds(int number)
        {
            int sumOfOdd = 0;
            while (number != 0)
            {
                int value = number % 10;
                if (value % 2 != 0)
                {
                    sumOfOdd += value;
                }
                number /= 10;
            }
            return sumOfOdd;
        }

       
    }
}