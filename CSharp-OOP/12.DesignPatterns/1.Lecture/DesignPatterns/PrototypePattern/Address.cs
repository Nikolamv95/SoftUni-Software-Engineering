using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern
{
    public class Address : ICloneable
    {
        public City City { get; set; }
        public Country Country { get; set; }
        public string  Street { get; set; }

        public object Clone()
        {
            //Slallow copy
            //return this.MemberwiseClone(); 
            ////Or new Address () {City = City, Country = Country, Street = Street}

            //DeepCopy
            var clone = (Address)this.MemberwiseClone();
            clone.City = (City)City.Clone();
            clone.Country = (Country)Country.Clone();
            return clone;
        }

        public override string ToString()
        {
            return $"Country {this.Country.CountryName}, City {this.City.CityName}, Street {this.Street}";
        }
    }
}
