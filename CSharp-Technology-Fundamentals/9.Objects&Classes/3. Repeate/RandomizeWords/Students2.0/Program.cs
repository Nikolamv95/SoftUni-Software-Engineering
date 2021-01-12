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
            List<Student> listOfStudents = new List<Student>();

            while ((input = Console.ReadLine()) != "end")
            {
                string[] data = input
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();

                string firstName = data[0];
                string lastName = data[1];
                int age = int.Parse(data[2]);
                string homeTown = data[3];

                if (isStudentExisting(firstName, lastName, listOfStudents))
                {
                    int getIndex = GetIndexStudent(firstName, lastName, listOfStudents);

                    listOfStudents.RemoveAt(getIndex);

                    Student student = new Student();

                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.Hometown = homeTown;

                    listOfStudents.Add(student);
                }
                else
                {
                    Student student = new Student();

                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.Hometown = homeTown;

                    listOfStudents.Add(student);
                }             
            }

            string hometown = Console.ReadLine();

            foreach (var student in listOfStudents)
            {
                if (student.Hometown == hometown)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }

        private static int GetIndexStudent(string firstName, string lastName, List<Student> listOfSudents)
        {
            int counter = 0;

            foreach (var student in listOfSudents)
            {               
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    break;
                }

                counter += 1;
            }

            return counter;
        }

        private static bool IsStudentExisting(string firstName, string lastName, List<Student> listOfSudents)
        {
            foreach (var student in listOfSudents)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
