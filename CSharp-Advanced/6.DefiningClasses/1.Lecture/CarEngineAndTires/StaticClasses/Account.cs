using System;
using System.Collections.Generic;
using System.Text;

namespace StaticClasses
{
    class Account
    {
        public static decimal Tax { get; set; }
        public string Owner { get; set; }
        public decimal Balance { get; set; }

        public void PayTax()
        {
            //по този начин извикваме стойността на Tax, защото тя е статична и не се променя
            //Може само да се чете. Account е името на класа, Tax е името на статичното пропърти
            this.Balance -= Account.Tax;
        }

        public static string GetBankName()
        {
            return "PeshoBankOOD";
        }
    }
}
