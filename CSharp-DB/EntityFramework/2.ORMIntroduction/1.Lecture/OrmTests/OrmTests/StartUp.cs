using OrmTests.Models;
using System;
using System.Linq;

namespace OrmTests
{
    //DB First Model - create DB in db server and transfer it to C#
    class StartUp
    {
        static void Main(string[] args)
        {
            var dbContext = new SoftUniLec2Context();

            //Example 1            
            Console.WriteLine("Example 1 ----------------------");
            Console.WriteLine();
            var employees = dbContext.Employees.Where(x => x.Department.Manager.Department.Name == "Sales")
                                .Select(x => new
                                {
                                    Name = x.FirstName + ' ' + x.LastName,
                                    DepartmentName = x.Department.Name,
                                    Manager = x.Manager.FirstName + ' ' + x.Manager.LastName
                                });

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Name} => {employee.DepartmentName} => {employee.Manager}");
            }


            //Example 2
            Console.WriteLine();
            Console.WriteLine("Example 2 ----------------------");
            Console.WriteLine();
            var employeesGroups = dbContext.Employees
                .GroupBy(x=> new { x.Department.Name})
                .Select(x=> new 
                { 
                    DepartmentName = x.Key.Name,
                    CountEmployees = x.Count()
                });

            foreach (var employeesGroup in employeesGroups)
            {
                Console.WriteLine($"{employeesGroup.DepartmentName} => {employeesGroup.CountEmployees}");
            }

            //Example 3
            Console.WriteLine();
            Console.WriteLine("Example 3 ----------------------");
            Console.WriteLine();
            var employeesNewGroups = dbContext.Employees
                .GroupBy(x => new { x.Department.Name})
                .Select(x => new
                {
                    DepartmentName = x.Key.Name,
                    Salaries = x.Sum(e=> e.Salary)
                });

            foreach (var employeesNewGroup in employeesNewGroups)
            {
                Console.WriteLine($"{employeesNewGroup.DepartmentName} => {employeesNewGroup.Salaries}");
            }

            //Example 4
            Console.WriteLine();
            Console.WriteLine("Example 4 ----------------------");
            Console.WriteLine();
            var employeesSalaryGroup = dbContext.Employees
                .GroupBy(x => new { x.Department.Name })
                .Where(x=> x.Count() > 10)
                .Select(x => new
                {
                    DepartmentName = x.Key.Name,
                    Salaries = x.Sum(e => e.Salary)
                }).ToList().Where(x=> x.Salaries > 10000);

            foreach (var employeesSalaryGr in employeesSalaryGroup)
            {
                Console.WriteLine($"{employeesSalaryGr.DepartmentName} => {employeesSalaryGr.Salaries}");
            }
        }
    }
}
