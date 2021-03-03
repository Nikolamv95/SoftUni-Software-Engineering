using MilitaryElite.Contracts;
using MilitaryElite.Core;
using MilitaryElite.Exceptions;
using System;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(string firstName, string lastName, int id, decimal salary, string corp)
            : base(firstName, lastName, id, salary)
        {
            this.Corps = this.TryParseCorps(corp);
        }

        public Corps Corps { get; private set; }

        private Corps TryParseCorps(string corpStr)
        {
            //This is the way how we Try to parse string value in to a Enum object (Corps corp);
            bool parsed = Enum.TryParse<Corps>(corpStr, out Corps corp);

            if (!parsed)
            {
                throw new InvalidCorpsException();
            }

            return corp;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                $"Corps: {this.Corps.ToString()}";
        }
    }
}
