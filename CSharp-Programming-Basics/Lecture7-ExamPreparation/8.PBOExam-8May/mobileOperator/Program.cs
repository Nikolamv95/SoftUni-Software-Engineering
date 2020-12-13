using System;

namespace mobileOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            string contractTime = Console.ReadLine();
            string contractType = Console.ReadLine();
            string mobileInternet = Console.ReadLine();
            int contractPayment = int.Parse(Console.ReadLine());

            double contractPrice = 0;

            switch (contractTime)
            {
                case "one":
                    if (contractType == "Small")
                    {
                        contractPrice = 9.98;
                    }
                    else if (contractType == "Middle")
                    {
                        contractPrice = 18.99;
                    }
                    else if (contractType == "Large")
                    {
                        contractPrice = 25.98;
                    }
                    else if (contractType == "ExtraLarge")
                    {
                        contractPrice = 35.99;
                    }
                    break;

                case "two":
                    if (contractType == "Small")
                    {
                        contractPrice = 8.58;
                    }
                    else if (contractType == "Middle")
                    {
                        contractPrice = 17.09;
                    }
                    else if (contractType == "Large")
                    {
                        contractPrice = 23.59;
                    }
                    else if (contractType == "ExtraLarge")
                    {
                        contractPrice = 31.79;
                    }
                    break;
            }

            if (mobileInternet == "yes")
            {
                switch (contractTime)
                {
                    case "one":
                        if (contractPrice <= 10)
                        {
                            contractPrice = contractPrice + 5.50;
                        }
                        else if (contractPrice <= 30)
                        {
                            contractPrice = contractPrice + 4.35;
                        }
                        else if (contractPrice > 30.01)
                        {
                            contractPrice = contractPrice + 3.85;
                        }
                        break;

                    case "two":
                        if (contractPrice <= 10)
                        {
                            contractPrice = contractPrice + 5.50;
                        }
                        else if (contractPrice <= 30)
                        {
                            contractPrice = contractPrice + 4.35;
                        }
                        else if (contractPrice > 30.01)
                        {
                            contractPrice = contractPrice + 3.85;
                        }

                        contractPrice *= 0.9625;

                        break;
                }
            }
            else if (mobileInternet == "no" && contractTime == "two")
            {
                contractPrice *= 0.9625;
            }

            contractPrice = contractPrice * contractPayment;

            Console.WriteLine($"{contractPrice:f2} lv.");
        }
    }
}
