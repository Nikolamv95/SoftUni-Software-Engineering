﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;

        }

        public Engine(string model, int power, string displacement) : this(model, power)
        {
            this.Displacement = displacement;

        }

        public Engine(string model, int power, string displacement, string efficiency) : this(model, power, displacement)
        {
            this.Efficiency = efficiency;
        }


        public string Model { get; set; }
        public int Power { get; set; }
        public string Displacement { get; set; }
        public string Efficiency { get; set; }
    }
}
