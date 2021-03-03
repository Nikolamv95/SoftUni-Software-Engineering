using System;
using System.Reflection;

namespace ReflectFields
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = typeof(Person);
            Console.WriteLine(type.GetProperty("Name").Name);
            Console.WriteLine(type.GetField("name", BindingFlags.NonPublic | BindingFlags.Instance).Name);
        }
    }
}
