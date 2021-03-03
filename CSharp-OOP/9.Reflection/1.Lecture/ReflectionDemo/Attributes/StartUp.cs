using System;
using System.Reflection;

namespace Attributes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var item in assembly)
            {
                var attributes = item.GetCustomAttributes(typeof(AuthorAttribute));

                foreach (var attr in attributes)
                {
                    Console.WriteLine(((AuthorAttribute)attr).Name);
                }
            }
        }
    }
}
