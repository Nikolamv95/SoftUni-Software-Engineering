using System;

namespace NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int nXnNum = int.Parse(Console.ReadLine());
            MatrinxNxN(nXnNum);
        }

        private static void MatrinxNxN(int nXnNum)
        {
            for (int i = 0; i < nXnNum; i++)
            {
                for (int j = 0; j < nXnNum; j++)
                {
                    Console.Write($"{nXnNum} ");
                }
                Console.WriteLine();
            }
        }
    }
}
