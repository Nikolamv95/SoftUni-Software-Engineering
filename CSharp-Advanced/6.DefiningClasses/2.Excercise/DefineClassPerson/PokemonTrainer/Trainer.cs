using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    class Trainer
    {
        public Trainer(string name, int numOfBadges, List<Pokemon> pokemons)
        {
            this.Name = name;
            this.NumOfBadges = numOfBadges;
            this.Pokemons = pokemons;
        }

        public string Name { get; set; }
        public int NumOfBadges { get; set; }
        public List<Pokemon> Pokemons { get; set; }
    }
}
