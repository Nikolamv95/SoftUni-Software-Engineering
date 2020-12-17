using System;

namespace AbsolutValue
{
    class Program
    {
        static void Main(string[] args)
        {
            int value1 = 10;
            int value2 = -14;

            //Math.Abs calculates the value from 10 to - 14 = 24
            Console.WriteLine(Math.Abs(value1 - value2));
        }
    }
}
