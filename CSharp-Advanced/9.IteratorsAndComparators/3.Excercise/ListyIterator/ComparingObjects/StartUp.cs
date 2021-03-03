using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            List<Person> listPersons = new List<Person>();

            while ((command = Console.ReadLine()) != "END")
            {
                string[] data = command.Split().ToArray();
                string name = data[0];
                int age = int.Parse(data[1]);
                string town = data[2];

                Person currPerson = new Person(name, age, town);
                listPersons.Add(currPerson);
            }

            int n = int.Parse(Console.ReadLine());
            var personToCHeck = listPersons[n-1];
            int matched = 0;

            for (int i = 0; i < listPersons.Count; i++)
            {
                var person = listPersons[i];
                int result = person.CompareTo(personToCHeck);

                if (result == 0)
                {
                    matched++;
                }
            }

            if (matched > 1)
            {
                Console.WriteLine($"{matched} {listPersons.Count - matched} {listPersons.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
            
        }
    }
}
