using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern.Models
{
    public class CarBuilder : ICarBuilder
    {
        public void BuildEngine(Car car)
        {
            car.Engine = "Create class Engine and implement it`s funcionality";
        }

        public void BuildTransmission(Car car)
        {
            car.Transmission = "Create class Transmission and implement it`s funcionality";
        }

        public void BuildTyres(Car car)
        {
            car.Tyres = "Create class Tyres and implement it`s funcionality";
        }
    }
}
