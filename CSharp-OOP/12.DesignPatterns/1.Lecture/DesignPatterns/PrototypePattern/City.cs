﻿using System;

namespace PrototypePattern
{
    public class City : ICloneable
    {
        public string CityName { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}