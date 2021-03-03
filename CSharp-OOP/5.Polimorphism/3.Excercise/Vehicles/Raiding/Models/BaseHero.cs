using Raiding.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class BaseHero : ICastableAbility
    {
        public BaseHero(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
        public virtual int Power { get; }

        public virtual string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
