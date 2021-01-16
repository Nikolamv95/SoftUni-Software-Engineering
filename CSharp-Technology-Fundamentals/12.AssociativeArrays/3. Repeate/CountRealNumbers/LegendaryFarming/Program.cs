using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Dictionary<string, int> listOfProducts = new Dictionary<string, int>();
            bool isCreated = false;

            while (isCreated == false)
            {
                string[] input = Console.ReadLine()
                                            .ToLower()
                                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                            .ToArray();

                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string product = input[i+1];

                    if (listOfProducts.ContainsKey(product) == false)
                    {
                        listOfProducts.Add(product, quantity);
                    }
                    else
                    {
                        listOfProducts[product] += quantity;
                    }

                    switch (product)
                    {
                        case "shards":
                            if (listOfProducts[product] >= 250)
                            {
                                listOfProducts[product] -= 250;
                                Console.WriteLine($"Shadowmourne obtained!");
                                isCreated = true;
                            }
                            break;
                        case "fragments":
                            if (listOfProducts[product] >= 250)
                            {
                                listOfProducts[product] -= 250;
                                Console.WriteLine($"Valanyr obtained!");
                                isCreated = true;
                            }
                            break;
                        case "motes":
                            if (listOfProducts[product] >= 250)
                            {
                                listOfProducts[product] -= 250;
                                Console.WriteLine($"Dragonwrath obtained!");
                                isCreated = true;
                            }
                            break;
                    }
                    if (isCreated == true)
                    {
                        break;
                    }
                }
            }

            Dictionary<string, int> mainProducts = new Dictionary<string, int>();

            foreach (var item in listOfProducts)
            {
                if (item.Key == "shards" || item.Key == "fragments" || item.Key == "motes")
                {
                    mainProducts.Add(item.Key, item.Value);
                }
            }

            bool shardsIsCreated = mainProducts.Select(x => x.Key).Contains("shards");
            bool fragmentsIsCreated = mainProducts.Select(x => x.Key).Contains("fragments");
            bool motesIsCreated = mainProducts.Select(x => x.Key).Contains("motes");


            if (shardsIsCreated == false)
            {
                mainProducts.Add("shards", 0);
            }
            if (fragmentsIsCreated == false)
            {
                mainProducts.Add("fragments", 0);
            }
            if (motesIsCreated == false)
            {
                mainProducts.Add("motes", 0);
            }

            var fillMainProd = mainProducts.OrderByDescending(x => x.Value).ThenBy(a => a.Key);
            foreach (var item in fillMainProd)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            var junkItemFil = listOfProducts.OrderBy(a => a.Key);

            foreach (var item in junkItemFil)
            {
                if (item.Key != "shards" && item.Key != "fragments" && item.Key != "motes")
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }
    }
}
