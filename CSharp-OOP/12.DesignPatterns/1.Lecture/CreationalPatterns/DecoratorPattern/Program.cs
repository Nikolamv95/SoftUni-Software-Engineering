using System;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IPaymentSystem payment = new PaymentSystemDecorator(new PayPalSystem());
            payment.LoanMoney("Marin", "Penka", 21);
            payment.LoanMoney("Ivan", "Stoine", 31);
            payment.PayMoney("Toni", "Tinche", 222);
        }
    }
}
