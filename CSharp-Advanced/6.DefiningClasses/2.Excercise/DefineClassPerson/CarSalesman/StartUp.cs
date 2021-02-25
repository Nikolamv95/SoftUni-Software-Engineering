using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            List<Engine> listOfEngines = new List<Engine>();
            AddingEngines(rows, listOfEngines);

            List<Car> listOfCars = new List<Car>();
            int rowsCars = int.Parse(Console.ReadLine());
            AddingCars(listOfEngines, listOfCars, rowsCars);

            Car car = new Car();
            car.ToString(listOfCars);
        }

        private static void AddingCars(List<Engine> listOfEngines, List<Car> listOfCars, int rowsCars)
        {
            for (int i = 0; i < rowsCars; i++)
            {
                string[] data = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();
                string modelCar = string.Empty;
                string carEngine = string.Empty;
                string weightCar = "n/a";
                string colorCar = "n/a";

                if (data.Length == 2)
                {
                    modelCar = data[0];
                    carEngine = data[1];
                }
                else if (data.Length == 3)
                {
                    modelCar = data[0];
                    carEngine = data[1];

                    if (Char.IsDigit(weightCar[0]))
                    {
                        weightCar = data[2];
                    }
                    else
                    {
                        colorCar = data[2];
                    }
                }
                else if (data.Length == 4)
                {
                    modelCar = data[0];
                    carEngine = data[1];
                    weightCar = data[2];
                    colorCar = data[3];
                }

                var currEngine = listOfEngines.Single(x => x.Model == carEngine);
                Car currCar = new Car(modelCar, currEngine, weightCar, colorCar);
                listOfCars.Add(currCar);
            }
        }

        private static void AddingEngines(int rows, List<Engine> listOfEngines)
        {
            for (int i = 0; i < rows; i++)
            {
                string[] data = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();
                string modelEngine = string.Empty;
                int powerEngine = 0;
                string displacement = "n/a";
                string efficiency = "n/a";

                if (data.Length == 2)
                {
                    modelEngine = data[0];
                    powerEngine = int.Parse(data[1]);
                }
                else if (data.Length == 3)
                {
                    modelEngine = data[0];
                    powerEngine = int.Parse(data[1]);

                    if (Char.IsDigit(data[2][0]))
                    {
                        displacement = data[2];
                    }
                    else
                    {
                        efficiency = data[2];
                    }
                }
                else if (data.Length == 4)
                {
                    modelEngine = data[0];
                    powerEngine = int.Parse(data[1]);
                    displacement = data[2];
                    efficiency = data[3];
                }

                Engine currEnine = new Engine(modelEngine, powerEngine, displacement, efficiency);
                listOfEngines.Add(currEnine);
            }
        }
    }
}
