using System;

namespace TradeCommissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());
            ;
            switch (city)
            {
                case "Sofia":
                    if (sales <= 500)
                    {

                    }
                    else if (sales <= 1000)
                    {

                    }
                    else if (sales <= 10000)
                    {

                    }
                    else if (sales > 10000)
                    {

                    }
                    break;
            }
        }
    }
}
