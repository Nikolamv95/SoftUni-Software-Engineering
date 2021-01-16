using System;
using System.Collections.Generic;
using System.Linq;

namespace courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> listOfCourses = new Dictionary<string, List<string>>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] data = command
                                 .Split(" : ");

                string lesson = data[0];
                string student = data[1];

                if (listOfCourses.ContainsKey(lesson) == false)
                {
                    List<string> students = new List<string> { student };
                    listOfCourses.Add(lesson, students);
                }
                else
                {
                    listOfCourses[lesson].Add(student);
                }
            }
            ;
            foreach (var item in listOfCourses.OrderByDescending(v => v.Value.Count))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");

                foreach (var name in item.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"--{name}");
                }
            }
        }
    }
}
