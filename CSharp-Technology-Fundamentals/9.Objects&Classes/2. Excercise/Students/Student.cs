using System;
using System.Collections.Generic;
using System.Text;

namespace Students
{
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
