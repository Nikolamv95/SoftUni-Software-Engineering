using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {   //Стъпка 1 - Създаваме нов клас -> Vehicle
            //Стъпка 2 - Създаваме списък за коли
            List<Vehicle> listOfVehicles = new List<Vehicle>();
            //Стъпка 3 - Взимаме input
            string input = Console.ReadLine();

            //Стъпка 4 - Стъздаваме While цикъл за проверка и вкарване на данните в списъка listOfVehicles
            while (input != "End" )
            {
                //Разбиваме input-a в масив и взимаме данните в него
                string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                //Разпределяме данните
                string typeOfVehicle = data[0];
                string modelOfVehicle = data[1];
                string colorOfVehicle = data[2];
                int horsepowerOfVehicle = int.Parse(data[3]);

                //Викаме инстанция от Vehicle с променлива currVehicle и подаваме данните които да се запишат в конструктура
                Vehicle currVehicle = new Vehicle(typeOfVehicle, modelOfVehicle, colorOfVehicle, horsepowerOfVehicle);
                //Добавяме в каталога данните
                listOfVehicles.Add(currVehicle);
                input = Console.ReadLine();
            }

            //Стъпка 5 - взимаме командите за конкретното превозно средство и да го отпечатаме

            string command = Console.ReadLine();

            while (command != "Close the Catalogue")
            {
                //Взимаме стойността на command
                string modelType = command;

                //Дефинираме нова променлива от тип Vehicle върху който да се запишат стойностите на модела кола който ни е подаден.
                //В случая върху printCar се записва стойността на колата която търсим modelType. За да се случи това бъркаме в списъка
                //listOfVehicles и с фукцията First взимаме първия елемент който намери със стойност modelType. Използват се предикати.
                Vehicle printCar = listOfVehicles.First(x => x.Model == modelType);

                //Принтираме стойността на printCar.
                Console.WriteLine(printCar);

                command = Console.ReadLine();
            }

            //Стъпка 6 - създаваме нови списъци, за да разделим колито от камионите
            List<Vehicle> onlyCars = listOfVehicles.Where(x => x.Type == "car").ToList();
            List<Vehicle> onlyTrucks = listOfVehicles.Where(x => x.Type == "truck").ToList();

            //Взимаме целите стойности на HP от колекция onlyCars
            double totalCarsHp = onlyCars.Sum(x => x.HorsePower);
            //Взимаме целите стойности на HP от колекция onlyTrucks
            double totalTruckHp = onlyTrucks.Sum(x => x.HorsePower);

            double avgCarHp = 0.00;
            double avgTruckHp = 0.00;

            //Стъпка 7 - проверяваме дали някой от листовете не е празен. Правим това защото не можем да делим 0/0
            if (onlyCars.Count > 0)
            {
                avgCarHp = totalCarsHp / onlyCars.Count;
            }
            if (onlyTrucks.Count > 0)
            {
                avgTruckHp = totalTruckHp / onlyTrucks.Count;
            }

            Console.WriteLine($"Cars have average horsepower of: {avgCarHp:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {avgTruckHp:f2}.");
        }
    }
}
 