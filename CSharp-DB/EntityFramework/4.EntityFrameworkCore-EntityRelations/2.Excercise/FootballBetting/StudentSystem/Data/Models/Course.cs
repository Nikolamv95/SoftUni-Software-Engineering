using System;
using System.Collections.Generic;

namespace StudentSystem.Data.Models
{
    public class Course
    {

        public Course()
        {
            this.Recources = new HashSet<Resource>();
            this.StudentCourses = new HashSet<StudentCourse>();
            this.HomeworkSubmissions = new HashSet<HomeworkSubmission>();
        }

        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
        
        public ICollection<Resource> Recources{ get; set; }
        public ICollection<HomeworkSubmission> HomeworkSubmissions{ get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
