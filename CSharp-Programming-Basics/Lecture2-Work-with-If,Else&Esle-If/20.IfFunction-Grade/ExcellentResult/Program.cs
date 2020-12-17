using System;

namespace BoolVariable
{
    class Program
    {
        static void Main(string[] args)
        {
            //Intput
            double grade = double.Parse(Console.ReadLine());
            //If Function
            if (grade >= 5.50)
            //If true -> continue
            {
                Console.WriteLine("Excellent!");
            }

        }
    }
}