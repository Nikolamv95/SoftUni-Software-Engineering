using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrmTestsStudents.Models
{
    //This class combine the tables which we want to create into our database server
    public class StudentsDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-0J5UCH7\SQLEXPRESS;Database=NewSchoolDb;Integrated Security=true");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
