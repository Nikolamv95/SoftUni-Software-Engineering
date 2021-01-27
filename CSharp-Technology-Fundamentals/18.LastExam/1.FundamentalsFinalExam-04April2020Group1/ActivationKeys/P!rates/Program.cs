using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_rates
{
    class Town
    {
        public string TownName { get; set; }
        public int Citizens { get; set; }
        public int Gold { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Town> listOfTowns = new List<Town>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] data = input
                                     .Split("||")
                                     .ToArray();

                string cityName = data[0];
                int amountOfCitizens = int.Parse(data[1]);
                int amountOfGold = int.Parse(data[2]);

                Town currTown = new Town();

                currTown.TownName = cityName;
                currTown.Citizens = amountOfCitizens;
                currTown.Gold = amountOfGold;

                if (listOfTowns.Any(x=>x.TownName == cityName))
                {
                    var tu = listOfTowns.Single(x => x.TownName == cityName);
                    tu.Citizens += amountOfCitizens;
                    tu.Gold += amountOfGold;
                }
                else
                {
                    listOfTowns.Add(currTown);
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command
                                     .Split("=>")
                                     .ToArray();

                string operation = data[0];
                Town currTown = new Town();

                switch (operation)
                {
                    case "Plunder":
                        string cityName = data[1];
                        int amountOfCitizens = int.Parse(data[2]);
                        int amountOfGold = int.Parse(data[3]);

                        Console.WriteLine($"{cityName} plundered! {amountOfGold} gold stolen, {amountOfCitizens} citizens killed.");

                        var tu = listOfTowns.Single(x => x.TownName == cityName);
                        tu.Citizens -= amountOfCitizens;
                        tu.Gold -= amountOfGold;

                        if (tu.Citizens <= 0 || tu.Gold <= 0)
                        {
                            listOfTowns.RemoveAll(x => x.TownName == cityName);
                            Console.WriteLine($"{cityName} has been wiped off the map!");
                        }
                        break;
                    case "Prosper":
                        string cityNameIncrease = data[1];
                        int amountOfGoldIncrease = int.Parse(data[2]);

                        if (amountOfGoldIncrease < 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                            break;
                        }
                        else
                        {
                            var tuu = listOfTowns.Single(x => x.TownName == cityNameIncrease);
                            tuu.Gold += amountOfGoldIncrease;
                            int currGold = tuu.Gold;

                            Console.WriteLine($"{amountOfGoldIncrease} gold added to the city treasury. " +
                                              $"{cityNameIncrease} now has {currGold} gold.");
                        }
                        break;
                }  
            }
            Console.WriteLine($"Ahoy, Captain! There are {listOfTowns.Count} wealthy settlements to go to:");

            var filteredList = listOfTowns.OrderByDescending(g => g.Gold).ThenBy(n => n.TownName);

            foreach (var item in filteredList)
            {
                Console.WriteLine($"{item.TownName} -> Population: {item.Citizens} citizens, Gold: {item.Gold} kg");
            }
        }
    }
}
