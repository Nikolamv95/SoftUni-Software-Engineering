using System;

namespace vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            double currentMoney = double.Parse(Console.ReadLine());

            int spend5Times = 0;
            int numberOfDays = 0;
            double totalMoney = currentMoney;

            while (totalMoney < neededMoney)
            {
                string action = Console.ReadLine();
                double moneyAfterAction = double.Parse(Console.ReadLine());
                    
                numberOfDays += 1;
                //Харчим
                if (action == "spend")
                {

                    if (moneyAfterAction > totalMoney)
                    {
                        totalMoney = 0;
                    }
                    else
                    {
                        totalMoney -= moneyAfterAction;
                    }

                    spend5Times += 1;

                    if (spend5Times >= 5)
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine(numberOfDays);
                        Environment.Exit(0);
                    }
                }
                //Пестим
                else if (action == "save")
                {
                    spend5Times = 0; 
                    // spend5Times идва тук, защото в условието пише 5 последователни дни. Реално 5 дни трябва само да харчиш.
                    // Когато сложим тази променлива тук, ние рестартираме периода в случай на комбинация, харча, спестявам, харча.
                    totalMoney += moneyAfterAction;
                }
            }
            Console.WriteLine($"You saved the money for {numberOfDays} days.");
        }
    }
}
