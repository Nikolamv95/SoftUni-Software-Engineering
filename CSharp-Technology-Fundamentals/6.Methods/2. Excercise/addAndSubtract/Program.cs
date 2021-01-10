using System;

namespace addAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());

            int resultAdd = 0;
            int finalResult = 0;

            resultAdd = AddValue(number1, number2);
            finalResult = SubstractValue(resultAdd, number3);

            Console.WriteLine(finalResult);
        }

        static int AddValue(int number1, int number2)
        {
            int resultAdd = number1 + number2;
            return resultAdd;
        }

        static int SubstractValue(int resultAdd, int number3)
        {
            int finalResult = resultAdd - number3;
            return finalResult;
        }
    }
}
