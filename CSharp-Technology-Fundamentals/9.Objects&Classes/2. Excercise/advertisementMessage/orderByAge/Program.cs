using System;
using System.Collections.Generic;
using System.Linq;

namespace orderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Student> listOfStudents = new List<Student>();

            while (input != "End")
            {
                string[] data = input
                               .Split(" ")
                               .ToArray();

                Student student = new Student(data[0], data[1], int.Parse(data[2]));
                listOfStudents.Add(student);
                input = Console.ReadLine();
            }

            listOfStudents = listOfStudents.OrderBy(x => x.Age).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, listOfStudents));
        }
    }
}
