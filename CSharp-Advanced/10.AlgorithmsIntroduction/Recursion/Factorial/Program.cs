using System;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int factorialNum = int.Parse(Console.ReadLine());

            int result = FactorialRec(factorialNum);
            Console.WriteLine(result);
        }

        private static int FactorialRec(int factorialNum)
        {
            if (factorialNum <= 1)
            {
                return 1;
            }

            int factMinus1 = FactorialRec(factorialNum - 1);
            int result = factorialNum * factMinus1;
            return result;
        }

        //Задачата работи така
        //след като извика рекурсията
        //4 пъти в себе си
        //5! = 5 * 4    
        //4! = 4 * 3
        //3! = 3 * 2
        //2! = 2 * 1
        //1! = 1

        //След като започне да връща резълтата той се връща по следния начин
        //1! = 1              
        //2! = 2 * 1  (1)       
        //3! = 3 * 2! (2)       
        //4! = 4 * 3! (6)
        //5! = 5 * 4! (24)
    }
}
