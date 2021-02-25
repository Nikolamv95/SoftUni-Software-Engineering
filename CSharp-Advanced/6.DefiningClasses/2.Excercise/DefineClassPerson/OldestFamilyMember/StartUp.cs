using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < rows; i++)
            {
                string[] data = Console.ReadLine().Split().ToArray();
                string name = data[0];
                int age = int.Parse(data[1]);
                Person member = new Person(name, age);
                family.AddMember(member);
            }

           var oldestMember = family.GetOldestMember();
           Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }
}