using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Models.Humans.Contracts
{
    public class Warrior : Hero
    {
        public Warrior(string name, int age, string continent) 
            : base(name, age, continent)
        {
        }
    }
}
