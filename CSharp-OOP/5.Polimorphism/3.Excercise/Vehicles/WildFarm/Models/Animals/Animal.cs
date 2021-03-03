using System;
using System.Collections.Generic;
using WildFarm.Models.Animals.Contracts;
using WildFarm.Models.Foods.Contracts;

namespace WildFarm.Models.Animals
{
    public abstract class Animal 
        : IAnimal, IFeedable, ISoundProducable
    {
        private const string FOOD_DONT_EAT_MSG = "{0} does not eat {1}!";

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public abstract double WeightMultiplier { get; }

        /// <summary>
        /// This collection holds the type of preffered foods. typeof(fruit), typeof(meat) etc...
        /// </summary>
        public abstract ICollection<Type> PreferedFoods { get; }

        public void Feed(IFood food)
        {
            if (!this.PreferedFoods.Contains(food.GetType()))
            {                                                                       //We are taking the type of the animal,
                                                                                    //and the type of the food.
                throw new InvalidOperationException(string.Format(FOOD_DONT_EAT_MSG, this.GetType().Name, food.GetType().Name));
            }
            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * this.WeightMultiplier;
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
