using System;

namespace divisionWithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersQ = int.Parse(Console.ReadLine());
            int devide2 = 0;
            int devide3 = 0;
            int devide4 = 0;

            for (int i = 0; i < numbersQ; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber % 2 == 0   )
                {
                    devide2 += 1;
                }
                if (currentNumber % 3 == 0)
                {
                    devide3 += 1;
                }
                if (currentNumber % 4 == 0)
                {
                    devide4 += 1;
                }
            }

            double totalNum = Convert.ToDouble(numbersQ);
            double devideDoub2 = Convert.ToDouble(devide2);
            double devideDoub3 = Convert.ToDouble(devide2);
            double devideDoub4 = Convert.ToDouble(devide2);

            devideDoub2 = (devide2 / totalNum) * 100;
            devideDoub3 = (devide3 / totalNum) * 100;
            devideDoub4 = (devide4 / totalNum) * 100;

            Console.WriteLine($"{devideDoub2:f2}%");
            Console.WriteLine($"{devideDoub3:f2}%");
            Console.WriteLine($"{devideDoub4:f2}%");
        }
    }
}
