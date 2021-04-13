using System;
using System.ComponentModel.DataAnnotations;

namespace WebProjectExample.ValidationAttributes
{
    public class YearRangeAttribute : ValidationAttribute
    {
        private readonly int minYear;

        public YearRangeAttribute(int minYear)
        {
            this.minYear = minYear;
        }

        public override bool IsValid(object value)
        {
            if (value is DateTime dtValue)
            {
                if (dtValue.Year <= DateTime.UtcNow.Year && dtValue.Year >= this.minYear)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
