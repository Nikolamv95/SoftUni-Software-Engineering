using System;
using System.Collections.Generic;
using System.Linq;

namespace studentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            for (int i = 0; i < lines; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (students.ContainsKey(name) == false)
                {
                    List<double> grades = new List<double> { grade };
                    students.Add(name, grades);
                }
                else
                {
                    students[name].Add(grade);
                }
            }

            Dictionary<string, double> filteredStudents = new Dictionary<string, double>();

            foreach (var item in students)
            {
                double averageGrade = item.Value.Average();

                if (averageGrade >= 4.50)
                {
                    filteredStudents.Add(item.Key, averageGrade);
                }
            }

            foreach (var item in filteredStudents.OrderByDescending(v=> v.Value))
            {
                Console.WriteLine($"{item.Key} –> {item.Value:f2}");
            }
        }
    }
}
