using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            this.StudentCourses = new HashSet<StudentCourse>();
            this.HomeworkSubmissions = new HashSet<HomeworkSubmission>();
        }

        public int StudentId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime? BirthDay { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<HomeworkSubmission> HomeworkSubmissions { get; set; }
    }
}
