using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car(140, 100);
            Console.WriteLine(car.Fuel);
            car.Drive(100);
            Console.WriteLine(car.Fuel);

            Console.WriteLine("----------------------------------");
            Motorcycle motorcycle = new Motorcycle(140, 100);
            Console.WriteLine(motorcycle.Fuel);
            motorcycle.Drive(100);
            Console.WriteLine(motorcycle.Fuel);

            Console.WriteLine("----------------------------------");
            FamilyCar familyCar = new FamilyCar(140, 100);
            Console.WriteLine(familyCar.Fuel);
            familyCar.Drive(100);
            Console.WriteLine(familyCar.Fuel);

        }
    }
}
