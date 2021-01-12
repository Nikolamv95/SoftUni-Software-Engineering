using System;

namespace orderByAge
{
    class Student
    {
        public Student(string name, string id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }

        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} with ID: {Id} is {Age} years old.");

            return sb.ToString().TrimEnd();
        }
    }
}
