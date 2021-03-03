using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int maxPower = 80;

        public Druid(string name)
            : base(name)
        {
        }

        public override int Power => maxPower;
    }
}
