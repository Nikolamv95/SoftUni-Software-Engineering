using System;
using System.Collections.Generic;
using System.Linq;

namespace CitiesContinentCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfInputs = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> dicOfContinents = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < numOfInputs; i++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string continent = data[0];
                string country = data[1];
                string city = data[2];
                Dictionary<string, List<string>> dicOfCountries = new Dictionary<string, List<string>>();
                List<string> listOfCities = new List<string>();

                //Вкарваме данни ако няма такъв континент
                if (dicOfContinents.ContainsKey(continent) == false)
                {
                    listOfCities.Add(city);
                    dicOfCountries.Add(country, listOfCities);
                    dicOfContinents.Add(continent, dicOfCountries);
                }
                else
                {
                    //Прваим проверка дали в конкретния континент съществува държавата
                    if (dicOfContinents[continent].ContainsKey(country) == true)
                    {
                        dicOfContinents[continent][country].Add(city);
                    }
                    else
                    {
                        listOfCities.Add(city);
                        dicOfContinents[continent].Add(country,listOfCities);
                    }
                }
            }

            foreach (var item in dicOfContinents)
            {
                Console.WriteLine($"{item.Key}:");

                foreach (var countries in item.Value)
                {
                    Console.WriteLine($"{countries.Key} -> {string.Join(", ",countries.Value)}");
                }
            }

        }
    }
}
