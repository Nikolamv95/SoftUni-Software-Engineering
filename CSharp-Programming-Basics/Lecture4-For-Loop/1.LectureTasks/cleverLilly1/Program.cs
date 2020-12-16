using System;

namespace cleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int ageLili = int.Parse(Console.ReadLine());
            double laundryPrice = double.Parse(Console.ReadLine());
            double toyPricePer1 = double.Parse(Console.ReadLine());

            int toysCount = 0;
            double moneySaved = 0;
            int temp = 10;

            for (int i = 1; i <= ageLili; i++)
            {
                if (i % 2 == 0)
                {
                    moneySaved += temp;
                    temp += 10;
                }
                else
                {
                    toysCount += 1;
                }
            }

            double totalToysMoney = toyPricePer1 * toysCount;
            double totalMoneySaved = moneySaved - (ageLili / 2);
            double totalMoney = totalMoneySaved + totalToysMoney;
         
            double difference = 0;

            if (totalMoney >= laundryPrice)
            {
                difference = totalMoney - laundryPrice;
                Console.WriteLine($"Yes! {difference:f2}");
            }
            else
            {
                difference =laundryPrice - totalMoney;
                Console.WriteLine($"No! {difference:f2}");
            }
        }
    }
}
