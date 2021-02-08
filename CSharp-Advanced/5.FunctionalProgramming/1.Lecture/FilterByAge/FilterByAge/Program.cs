using System;
using System.Linq;

namespace FilterByAge
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            Person[] people = new Person[rows];

            for (int i = 0; i < rows; i++)
            {
                var inputArray = Console.ReadLine().Split(", ").ToArray();
                
                people[i] = new Person()
                {
                    Name = inputArray[0],
                    Age = int.Parse(inputArray[1])
                };
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> ageChecker = VerifyAgePerson(condition, age, people);
            Action<Person> filterData = PrintData(format);

            PrintMatchedConditions(people, ageChecker, filterData);
            //-----------------------------------
            Console.WriteLine("--------------");
            PrintMatchedConditions(people, p=> p.Name.Length > 3, filterData);
            Console.WriteLine("--------------");
            PrintMatchedConditions(people, p => p.Name.Length > 3, p => Console.WriteLine($"{p.Name} {p.Age}!!!"));
            Console.WriteLine("--------------");
            PrintMatchedConditions(people, FilterOldPeople, filterData); //Сам си създавам функция
            //-----------------------------------

        }

        static bool FilterOldPeople(Person people)
        {
            return people.Age > 30;
        }

        private static void PrintMatchedConditions(Person[] people, Func<Person, bool> ageChecker, Action<Person> filterData)
        {
            foreach (var person in people)
            {
                if (ageChecker(person))
                {
                    filterData(person);
                }
            }
        }

        static Action<Person> PrintData(string format)
        {
            switch (format)
            {
                case "name":
                    return p =>
                    { 
                        Console.WriteLine($"{p.Name}");
                    };
                case "age":
                    return p =>
                    {
                        Console.WriteLine($"{p.Age}");
                    };
                case "name age":
                    return p =>
                    {
                        Console.WriteLine($"{p.Name} - {p.Age}");
                    };
                default:
                    return null;
            }
        }

        static Func<Person, bool> VerifyAgePerson(string condition, int age, Person[] people)
        {
            switch (condition)
            {
                case "younger": return p => p.Age < age;
                case "older": return p => p.Age >= age;
                default: return null;
            }
        }
    }
}
