﻿using System;

namespace exactSumOfRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            double sum = 0;

            for (int i = 0; i < numbers; i++)
            {
                double input = double.Parse(Console.ReadLine());

                sum += input;
            }

            Console.WriteLine(sum);
        }
    }
}