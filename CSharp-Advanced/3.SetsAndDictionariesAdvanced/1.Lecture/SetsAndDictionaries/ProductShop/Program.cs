using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Dictionary<string, Dictionary<string, double>> dicOfMarkets = new Dictionary<string, Dictionary<string, double>>();

            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] data = input.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string market = data[0];
                string product = data[1];
                double priceProduct = double.Parse(data[2]);
                Dictionary<string, double> dicOfProducts = new Dictionary<string, double>();

                if (dicOfMarkets.ContainsKey(market) == false)
                {
                    dicOfProducts.Add(product, priceProduct);
                    dicOfMarkets.Add(market, dicOfProducts);
                }
                else
                {
                    dicOfMarkets[market].Add(product, priceProduct);
                }
            }

            foreach (var market in dicOfMarkets.OrderBy(n=> n.Key))
            {
                Console.WriteLine($"{market.Key}->");
                foreach (var product in market.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
