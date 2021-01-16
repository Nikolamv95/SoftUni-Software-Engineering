using System;
using System.Collections.Generic;
using System.Linq;

namespace associativeArrayss
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, double> fruits = new SortedDictionary<string, double>();

            fruits.Add("Orange", 4.30);
            fruits.Add("Banana", 3.30);
            fruits.Add("Kiwi", 5.30);

            //fruits.ContainsKey();

            foreach (var item in fruits)
            {
                Console.WriteLine($"This is a {item.Key} and the price is {item.Value}");
            }


            //Dictionary<string, double> fruits = new Dictionary<string, double>();

            //fruits.Add("Orange", 4.30);
            //fruits.Add("Banana", 3.30);
            //fruits.Add("Kiwi", 5.30);

            //foreach (var item in fruits)
            //{
            //    Console.WriteLine($"This is a {item.Key} and the price is {item.Value}");
            //}
        }
    }
} 
