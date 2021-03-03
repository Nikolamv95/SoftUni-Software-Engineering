using OrmTestsStudents.Models;
using System;
using System.Linq;

namespace OrmTestsStudents
{
    //Code First Model - create DB in c# and transfer it to db server
    class StartUp
    {
        static void Main(string[] args)
        {
            //Example 1            
            Console.WriteLine("Example 1 ----------------------");
            Console.WriteLine();
            var dbContext = new StudentsDbContext();

            dbContext.Courses.RemoveRange(dbContext.Courses.Where(c => c.Name == "Entity Framework Core"));
            dbContext.SaveChanges();




            //dbContext.Database.EnsureCreated();
            //dbContext.Courses.Add(new Course { Name = "Entity Framework Core" });

            //var course = dbContext.Courses.FirstOrDefault(x => x.Id == 1);
            //Console.WriteLine(course.Name);

            ////Example 2 - Create       
            //Console.WriteLine("Example 2 ----------------------");
            //Console.WriteLine();

            ////We take the students with average values over 4.50
            //dbContext.Students.Where(x => x.Grades.Average(g => g.Value) > 4.50m);

            ////Add new student
            //dbContext.Students.Add(new Student { FirstName = "Vasko", LastName = "Parev"  });
            //Console.WriteLine("New student added");

            ////Example 3 - Create          
            //Console.WriteLine("Example 2 ----------------------");
            //Console.WriteLine();

            ////Add new grade
            //dbContext.Grades.Add(new Grade
            //{
            //    Student = new Student { FirstName = "Vasko", LastName = "Vasilev" },
            //    Course = new Course { Name = "DB Sql" },
            //    Value = 4.50M
            //});
            //Console.WriteLine("New grade added");
            //dbContext.SaveChanges();

            ////Example 4 - Update          
            //Console.WriteLine("Example 4 ----------------------");
            //Console.WriteLine();

            //var grade = dbContext.Grades.FirstOrDefault(x => x.Student.FirstName == "Vasko");
            //grade.Value = 2;
            //Console.WriteLine("Vasko grade changed");
            //dbContext.SaveChanges();

            ////Example 5 - Remove     
            //Console.WriteLine("Example 4 ----------------------");
            //Console.WriteLine();

            //var students = dbContext.Students.FirstOrDefault(x=>x.FirstName == "Nikolay");
            //dbContext.Students.Remove(students);
            //Console.WriteLine("Delete Nikolay");
            //dbContext.SaveChanges();
        }
    }
}
