using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsExcercise
{
    class Student
    {
        public Student(string firstName, string lastName, double grade) 
        {
            FirstName = firstName;
            SecondName = lastName;
            Grade = grade;
        }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {SecondName}: {Grade:f2}";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int numberStudents = int.Parse(Console.ReadLine());

            List<Student> listOfStudents = new List<Student>();

            for (int i = 0; i < numberStudents; i++)
            {
                string[] data = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();

                string firstName = data[0];
                string lastName = data[1];
                double grade = double.Parse(data[2]);

                Student student = new Student(firstName, lastName, grade);

                listOfStudents.Add(student);
            }


            var filteredList = listOfStudents.OrderByDescending(g => g.Grade).ToList();

            foreach (var item in filteredList)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
