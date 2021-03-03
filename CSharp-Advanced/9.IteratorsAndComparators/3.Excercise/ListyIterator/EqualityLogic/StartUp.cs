using System;
using System.Collections.Generic;
using System.Linq;

namespace EqualityLogic
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SortedSet<Person> setPerson = new SortedSet<Person>();
            HashSet<Person> hashPerson = new HashSet<Person>();

            int rows = int.Parse(Console.ReadLine());

            for (int i = 0; i < rows; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = data[0];
                int age = int.Parse(data[1]);

                Person currPerson = new Person(name, age);
                setPerson.Add(currPerson);
                hashPerson.Add(currPerson);
            }

            Console.WriteLine(setPerson.Count);
            Console.WriteLine(hashPerson.Count);

        }
    }
}
