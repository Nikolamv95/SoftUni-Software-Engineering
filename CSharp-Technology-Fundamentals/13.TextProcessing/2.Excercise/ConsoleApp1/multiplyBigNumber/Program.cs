using System;
using System.Linq;
using System.Numerics;

namespace multiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger num1 = BigInteger.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            BigInteger result = (BigInteger)num1 * num2;
            Console.WriteLine(result);
        }
    }
}
