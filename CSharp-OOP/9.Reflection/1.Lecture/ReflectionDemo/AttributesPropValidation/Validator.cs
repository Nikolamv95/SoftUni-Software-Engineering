using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AttributesPropValidation
{
    public static class Validator
    {
        public static bool Validate(Movie movie)
        {
            var allProperties = movie.GetType().GetProperties();

            foreach (var currProp in allProperties)
            {
                var rangeAttributes = currProp.GetCustomAttributes(typeof(RangeAttribute), true);
                var curPropValue = currProp.GetValue(movie);

                foreach (var currAtt in rangeAttributes)
                {
                    int length = curPropValue.ToString().Length;
                    var isValid = ((RangeAttribute)currAtt).IsValid(length);
                    
                    if (isValid)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
