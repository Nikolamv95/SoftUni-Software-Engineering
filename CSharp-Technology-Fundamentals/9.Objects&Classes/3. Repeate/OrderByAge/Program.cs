using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderByAge
{
    class Student
    {
        public Student(string name, string idNum, int yearsOld)
        {
            Name = name;
            IdNum = idNum;
            YearsOld = yearsOld;
        }

        public string Name { get; set; }
        public string IdNum { get; set; }
        public int YearsOld{ get; set; }

        public override string ToString()
        {
           return $"{Name} with ID: {IdNum} is {YearsOld} years old.";
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            List<Student> listOfStudents = new List<Student>();

            while ((command = Console.ReadLine()) != "End" )
            {
                var data = command
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();

                string name = data[0];
                string idNum = data[1];
                int age = int.Parse(data[2]);

                Student student = new Student(name, idNum, age);
                listOfStudents.Add(student);
            }

            var filteredLIst = listOfStudents.OrderBy(x => x.YearsOld);

            foreach (var item in filteredLIst)
            {
                Console.WriteLine(item.ToString());
            }

        }
    }
}
