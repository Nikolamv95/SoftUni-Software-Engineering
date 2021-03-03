using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Models.Humans.Contracts
{
    public class Magician : Hero
    {
        public Magician(string name, int age, string continent) 
            : base (name, age , continent)
        {

        }
    }
}
