using System;
using System.Linq;

namespace MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNum = Math.Abs(int.Parse(Console.ReadLine()));
            int resultFinal = FindResult(inputNum);
            Console.WriteLine(resultFinal);
        }

        private static int FindResult(int inputNum)
        {
            int resultFinal = SumOfEven(inputNum) * SumOfOdd(inputNum);
            return resultFinal;
        }

        private static int SumOfOdd(int inputNum)
        {
            int resultOdd = 0;

            while (inputNum != 0)
            {
                int currNum = inputNum % 10;

                if (currNum % 2 != 0)
                {
                    resultOdd += currNum;
                }

                inputNum /= 10;
            }
            return resultOdd;
        }

        private static int SumOfEven(int inputNum)
        {
            int resultEven = 0;

            while (inputNum != 0)
            {
                int currNum = inputNum % 10;

                if (currNum % 2 == 0)
                {
                    resultEven += currNum;
                }
                inputNum /= 10;
            }
            return resultEven;
        }
    }
}
