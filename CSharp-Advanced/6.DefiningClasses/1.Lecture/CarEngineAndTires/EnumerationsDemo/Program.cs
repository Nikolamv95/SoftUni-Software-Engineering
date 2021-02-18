using System;

namespace EnumerationsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Payment payment = Payment.Bank;
            Console.WriteLine(payment);
            DoPayment(Payment.Cash);
            Console.WriteLine((int)Payment.Cash);
            Console.WriteLine($"{(Payment)4}");
        }

        static void DoPayment(Payment type)
        {
            if (type == Payment.Cash )
            {
                Console.WriteLine("TOP");
            }
            if (type == Payment.GoToCanada)
            {
                Console.WriteLine("GoTOCanada is bad");
            }
            else
            {
                Console.WriteLine("BestOption");
            }
        
        }
    }
}
