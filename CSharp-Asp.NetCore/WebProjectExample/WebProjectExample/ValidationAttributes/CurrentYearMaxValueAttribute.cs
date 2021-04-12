using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebProjectExample.Data;

namespace WebProjectExample.ValidationAttributes
{
    public class CurrentYearMaxValueAttribute : ValidationAttribute
    {
        //The min year in the constructor is received from the attribute [CurrentYearMaxValueAttribute(1900)]
        private readonly int minYear;

        public CurrentYearMaxValueAttribute(int minYear)
        {
            this.minYear = minYear;
        }
        public override bool IsValid(object value)
        {
            //do something with minYear to validate the value -> Example

            if (value is int intValue)  
            {
                if (intValue <= DateTime.UtcNow.Year)
                {
                    return true;
                }
            }

            return false;


            
        }

        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    //if we want we can use the DB to compare input data with data from the DB
        //    var context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
        //    //do something with the context
        //}
    }
}
