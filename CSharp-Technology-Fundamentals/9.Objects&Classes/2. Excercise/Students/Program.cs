using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int numStudents = int.Parse(Console.ReadLine());

            List<Student> listOfStudents = new List<Student>();

            for (int i = 0; i < numStudents; i++)
            {

                string[] input = Console.ReadLine()
                             .Split(" ");

                string firstName = input[0];
                string lastName = input[1];
                double grade = double.Parse(input[2]);

                Student student = new Student();

                student.FirstNames = firstName;
                student.LastNames = lastName;
                student.Grade = grade;

                listOfStudents.Add(student);
            }

            listOfStudents = listOfStudents.OrderBy(x => x.Grade).ToList();
            listOfStudents.Reverse();

            Console.WriteLine(string.Join(Environment.NewLine, listOfStudents));

        }

        class Student
        {
            public string FirstNames { get; set; }
            public string LastNames { get; set; }
            public double Grade { get; set; }

            public override string ToString()
            {
                return $"{FirstNames} {LastNames}: {Grade:f2}";
            }
        }
    }
}
