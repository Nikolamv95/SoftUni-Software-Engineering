using System;
using System.Collections.Generic;
using System.Linq;

namespace students
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Student> listOfStudent = new List<Student>();
            
            while (input != "end")
            {
                string[] inputData = input
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);


                string firsName = inputData[0];
                string lastName = inputData[1];
                string age = inputData[2];
                string homeTown = inputData[3];

                Student student = new Student();

                student.FirstName = firsName;
                student.LasttName = lastName;
                student.Age = age;
                student.Hometown = homeTown;

                listOfStudent.Add(student);

                input = Console.ReadLine();
            }

            string cityCheck = Console.ReadLine();

            List <Student> filteredStudents = listOfStudent.Where(s => s.Hometown == cityCheck).ToList();

            foreach (Student print in filteredStudents)
            {
                Console.WriteLine($"{print.FirstName} {print.LasttName} is {print.Age} years old.");
            }
        }
    }
}
