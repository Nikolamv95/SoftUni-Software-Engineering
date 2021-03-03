using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorPattern
{
    public interface IPaymentSystem
    {
        void PayMoney(string from, string to, int ammount);
        void LoanMoney(string from, string to, int ammount);
    }
}
