using System;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfUnputs = int.Parse(Console.ReadLine());

            string patternValid = @"(\@\#+)([A-z][a-zA-Z0-9]{4,}[A-Z])(\@\#+)";
            string patternNumber = @"\d";

            for (int i = 0; i < numberOfUnputs; i++)
            {
                string input = Console.ReadLine();
                Regex validRegex = new Regex(patternValid);
                Match match = validRegex.Match(input);

                if (match.Success)
                {

                }


            }



        }
    }
}
