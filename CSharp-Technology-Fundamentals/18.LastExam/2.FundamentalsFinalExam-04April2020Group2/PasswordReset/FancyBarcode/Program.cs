using System;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfUnputs = int.Parse(Console.ReadLine());

            string patternValid = @"(\@\#+)([A-Z][a-zA-Z0-9]{4,}[A-Z])(\@\#+)";
            string patternNumber = @"\d+";
            Regex validRegex = new Regex(patternValid);
            Regex validNumber = new Regex(patternNumber);

            for (int i = 0; i < numberOfUnputs; i++)
            {
                string input = Console.ReadLine();
                Match match = validRegex.Match(input);

                if (match.Success)
                {
                    Match matchNumber = validNumber.Match(input);
                    if (matchNumber.Success)
                    {
                        MatchCollection collOfNumbers = Regex.Matches(input, patternNumber);
                        string currProduct = string.Empty;
                        foreach (Match item in collOfNumbers)
                        {
                            currProduct += item.Value.ToString();
                        }
                        Console.WriteLine($"Product group: {currProduct}");
                    }
                    else
                    {
                        Console.WriteLine("Product group: 00");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
