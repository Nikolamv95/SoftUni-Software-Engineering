using System;
using System.Collections.Generic;
using System.Linq;

namespace shoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shoppingList = Console.ReadLine()
                                         .Split("!")
                                         .ToList();

            string input = Console.ReadLine();

            while (input != "Go Shopping!")
            {
                string[] data = input
                                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                 .ToArray();

                string operation = data[0];
                string product = string.Empty;
                string product2 = string.Empty;

                switch (operation)
                {
                    case "Urgent":
                        product = data[1];

                        if (!shoppingList.Contains(product))
                        {
                            shoppingList.Insert(0, product);
                        }
                        break;
                    case "Unnecessary":
                        product = data[1];

                        if (shoppingList.Contains(product))
                        {
                            shoppingList.Remove(product);
                        }
                        break;
                    case "Correct":
                        product = data[1];
                        product2 = data[2];

                        if (shoppingList.Contains(product))
                        {
                            int index = shoppingList.IndexOf(product);
                            shoppingList.Insert(index, product2);
                            shoppingList.Remove(product);
                        }
                        break;
                    case "Rearrange":
                        product = data[1];

                        if (shoppingList.Contains(product))
                        {
                            shoppingList.Remove(product);
                            shoppingList.Add(product);
                        }
                            break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", shoppingList));
        }
    }
}
