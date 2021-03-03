using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Birds
{
    public class Hen : Bird
    {
        private const double weightMultipler = 0.35;
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {

        }

        public override double WeightMultiplier => weightMultipler;

        public override ICollection<Type> PreferedFoods => new List<Type>() { typeof(Vegetable), typeof(Seeds), typeof(Meat), typeof(Fruit)};

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
