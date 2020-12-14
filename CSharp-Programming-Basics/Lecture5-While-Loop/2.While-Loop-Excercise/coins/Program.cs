using System;

namespace coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double inputMoney = double.Parse(Console.ReadLine());

            inputMoney *= 100;
            inputMoney = Convert.ToInt32(inputMoney);

            int coinsCount = 0;

            while (inputMoney > 0)
            {

                if (inputMoney >= 200)
                {
                    inputMoney -= 200;
                    coinsCount += 1;
                    continue;
                }
                else if (inputMoney >= 100)
                {
                    inputMoney -= 100;
                    coinsCount += 1;
                    continue;
                }
                else if (inputMoney >= 50)
                {
                    inputMoney -= 50;
                    coinsCount += 1;
                    continue;
                }
                else if (inputMoney >= 20)
                {
                    inputMoney -= 20;
                    coinsCount += 1;
                    continue;
                }
                else if (inputMoney >= 10)
                {
                    inputMoney -= 10;
                    coinsCount += 1;
                    continue;
                }
                else if (inputMoney >= 5)
                {
                    inputMoney -= 5;
                    coinsCount += 1;
                    continue;
                }
                else if (inputMoney >= 2)
                {
                    inputMoney -= 2;
                    coinsCount += 1;
                    continue;
                }
                else if (inputMoney >= 1)
                {
                    inputMoney -= 1;
                    coinsCount += 1;
                    continue;
                }
            }

            Console.WriteLine(coinsCount);
        }
    }
}
