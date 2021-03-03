using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesExample
{
    class Company
    {
        public List<IManager> Workers { get; set; }

        public Company()
        {
            this.Workers = new List<IManager>();
        }

        public void WorkeDay()
        {
            Workers.ForEach((worker) =>
            {
                if (worker is Programmer)//По този начин ако Worker е програмист  можем да извършваме действия с програмиста в скобите. Не се препоръчва
                {
                    Console.WriteLine("Programmer on our way");
                }
                worker.Work();
            });
        }

        public void SalaryDay()
        {
            Workers.ForEach((worker) =>
            {
                worker.GetSalary();
            });
        }
    }
}
