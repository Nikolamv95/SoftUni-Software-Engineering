using System;

namespace InterfacesExample
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //Най-често интерфейсите се използват за методи
             
            var company = new Company();
            company.Workers.Add(new Programmer());
            company.Workers.Add(new Boss());
            company.Workers.Add(new FactoryWorker());
            company.Workers.Add(new Programmer());

            while (true)
            {
                var input = Console.ReadLine();
                company.WorkeDay();

                if (input == "Salary")
                {
                    company.SalaryDay();
                }

            }
        }
    }
}
