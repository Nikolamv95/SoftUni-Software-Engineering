using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Hometown { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<Student> listOfSudents = new List<Student>();

            while ((input = Console.ReadLine()) != "end")
            {
                string[] data = input
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();

                string firstName = data[0];
                string lastName = data[1];
                int age = int.Parse(data[2]);
                string homeTown = data[3];

                Student student = new Student();

                student.FirstName = firstName;
                student.LastName = lastName;
                student.Age = age;
                student.Hometown = homeTown;

                listOfSudents.Add(student);
            }

            string hometown = Console.ReadLine();

            foreach (var student in listOfSudents)
            {
                if (student.Hometown == hometown)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }
}
