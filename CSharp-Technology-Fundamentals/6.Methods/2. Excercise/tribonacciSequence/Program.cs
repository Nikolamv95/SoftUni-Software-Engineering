using System;
using System.Linq;
using System.Numerics;

namespace tribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            uint lenght = uint.Parse(Console.ReadLine());
            uint[] tribonacci = new uint[lenght];
            Calculation(tribonacci);

        }

        private static void Calculation(uint[] tribonacci)
        {
            switch (tribonacci.Length)
            {
                case 1:
                    tribonacci[0] = 1;
                    break;
                case 2:
                    tribonacci[0] = 1;
                    tribonacci[1] = 1;
                    break;
                case 3:
                    tribonacci[0] = 1;
                    tribonacci[1] = 1;
                    tribonacci[2] = 2;
                    break;
                default:
                    tribonacci[0] = 1;
                    tribonacci[1] = 1;
                    tribonacci[2] = 2;

                    for (uint i = 3; i < tribonacci.Length; i++)
                    {
                        tribonacci[i] = tribonacci[i - 1] +
                                        tribonacci[i - 2] +
                                        tribonacci[i - 3];
                    }
                    break;
            }

            for (uint i = 0; i < tribonacci.Length; i++)
            {
                Console.Write(tribonacci[i] + " ");
            }
        }
    }
}
