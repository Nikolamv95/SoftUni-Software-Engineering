using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> dicOfClothes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < rows; i++)
            {
                string[] data = Console.ReadLine().Split(" -> ").ToArray();
                string color = data[0];
                string[] clothes = data[1].Split(',', StringSplitOptions.RemoveEmptyEntries).ToArray();
                Dictionary<string, int> dicOfDresses = new Dictionary<string, int>();

                for (int c = 0; c < clothes.Length; c++)
                {
                    string currClothe = clothes[c];

                    if (dicOfClothes.ContainsKey(color) == false)
                    {
                        dicOfDresses.Add(currClothe, 1);
                        dicOfClothes.Add(color, dicOfDresses);
                    }
                    else
                    {
                        if (dicOfClothes[color].ContainsKey(currClothe) == true)
                        {
                            dicOfClothes[color][currClothe]++;

                        }
                        else
                        {
                            dicOfClothes[color].Add(currClothe, 1);
                        }
                    }
                }
            }

            string[] findInput = Console.ReadLine().Split(' ').ToArray();
            string findColor = findInput[0];
            string findCloth = findInput[1];

            foreach ((string color, Dictionary<string, int> dicOfClotes) in dicOfClothes)
            {
                Console.WriteLine($"{color} clothes:");

                if (color == findColor)
                {
                    foreach ((string clothe, int num) in dicOfClotes)
                    {
                        if (clothe == findCloth)
                        {
                            Console.WriteLine($"* {clothe} - {num} (found!)");
                        }
                        else
                        {
                            Console.WriteLine($"* {clothe} - {num}");
                        }
                    }
                }
                else
                {
                    foreach (var product in dicOfClotes)
                    {
                        Console.WriteLine($"* {product.Key} - {product.Value}");
                    }
                }
            }
        }
    }
}
