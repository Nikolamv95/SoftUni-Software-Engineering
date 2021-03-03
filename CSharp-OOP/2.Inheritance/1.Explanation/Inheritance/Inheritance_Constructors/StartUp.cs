using System;

namespace Inheritance
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //В момента в инстанцията на new FactoryWorker() не сме подали никакви данни.
            //Тъй като Person има празен конструктор, Worker също, FactoryWorker също - програмата ще премините от 
            //празния конструктор на Person(), след това на Worker() и накрая FactoryWorker()
            FactoryWorker factoryWorker = new FactoryWorker();
            Console.WriteLine(factoryWorker.Company);//Няма да изпише нищо

            //В момента в инстанцията на new FactoryWorker() сме подалли данни само за Company "CurrCompany"
            //Tъй като Person има празен конструктор програмата започва от него, след това минава на конструктора на Worker(company)
            //и накрая приключва в конструктора на FactoryWorker(string comapy) : base(company)
            //В конструктора на FactoryWorker не е нуждно да записвваме нищо защото данните вече са се записали
            FactoryWorker factoryWorker2 = new FactoryWorker("CurrCompany");
            Console.WriteLine(factoryWorker2.Company);//Ще изпише CurrCompany


            //В момента в инстанцията на new FactoryWorker() сме подалли данни за Name, Age, Company
            //Tъй като Person празен конструктор с (Name, Age) програмата започва от него, след това минава на конструктора на Worker(company)
            //и накрая приключва в конструктора на FactoryWorker(name, compay, age) : base(name, compay, age)
            //В конструктора на FactoryWorker не е нуждно да записвваме нищо защото данните вече са се записали
            FactoryWorker factoryWorker3 = new FactoryWorker("Georgi", 18, "Gecata OOD");
            Console.WriteLine($"{factoryWorker3.Name}, {factoryWorker3.Age}, {factoryWorker3.Company}");//Ще изпише - Georgi, 18, Gecata OOD



        }
    }
}
