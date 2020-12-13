using System;

namespace CinemaVoucher
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Стойността на ваучера – цяло число в интервала[1…100000]
            //    След това до получаване на команда "End" или до изчерпването на ваучера, се чете по един ред:
            //     o Покупката, която Любо е избрал – текст

            double voucherValue = double.Parse(Console.ReadLine());
            string order;
            int sum = 0;
            int movies = 0;
            int products = 0;

            while ((order = Console.ReadLine()) != "End")
            {
                char [] letters = order.ToCharArray();

                //Movie
                if (letters.Length > 7)
                {
                    int num1 = letters[0];
                    int num2 = letters[1];
                    sum += num1 + num2;

                    if (sum <= voucherValue)
                    {  
                        movies += 1;
                    }
                    else
                    {
                        break;
                    }
                    
                }
                else if (order.Length <= 7)
                {
                    int num1 = letters[0];
                    sum += num1;

                    if (sum <= voucherValue)
                    {
                        products += 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            Console.WriteLine($"{movies}");
            Console.WriteLine($"{products}");
        }
    }
}
