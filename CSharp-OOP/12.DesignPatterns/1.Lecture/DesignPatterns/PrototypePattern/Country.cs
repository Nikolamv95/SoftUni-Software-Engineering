using System;

namespace PrototypePattern
{
    public class Country : ICloneable
    {
        public string CountryName { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}