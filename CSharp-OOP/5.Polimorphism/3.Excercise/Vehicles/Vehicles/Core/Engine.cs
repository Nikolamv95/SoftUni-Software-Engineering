using System;
using System.Linq;
using VehiclesV2.Contracts;
using VehiclesV2.Exceptions;
using VehiclesV2.IO.Contracts;

namespace VehiclesV2.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine()
        {

        }
        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] carArg = reader.ReadLine().Split().ToArray();
            string[] truckArg = reader.ReadLine().Split().ToArray();

            IVehicle carVehicle = new Car(double.Parse(carArg[1]), double.Parse(carArg[2]));
            IVehicle truckVehicle = new Truck(double.Parse(truckArg[1]), double.Parse(truckArg[2]));

            int rows = int.Parse(reader.ReadLine());

            for (int i = 0; i < rows; i++)
            {
                string[] comArg = reader.ReadLine().Split().ToArray();
                string command = comArg[0];
                string vehicle = comArg[1];
                double distanceQuantity = double.Parse(comArg[2]);

                try
                {
                    switch (vehicle)
                    {
                        case "Car":
                            if (command == "Drive")
                            {
                                carVehicle.DriveVehicle(distanceQuantity);
                            }
                            else if (command == "Refuel")
                            {
                                carVehicle.RefuelVehicle(distanceQuantity);
                            }
                            break;
                        case "Truck":
                            if (command == "Drive")
                            {
                                truckVehicle.DriveVehicle(distanceQuantity);
                            }
                            else if (command == "Refuel")
                            {
                                truckVehicle.RefuelVehicle(distanceQuantity);
                            }
                            break;
                    }
                }
                catch (InvalidCarFuelException cfe)
                {
                    Console.WriteLine(cfe.Message);
                }
                catch(InvalidTruckFuelException tfe)
                {
                    Console.WriteLine(tfe.Message);
                }
                
            }

            Console.WriteLine($"{carVehicle.GetRemainingFuel()}");
            Console.WriteLine($"{truckVehicle.GetRemainingFuel()}");
        }
    }
}
