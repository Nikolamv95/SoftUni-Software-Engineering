using Raiding.Core.Contracts;
using Raiding.Core.Factories;
using Raiding.IO.Contracts;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        //Private Fields
        private readonly HeroFactory heroFactory;
        private readonly ICollection<BaseHero> heroes;

        private IReader reader;
        private IWriter writer;

        //Constructors
        public Engine()
        {
            this.heroFactory = new HeroFactory();
            this.heroes = new List<BaseHero>();
        }
        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        //Methods
        public void Run()
        {
            int n = int.Parse(reader.ReadLine());
            AddHeroes(n);

            int bossPower = int.Parse(reader.ReadLine());
            int sumPower = this.heroes.Sum(x => x.Power);

            PrintCastAbility();
            writer.WriteLine(VictoryOrDefeat(bossPower, sumPower));
        }

        private void PrintCastAbility()
        {
            foreach (var hero in this.heroes)
            {
                writer.WriteLine(hero.CastAbility());
            }
        }
        private string VictoryOrDefeat(int bossPower, int sumPower)
        {
            if (bossPower > sumPower)
            {
                return "Defeat...";
            }
            else
            {
                return "Victory!";
            }
        }
        private void AddHeroes(int n)
        {
            int counter = 0;

            while (counter != n)
            {
                try
                {
                    BaseHero hero = this.ProcessHeroInfo();
                    this.heroes.Add(hero);
                    counter++;
                }
                catch (InvalidOperationException se)
                {
                    writer.WriteLine(se.Message);
                }
            }
            
                
            
        }
        private BaseHero ProcessHeroInfo()
        {
            string nameHero = reader.ReadLine();
            string typeHero = reader.ReadLine();
            BaseHero hero = this.heroFactory.CreateHero(typeHero, nameHero);
            return hero;
        }
    }
}
