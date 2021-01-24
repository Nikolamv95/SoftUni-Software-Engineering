using System;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%([A-Z][a-z]+)%[^|$%.]*<(\w+)>[^|$%.]*\|(\d+)\|[^|$%.]*?((\d+)|(\d+\.\d+))\$";
            //Създаваме обект braRegex от клас Regex и му придаваме патерна който сме написали
            Regex barRegex = new Regex(pattern);
            double totalSumOfOrders = 0;

            string input = Console.ReadLine();

            while (input != "end of shift")
            {
                //Извикваме метода match
                Match matchedInput = barRegex.Match(input);

                //Проверяваме дали матчването е успешно
                if (matchedInput.Success == true)
                {
                    string customerName = matchedInput.Groups[1].Value;
                    string product = matchedInput.Groups[2].Value;
                    double quantity = double.Parse(matchedInput.Groups[3].Value);
                    double price = double.Parse(matchedInput.Groups[4].Value);
                    double totalPrice = quantity * price;
                    Console.WriteLine($"{customerName}: {product} - {totalPrice:f2}");

                    totalSumOfOrders += totalPrice;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {totalSumOfOrders:f2}");
        }
    }
}
