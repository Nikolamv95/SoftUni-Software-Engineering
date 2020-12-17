using System;

namespace DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //otput
            double deposit = double.Parse(Console.ReadLine());
            int period = int.Parse(Console.ReadLine());
            double interest = double.Parse(Console.ReadLine());
            //calculations
            double addedInterest = (deposit * interest) / 100;
            double oneMonthInterest = addedInterest / 12;
            double finalDeposit = deposit + (period * oneMonthInterest);
            //output
            Console.WriteLine($"{finalDeposit:f2}") ;
            // ($"{Променлива сума:f2}") - по този начин закрългяме числото до 
            // 2 цифри след запетаята пример 5.78888 = 5.79
            
        }
    }
}
