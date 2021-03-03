using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildFarm.Core.Contracts;
using WildFarm.Core.Factories;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {

        private ICollection<Animal> animals;
        private readonly AnimalFactory animalFactory;
        private readonly FoodFactory foodFactory;

        public Engine()
        {
            this.animalFactory = new AnimalFactory();
            this.foodFactory = new FoodFactory();
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {

                string[] animalArgs = command
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .ToArray();

                string type = animalArgs[0];
                string name = animalArgs[1];
                double weight = double.Parse(animalArgs[2]);
                string[] args = animalArgs.Skip(3).ToArray();

                Animal animal = null;
                try
                {
                    animal = this.animalFactory.CreateAnimal(type, name, weight, args);
                    this.animals.Add(animal);
                    Console.WriteLine(animal.ProduceSound());
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                string[] foodArgs = Console.ReadLine()
                                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                                    .ToArray();

                string foodType = foodArgs[0];
                int foodQty = int.Parse(foodArgs[1]);

                try
                {
                    Food food = this.foodFactory.CreateFood(foodType, foodQty);
                    animal?.Feed(food);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            foreach (var item in this.animals)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
