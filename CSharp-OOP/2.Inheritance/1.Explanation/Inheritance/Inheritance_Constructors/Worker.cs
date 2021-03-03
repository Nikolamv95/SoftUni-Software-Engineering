using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    class Worker : Person
    {
        //Празен конструктрор
        public Worker()
        {

        }

        //Конструктор в който подаваме име на компанията
        public Worker(string company)
        {
            this.Company = company;
        }

        public Worker(string name, int age, string company)
        {
            this.Name = name;
            this.Age = age;
            this.Company = company;
        }

        public string Company { get; set; }
        public bool IsLazy { get { return true; } }
    }
}
