using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfUnputs = int.Parse(Console.ReadLine());

            string patternValid = @"\@\#+[A-Z][a-zA-Z0-9]{4,}[A-Z]\@\#+";

            for (int i = 0; i < numberOfUnputs; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, patternValid);

                if (match.Success)
                {
                    string compare = match.Value;
                    string temp = string.Empty;

                    for (int z = 0; z < compare.Length; z++)
                    {

                        if (char.IsDigit(compare[z]))
                        {
                            temp += compare[z];
                        }
                    }
                    if (temp == "")
                    {
                        Console.WriteLine("Product group: 00");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: {temp}");
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
