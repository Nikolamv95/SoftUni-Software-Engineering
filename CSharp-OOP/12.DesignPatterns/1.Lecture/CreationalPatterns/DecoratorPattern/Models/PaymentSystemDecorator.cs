using System;

namespace DecoratorPattern
{
    public class PaymentSystemDecorator : IPaymentSystem
    {
        private IPaymentSystem paymentSystem;

        public PaymentSystemDecorator(IPaymentSystem system)
        {
            this.paymentSystem = system;
        }

        public void LoanMoney(string from, string to, int ammount)
        {
            Console.WriteLine("We can make whatever we want in this LoanMoney Method");
            paymentSystem.LoanMoney(from, to, ammount);
        }

        public void PayMoney(string from, string to, int ammount)
        {
            Console.WriteLine("We can make whatever we want in this PaidMoney Method");
            paymentSystem.PayMoney(from, to, ammount);
        }
    }
}
