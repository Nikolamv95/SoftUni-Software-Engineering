using System;
using System.Collections.Generic;
using System.Linq;

namespace task6
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfCompanies = int.Parse(Console.ReadLine());
            Dictionary<string, int> dicOfCompanies = new Dictionary<string, int>();

            for (int i = 0; i < numOfCompanies; i++)
            {
                string flightCompany = Console.ReadLine();
                string input = string.Empty;
                int counter = 0;
                int passangersPerCompany = 0;

                while ((input = Console.ReadLine()) != "Finish")
                {
                    int numOfPassangers = int.Parse(input);
                    counter++;

                    if (dicOfCompanies.ContainsKey(flightCompany) == false)
                    {
                        dicOfCompanies.Add(flightCompany, 0);
                    }
                    passangersPerCompany += numOfPassangers;
                }

                int averagePassengers = passangersPerCompany / counter;
                dicOfCompanies[flightCompany] += averagePassengers;
            }

            foreach (var item in dicOfCompanies)
            {
                Console.WriteLine($"{item.Key}: {item.Value} passengers.");
            }

            var filtDic = dicOfCompanies.OrderByDescending(x => x.Value);

            foreach (var item in filtDic)
            {
                Console.WriteLine($"{item.Key} has most passengers per flight: {item.Value}");
                break;
            }
        }
    }
}
