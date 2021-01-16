using System;
using System.Collections.Generic;

namespace MinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            while (product != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (dictionary.ContainsKey(product) == false)
                {
                    dictionary.Add(product, quantity);
                }
                else
                {
                    dictionary[product] += quantity; 
                }

                product = Console.ReadLine();
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} –> {item.Value}");
            }
        }
    }
}
