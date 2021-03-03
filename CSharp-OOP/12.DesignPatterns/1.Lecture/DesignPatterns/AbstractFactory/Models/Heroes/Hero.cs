using AbstractFactory.Models.Humans.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Models.Humans
{
    public abstract class Hero : IHero
    {
        public Hero(string name, int age, string continent)
        {
            this.Name = name;
            this.Age = age;
            this.Continent = continent;
        }

        public string Name {get; private set;}

        public int Age { get; private set; }

        public string Continent { get; private set; }
    }
}
