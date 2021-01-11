using System;
using System.Collections.Generic;
using System.Linq;

namespace listOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            List<string> products = new List<string>(lenght);

            for (int i = 0; i < lenght; i++)
            {
                products.Add(Console.ReadLine());
            }

            products.Sort();

            for (int i = 0; i < lenght; i++)
            {
                Console.WriteLine($"{i+1}.{products[i]}");
            }
        }
    }
}
