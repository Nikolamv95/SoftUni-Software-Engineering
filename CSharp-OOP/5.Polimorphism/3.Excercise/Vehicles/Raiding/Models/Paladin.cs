using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int maxPower = 100;

        public Paladin(string name)
            : base(name)
        {
        }

        public override int Power => maxPower;
    }
}
