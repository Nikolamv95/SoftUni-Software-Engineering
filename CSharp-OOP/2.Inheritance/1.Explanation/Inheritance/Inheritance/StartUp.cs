using System;

namespace Inheritance
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //Основен клас Person - той е основен клас и може да използва само собствените си пропъртита и методи
            //НЕ НАСЛЕДЯВА ДРУГИ КЛАСОЕ ЗАЩОТО Е BASE CLASS
            //За да са достъпни пропъртитата трябва да са public
            var person = new Person();
            person.Name = "Pesho";
            person.Age = 19;
            Console.WriteLine("-------------");

            //Worker : Person и приема пропъртитата му Age, Name и методите Sleep(), Eat();
            var worker = new Worker();
            worker.Name = "Pesho";
            worker.Age = 18;
            worker.Company = "PeshoOOD";

            Console.WriteLine(worker.Name);
            Console.WriteLine(worker.Age);
            Console.WriteLine(worker.Company);
            Console.WriteLine(worker.IsLazy);
            worker.Sleep();
            worker.Eat();
            Console.WriteLine("-------------");

            //Student : Person и приема пропъртитата му Age, Name и методите Sleep(), Eat();
            var student = new Student();
            student.Name = "Stoiko";
            student.Age = 24;
            Console.WriteLine(student.Name);
            Console.WriteLine(student.Age);
            Console.WriteLine(student.IsBad);
            student.Sleep();
            student.Eat();
            Console.WriteLine("-------------");

            //FactoryWork : Worker и приема пропъртитата му Compay, IsLazy и приема пропъртитата на Person - Age, Name и методите Sleep(), Eat();
            var factoryWorker = new FactoryWorker();
            factoryWorker.Name = "Stoiko";
            factoryWorker.Age = 24;
            Console.WriteLine(factoryWorker.Name);
            Console.WriteLine(factoryWorker.Age);
            Console.WriteLine(factoryWorker.IsLazy);
            factoryWorker.Sleep();
            factoryWorker.Eat();
            factoryWorker.LeaveFactory();
            

        }
    }
}
