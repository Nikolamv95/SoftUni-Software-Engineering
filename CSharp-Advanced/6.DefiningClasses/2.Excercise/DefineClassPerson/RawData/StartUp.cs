using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            List<Car> listOfCars = new List<Car>();
            AddCars(rows, listOfCars);

            string command = Console.ReadLine();
            Car car = new Car();

            if (command == "fragile")
            {
                car.PrintFragile(listOfCars);
            }
            else if (command == "flamable")
            {
                car.PrintFlamable(listOfCars);
            }
        }

        private static void AddCars(int rows, List<Car> listOfCars)
        {
            for (int i = 0; i < rows; i++)
            {
                //Input
                string[] input = Console.ReadLine().Split().ToArray();
                //Model
                string model = input[0];
                //Engine
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                //Cargo
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                //Tires 1
                double tirePressuerOne = double.Parse(input[5]);
                int tireAgeOne = int.Parse(input[6]);
                //Tires 2
                double tirePressuerTwo = double.Parse(input[7]);
                int tireAgeTwo = int.Parse(input[8]);
                //Tires 3
                double tirePressuerThree = double.Parse(input[9]);
                int tireAgeThree = int.Parse(input[10]);
                //Tires 4
                double tirePressuerFour = double.Parse(input[11]);
                int tireAgeFour = int.Parse(input[12]);

                Engine currEngine = new Engine(engineSpeed, enginePower);
                Cargo currCargo = new Cargo(cargoWeight, cargoType);

                Tire[] currTires = new Tire[4]
                {
                new Tire(tirePressuerOne, tireAgeOne),
                new Tire(tirePressuerTwo, tireAgeTwo),
                new Tire(tirePressuerThree, tireAgeThree),
                new Tire(tirePressuerFour, tireAgeFour),
                };

                Car currCar = new Car(model, currEngine, currCargo, currTires);
                listOfCars.Add(currCar);
            }
        }
    }
}
