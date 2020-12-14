using System;

namespace numberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int currentNumber = 1;
            bool exit = false;

            for (int rows = 1; rows <= input; rows++)
            {
                for (int cols = 1; cols <= rows; cols++)
                {
                    if (currentNumber > input)
                    {
                        exit = true;
                        break;
                    }

                    Console.Write(currentNumber + " ");
                    currentNumber++;
                }
                Console.WriteLine();

                if (exit)
                {
                    break;
                }
            }
        }
    }
}
