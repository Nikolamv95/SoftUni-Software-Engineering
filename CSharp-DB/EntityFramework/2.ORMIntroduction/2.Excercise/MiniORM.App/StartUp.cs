using MiniORM.App.Data.Entities;
using System.Linq;

namespace MiniORM.App
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var connectionString = @"Server=DESKTOP-0J5UCH7\SQLEXPRESS;Database=MiniORM;Integrated Security=true";

			var context = new SoftUniDbContext(connectionString);

            //context.Employees.Add(new Employee
            //{
            //    FirstName = "Nikola",
            //    LastName = "Inserted",
            //    DepartmentId = context.Departments.First().Id,
            //    IsEmployed = true,
            //});

            var employee = context.Employees.Last();
            //employee.FirstName = "Modified";
            //employee.IsEmployed = false;
            context.Employees.Remove(employee);

            context.SaveChanges();
        }
    }
}
