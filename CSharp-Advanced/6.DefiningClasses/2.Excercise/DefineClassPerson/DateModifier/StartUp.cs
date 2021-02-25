using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            List<DateTime> listOfDateTime = new List<DateTime>();

            for (int i = 0; i < 2; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                int year = int.Parse(input[0]);
                int month = int.Parse(input[1]);
                int day = int.Parse(input[2]);

                DateTime currTime = new DateTime(year, month, day);
                listOfDateTime.Add(currTime);
            }

            DateModifier dateModifier = new DateModifier();
            long result = dateModifier.CalculateDate(listOfDateTime);
            Console.WriteLine(result);
        }
    }
}