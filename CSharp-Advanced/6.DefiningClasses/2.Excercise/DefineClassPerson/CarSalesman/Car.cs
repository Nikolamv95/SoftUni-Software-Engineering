using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public Car()
        {

        }

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }

        public Car(string model, Engine engine, string weight) : this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string weight, string color) : this(model, engine, weight)
        {
            this.Color = color;
        }

        public void ToString(List<Car> listOfCars)
        {
            foreach (var item in listOfCars)
            {
                Console.WriteLine($"{item.Model}:");
                Console.WriteLine($"  {item.Engine.Model}:");
                Console.WriteLine($"    Power: {item.Engine.Power}");
                Console.WriteLine($"    Displacement: {item.Engine.Displacement}");
                Console.WriteLine($"    Efficiency: {item.Engine.Efficiency}");
                Console.WriteLine($"  Weight: {item.Weight}");
                Console.WriteLine($"  Color: {item.Color}");
            }
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }
    }
}
