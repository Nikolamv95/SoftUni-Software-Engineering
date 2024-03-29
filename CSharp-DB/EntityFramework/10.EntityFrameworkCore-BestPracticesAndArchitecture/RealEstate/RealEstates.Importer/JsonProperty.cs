﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstates.Importer
{
    public class JsonProperty
    {
        public int Size { get; set; }
        public int Floor { get; set; }
        public int TotalFloors { get; set; }
        public string District { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public string BuildingType { get; set; }
        public int Price { get; set; }
    }
}
