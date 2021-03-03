using System;

namespace ReflectionGetMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var personMethods = typeof(Person).GetMethod("GetName");
            var personInstance = Activator.CreateInstance(typeof(Person), "Marinkata");
            var result = personMethods.Invoke(personInstance, new object[] { });

            Console.WriteLine(result);


            //foreach (var item in personMethods)
            //{
            //    Console.WriteLine(item.Name);
            //}
        }
    }
}
