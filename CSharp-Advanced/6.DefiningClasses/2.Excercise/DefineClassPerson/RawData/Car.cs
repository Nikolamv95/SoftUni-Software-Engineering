using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class Car
    {
        public Car()
        {

        }

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }

        public void PrintFragile(List<Car> listOfCars)
        {
            var filtList = listOfCars.Where(x => x.Cargo.CargoType == "fragile");

            foreach (var item in listOfCars)
            {
                double sumTire = item.Tires.Sum(x => x.TirePressure);

                if (sumTire / 4 < 1)
                {
                    Console.WriteLine(item.Model);
                }
            }
            
        }
        public void PrintFlamable(List<Car> listOfCars)
        {
            var filtList = listOfCars.Where(x => x.Cargo.CargoType == "flamable");
            foreach (var item in filtList.Where(x => x.Engine.EnginePower > 250))
            {
                Console.WriteLine(item.Model);
            }
        }
    }
}
