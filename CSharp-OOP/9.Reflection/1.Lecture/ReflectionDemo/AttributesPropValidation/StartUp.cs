using System;
using System.Collections;

namespace AttributesPropValidation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var movie = new Movie()
            {
                Name = "TODOT",
                Description = "DONOTdonotDONOTdonotDONOTdonotDONOTdonot",
                Year = 2040,
                Price = 4320m,
            };

            var isValid = Validator.Validate(movie);
            Console.WriteLine(isValid);
        }
    }
}
