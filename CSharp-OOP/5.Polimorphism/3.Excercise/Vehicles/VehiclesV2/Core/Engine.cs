using System;
using System.Collections.Generic;
using System.Linq;

using VehiclesV2.Contracts;
using VehiclesV2.Core.Factories;
using VehiclesV2.IO.Contracts;
using VehiclesV2.Models;

namespace VehiclesV2.Core
{
    public class Engine : IEngine
    {
        private readonly VehicleFactory vehicleFactory;

        private IReader reader;
        private IWriter writer;

        public Engine()
        {
            this.vehicleFactory = new VehicleFactory();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            Vehicle car = this.ProcessVehicleInfo();
            Vehicle truck = this.ProcessVehicleInfo();
            Vehicle bus = this.ProcessVehicleInfo();

            int n = int.Parse(reader.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] comArg = reader.ReadLine().Split().ToArray();
                string command = comArg[0];
                string vehicleType = comArg[1];
                //Can be distance or quantity
                double distanceQuantity = double.Parse(comArg[2]);

                try
                {
                    switch (vehicleType)
                    {
                        case "Car":
                            if (command == "Drive")
                            {
                                Drive(car, distanceQuantity);
                            }
                            else if (command == "Refuel")
                            {
                                Refuel(car, distanceQuantity);
                            }
                            break;
                        case "Truck":
                            if (command == "Drive")
                            {
                                Drive(truck, distanceQuantity);
                            }
                            else if (command == "Refuel")
                            {
                                Refuel(truck, distanceQuantity);
                            }
                            break;
                        case "Bus":
                            if (command == "Drive")
                            {
                                Drive(bus, distanceQuantity);
                            }
                            if (command == "DriveEmpty")
                            {
                                ((Bus)bus).SwitchOffAirConditioner();
                                Drive(bus, distanceQuantity);
                                ((Bus)bus).SwitchOnAirConditioner();
                            }
                            else if (command == "Refuel")
                            {
                                Refuel(bus, distanceQuantity);
                            }
                            break;

                    }
                }
                catch (InvalidOperationException ioe)
                {
                    writer.WriteLine(ioe.Message);
                }
            }

            writer.WriteLine(car.ToString());
            writer.WriteLine(truck.ToString());
            writer.WriteLine(bus.ToString());
        }

        private void Drive(Vehicle vehicle, double distanceQuantity)
        {
            writer.WriteLine(vehicle.Drive(distanceQuantity));
        }
        private void Refuel(Vehicle vehicle, double distanceQuantity)
        {
            vehicle.Refuel(distanceQuantity);
        }

        /// <summary>
        /// It will create Vehicle by the given information
        /// </summary>
        /// <returns></returns>
        private Vehicle ProcessVehicleInfo()
        {
            string[] vehicleArgs = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string vehicleType = vehicleArgs[0];
            double fuelQuantity = double.Parse(vehicleArgs[1]);
            double fuelConsumpt = double.Parse(vehicleArgs[2]);
            double tankFuel = double.Parse(vehicleArgs[3]);

            Vehicle currVehicle = this.vehicleFactory.CreateVehicle(vehicleType, fuelQuantity, fuelConsumpt, tankFuel);
            return currVehicle;
        }
    }
}
