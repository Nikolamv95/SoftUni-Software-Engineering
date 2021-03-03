using System;
using System.Collections.Generic;

namespace StudentSystem
{
    public class StudentData
    {
        public Dictionary<string, Student> Students { get; } = new Dictionary<string, Student>();


        public void Add(string name, int age, double grade)
        {
            if (this.Students.ContainsKey(name) == true)
            {
                return;
            }
            var student = new Student(name, age, grade);
            this.Students[name] = student;
        }

        public string GetStudent(string name)
        {
            if (this.Students.ContainsKey(name) == false)
            {
                return null;
            }

            var student = this.Students[name];

            return student.ToString();
        }
    }

}
