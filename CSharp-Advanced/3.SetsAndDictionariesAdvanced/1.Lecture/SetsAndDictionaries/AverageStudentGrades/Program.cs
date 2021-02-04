using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfStudents = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> dicOfStudents = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < numOfStudents; i++)
            {
                string[] data = Console.ReadLine().Split().ToArray();
                string name = data[0];
                decimal grade = decimal.Parse(data[1]);
                List<decimal> grades = new List<decimal>();

                if (dicOfStudents.ContainsKey(name) == false)
                {
                    grades.Add(grade);
                    dicOfStudents.Add(name, grades);
                }
                else
                {
                    dicOfStudents[name].Add(grade);
                }
            }

            foreach (var item in dicOfStudents)
            {
                decimal avGrade = item.Value.Average();
                Console.WriteLine($"{item.Key} -> {string.Join(' ', item.Value.Select(x => x.ToString("F2")))} (avg: {avGrade:f2})");
            }
        }
    }
}
