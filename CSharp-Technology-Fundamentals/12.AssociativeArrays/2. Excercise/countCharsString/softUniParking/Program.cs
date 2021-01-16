using System;
using System.Collections.Generic;

namespace softUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            Dictionary<string, string> listOfCars = new Dictionary<string, string>();

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine()
                                 .Split();

                string operation = input[0];
                string name = input[1];
                

                switch (operation)
                {
                    case "register":

                        string plateNumber = input[2];

                        if (listOfCars.ContainsKey(name) == true)
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {plateNumber}"); 
                        }
                        else
                        {
                            listOfCars.Add(name, plateNumber);
                            Console.WriteLine($"{name} registered {plateNumber} successfully");
                        }
                        break;
                    case "unregister":
                        if (listOfCars.ContainsKey(name) == false)
                        {
                            Console.WriteLine($"ERROR: user {name} not found");
                        }
                        else
                        {
                            listOfCars.Remove(name);
                            Console.WriteLine($"{name} unregistered successfully");
                        }
                        break;
                }
            }

            foreach (var item in listOfCars)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
