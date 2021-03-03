using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public interface ICarBuilder
    {
        void BuildTyres(Car car);
        void BuildEngine(Car car);
        void BuildTransmission(Car car);
    }
}
