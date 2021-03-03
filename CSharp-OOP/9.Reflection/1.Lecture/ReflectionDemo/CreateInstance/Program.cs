using System;
using System.Linq;
using System.Reflection;

namespace CreateInstance
{
    class Program
    {
        static void Main(string[] args)
        {
            //This is how we can create objects dynamiclly
            string name = "CreateInstance.Woman";
            Type getType = Type.GetType(name);
            //If we cast the object on this way (object)Activator.CreateInstance if there is no object with will throw an exception
            //Person transformType = (Person)Activator.CreateInstance(getType, "Maria");

            //If we do it on this way will and there is no right object will save null; This is the better choice
            Person transformType = Activator.CreateInstance(getType, "Maria") as Person;
            Console.WriteLine(transformType.Name);

            //This is how we create instance and create object 
            Type type = typeof(Man);
            var man = Activator.CreateInstance(type, "Stoqn");
            var result = type.GetProperty("Name").GetValue(man);
            Console.WriteLine(result);

            //Way hot to check all properties
            man.GetType().GetProperty("Name").SetValue(man, "Koce");
            Console.WriteLine(man.GetType().GetProperty("Name").GetValue(man));

            //How to use Assembly
            var assembly = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == "Man");
            var instance = Activator.CreateInstance(assembly, "Manol") as Person;
            Console.WriteLine(instance.Name);

        }

    }
}

