using System;

namespace ReflectionDemoGetType
{
    class Program
    {
        static void Main(string[] args)
        {
            //We can take dynamiclly the type of object which we want
            string name = "ReflectionDemoGetType.Person";
            var getType = GetType(name);
            Console.WriteLine(getType.FullName);
            Console.WriteLine(getType.Name);
        }

        static Type GetType(string name)
        {
            var type = Type.GetType(name);
            return type;
        }
    }
}
