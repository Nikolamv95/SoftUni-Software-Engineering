using FluentInterface.Models.Contracts;

namespace FluentInterface.Models
{
    public class CarBuilder : ICarBuilder
    {
        public ICarBuilder BuildEngine(Car car)
        {
            car.Engine = "Create class Engine and implement it`s funcionality";
            return this;
        }

        public ICarBuilder BuildTransmission(Car car)
        {
            car.Transmission = "Create class Transmission and implement it`s funcionality";
            return this;
        }

        public ICarBuilder BuildTyres(Car car)
        {
            car.Tyres = "Create class Tyres and implement it`s funcionality";
            return this;
        }
    }
}
