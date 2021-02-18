using System;

namespace StaticClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            BankHelper.Name = "Pesho Bank OOD";
            //Това е статичен клас в който можем да си правим методи(калкулации) и после да ги 
            //използваме по подобир на Math.Round, Math.Max и т.н;
            BankHelper.CalculateDebt(55.21);
            double math = Math.Round(54.2);
            Console.WriteLine(BankHelper.Name);



            Account account = new Account();
            account.Balance = 100;
            account.PayTax();
            Account account2 = new Account();
            Account.Tax = 500;
            account.PayTax();
        }
    }
}
