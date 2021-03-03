using System;
using System.Collections.Generic;
using System.Text;

namespace AttributesPropValidation
{
    public class RangeAttribute : Attribute
    {
        public RangeAttribute(int minLength, int maxLength)
        {
            this.MinLength = minLength;
            this.MaxLength = maxLength;
        }

        public int MinLength { get; set; }
        public int MaxLength { get; set; }

        public bool IsValid(int number)
        {
            return number >= this.MinLength && number <= this.MaxLength;
        }
    }
}
