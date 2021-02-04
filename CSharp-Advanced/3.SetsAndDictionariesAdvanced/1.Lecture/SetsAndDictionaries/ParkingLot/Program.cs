using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> setOfCars = new HashSet<string>();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] data = command.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string operation = data[0];
                string carReg = data[1];

                if (operation == "IN")
                {
                    setOfCars.Add(carReg);
                }
                else if (operation == "OUT")
                {
                    setOfCars.Remove(carReg);
                }
            }

            if (setOfCars.Count > 0)
            {
                foreach (var item in setOfCars)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
