using System;
using System.Collections.Generic;
using System.Linq;

namespace minerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string resource = Console.ReadLine();

            Dictionary<string, int> listOfResources = new Dictionary<string, int>();

            while (resource != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (listOfResources.ContainsKey(resource) == false)
                {
                    listOfResources.Add(resource, quantity);
                }
                else
                {
                    listOfResources[resource] += quantity;
                }
                resource = Console.ReadLine();
            }

            foreach (var item in listOfResources)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
