using Raiding.Commons;
using Raiding.Models;
using System;

namespace Raiding.Core.Factories
{
    public class HeroFactory
    {
        public BaseHero CreateHero(string typeHero, string name)
        {
            BaseHero hero = null;

            if (typeHero == "Druid")
            {
                hero = new Druid(name);
            }
            else if (typeHero == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (typeHero == "Rogue")
            {
                hero = new Rogue(name);
            }
            else if (typeHero == "Warrior")
            {
                hero = new Warrior(name);
            }
            else
            {
                throw new InvalidOperationException(GlobalExceptions.INV_HERO_MSG);
            }

            return hero;
        }
    }
}
