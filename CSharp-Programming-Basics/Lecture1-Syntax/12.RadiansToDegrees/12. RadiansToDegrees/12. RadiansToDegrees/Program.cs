using System;
using System.Text.RegularExpressions;

namespace _12._RadiansToDegrees
{
    class Program
    {
        static void Main(string[] args)
        {
            double radians = double.Parse(Console.ReadLine());
            double deg = radians * 180 / Math.PI;
            Console.WriteLine(Math.Round(deg));
        }
    }
}
