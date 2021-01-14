using System;
using System.Collections.Generic;
using System.Linq;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfItems = Console.ReadLine()
                                       .Split(", ")
                                       .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Craft!")
            {
                string[] data = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                switch (data[0])
                {
                    case "Collect":
                        if (!listOfItems.Contains(data[1]))
                        {
                            listOfItems.Add(data[1]);
                        }
                        break;
                    case "Drop":
                        if (listOfItems.Contains(data[1]))
                        {
                            listOfItems.Remove(data[1]);
                        }
                        break;
                    case "Combine Items":
                        string[] newData = data[1]
                                            .Split(":")
                                            .ToArray();

                        string oldItem = newData[0];
                        string newItem = newData[1];

                        if (listOfItems.Contains(oldItem))
                        {
                            int index = listOfItems.IndexOf(oldItem);
                            listOfItems.Insert(index + 1, newItem);
                        }
                        break;
                    case "Renew":
                        if (listOfItems.Contains(data[1]))
                        {
                            listOfItems.Remove(data[1]);
                            listOfItems.Add(data[1]);
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", listOfItems));
        }
    }
}
