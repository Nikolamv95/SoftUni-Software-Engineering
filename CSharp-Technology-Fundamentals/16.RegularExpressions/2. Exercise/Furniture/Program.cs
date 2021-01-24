using System;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>([a-zA-z]+)<<((\d+)|(\d+\.\d+))!(\d+)";
            Regex furnitureRegex = new Regex(pattern);
            double totalPrice = 0;

            string input = Console.ReadLine();

            Console.WriteLine("Bought furniture:");

            while (input != "Purchase")
            {
                Match matchedInput = furnitureRegex.Match(input);

                if (matchedInput.Success == true)
                {
                    string name = matchedInput.Groups[1].Value;
                    string price = matchedInput.Groups[2].Value;
                    string quantity = matchedInput.Groups[5].Value;
                    totalPrice += double.Parse(price) * double.Parse(quantity);
                    Console.WriteLine(name);
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
