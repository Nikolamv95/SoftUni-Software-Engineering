using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<Trainer> listOfTrainers = new List<Trainer>();
            
            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string nameTrainer = data[0];
                string namePokemon = data[1];
                string elementPokemon = data[2];
                int healthPokemon= int.Parse(data[3]);
                int numOfBadges = 0;

                Pokemon currPokemon = new Pokemon(namePokemon, elementPokemon, healthPokemon);
                

                if (listOfTrainers.Exists(x=>x.Name == nameTrainer) == false)
                {
                    List<Pokemon> listOfPokemons = new List<Pokemon>();
                    listOfPokemons.Add(currPokemon);
                    Trainer currTrainer = new Trainer(nameTrainer, numOfBadges, listOfPokemons);
                    listOfTrainers.Add(currTrainer);
                }
                else
                {
                    var tu = listOfTrainers.Single(x => x.Name == nameTrainer);
                    tu.Pokemons.Add(currPokemon);
                }
            }

            string badge = string.Empty;

            while ((badge = Console.ReadLine()) != "End")
            {
                for (int i = 0; i < listOfTrainers.Count; i++)
                {
                    string nameTrainer = listOfTrainers[i].Name;

                    if (listOfTrainers[i].Pokemons.Exists(x => x.Element == badge))
                    {
                        listOfTrainers[i].NumOfBadges++;
                    }
                    else
                    {
                        var tu = listOfTrainers.Single(x => x.Name == nameTrainer);

                        for (int z = 0; z < listOfTrainers[i].Pokemons.Count; z++)
                        {
                            listOfTrainers[i].Pokemons[z].Health -= 10;
                            bool isDied = listOfTrainers[i].Pokemons.Exists(x => x.Health <= 0);

                            if (isDied)
                            {
                                tu.Pokemons.RemoveAll(x => x.Health < 0);
                                z--;
                            }
                        }
                    }
                }
            }

            foreach (var item in listOfTrainers.OrderByDescending(x=>x.NumOfBadges))
            {
                Console.WriteLine($"{item.Name} {item.NumOfBadges} {item.Pokemons.Count}");
            }
        }
    }
}
