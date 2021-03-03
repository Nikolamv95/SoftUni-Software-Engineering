using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();

            //Console.WriteLine(GetEmployeesFullInformation(context));
            //Console.WriteLine(GetEmployeesWithSalaryOver50000(context));
            //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));
            //Console.WriteLine(AddNewAddressToEmployee(context));
            //Console.WriteLine(GetEmployeesInPeriod(context));
            //Console.WriteLine(GetAddressesByTown(context));
            //Console.WriteLine(GetEmployee147(context));
            //Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));
            //Console.WriteLine(IncreaseSalaries(context));
            //Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));
            //Console.WriteLine(DeleteProjectById(context));
        }

        //Excercise 3
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees.Select(x => new
            {
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                JobTitle = x.JobTitle,
                Salary = x.Salary
            }).ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }

            return sb.ToString();
        }

        //Excercise 4
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees.Select(x => new
            {
                FirstName = x.FirstName,
                Salary = x.Salary
            }).Where(x => x.Salary > 50000).ToList();

            foreach (var e in employees.OrderBy(x => x.FirstName))
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }


            return sb.ToString();

        }

        //Excercise 5
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees.Select(x => new
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                DepartmentName = x.Department.Name,
                Salary = x.Salary
            })
                .Where(x => x.DepartmentName == "Research and Development")
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .ToList();


            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - {e.Salary:f2}");
            }

            return sb.ToString();

        }

        //Excercise 6
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Address newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            Employee employeeNakov = context.Employees
                                          .First(x => x.LastName == "Nakov");

            context.Addresses.Add(newAddress); //Can be skipped. EF will add the new address
            employeeNakov.Address = newAddress;//<-- here 

            context.SaveChanges();

            List<string> employeesTop10 = context.Employees
                                        .OrderByDescending(x => x.AddressId)
                                        .Take(10)
                                        .Select(e => e.Address.AddressText)
                                        .ToList();

            foreach (var e in employeesTop10)
            {
                sb.AppendLine(e);
            }

            return sb.ToString();
        }

        //Excercise 7
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeesWithProject = context.Employees
                .Where(x => x.EmployeesProjects
                    .Any(x => x.Project.StartDate.Year >= 2001
                           && x.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ManagerFName = x.Manager.FirstName,
                    ManagerLName = x.Manager.LastName,
                    Projects = x.EmployeesProjects.Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        ProjectStartDate = ep.Project.StartDate
                                             .ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        ProjectEndDate = ep.Project.EndDate.HasValue
                                ? ep.Project.EndDate.Value
                                  .ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                                : "not finished"
                    })
                }).ToList();


            foreach (var e in employeesWithProject)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFName} {e.ManagerLName}");

                foreach (var ep in e.Projects)
                {
                    sb.AppendLine($"--{ep.ProjectName} - {ep.ProjectStartDate} - {ep.ProjectEndDate}");
                }
            }

            return sb.ToString();
        }

        //Excercise 8
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context.Employees
                .GroupBy(x => new { x.Address.AddressText, x.Address.Town.Name })
                .Select(x => new
                {
                    AddressText = x.Key.AddressText,
                    TownName = x.Key.Name,
                    Count = x.Count()
                })
                .OrderByDescending(x => x.Count)
                .Take(10)
                .ToList();

            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.Count}");
            }

            return sb.ToString();
        }

        //Excercise 9
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employee147 = context.Employees
                .Where(x => x.EmployeeId == 147)
                .Select(x => new
                {
                    EmployeeId = x.EmployeeId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    JobTitle = x.JobTitle,
                    ProjectsName = x.EmployeesProjects
                        .Select(pn => new { pn.Project.Name })
                        .OrderBy(x => x.Name).ToList()
                }).Single();


            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            foreach (var pn in employee147.ProjectsName)
            {
                sb.AppendLine($"{pn.Name}");
            }

            return sb.ToString();
        }

        //Excercise 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departments5orMoreEmp = context.Departments
                                        .Where(d => d.Employees.Count() > 5)
                                        .Select(x => new
                                        {
                                            DepartmentName = x.Name,
                                            ManagerFName = x.Manager.FirstName,
                                            ManagerLName = x.Manager.LastName,
                                            Employees = x.Employees
                                                       .Select(e => new
                                                       {
                                                           EmployeeFName = e.FirstName,
                                                           EmployeeLName = e.LastName,
                                                           EmployeeJobTitle = e.JobTitle,
                                                       })
                                                       .OrderBy(efn => efn.EmployeeFName)
                                                       .ThenBy(eln => eln.EmployeeLName)
                                                       .ToList()
                                        })
                                        .OrderBy(x => x.Employees.Count())
                                        .ThenBy(x => x.DepartmentName)
                                        .ToList();

            foreach (var dep in departments5orMoreEmp)
            {
                sb.AppendLine($"{dep.DepartmentName} - {dep.ManagerFName}  {dep.ManagerLName}");

                foreach (var e in dep.Employees)
                {
                    sb.AppendLine($"{e.EmployeeFName} {e.EmployeeLName} - {e.EmployeeJobTitle}");
                }
            }

            return sb.ToString();
        }

        //Excercise 12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            IQueryable<Employee> employeesIncSal = context.Employees
                .Where(x =>
                         (x.Department.Name == "Engineering") ||
                         (x.Department.Name == "Tool Design") ||
                         (x.Department.Name == "Marketing") ||
                         (x.Department.Name == "Information Services")
                       );

            foreach (var e in employeesIncSal)
            {
                e.Salary *= 1.12M;
            }

            context.SaveChanges();


            var employees = employeesIncSal
                                .Select(x => new
                                    {
                                        FirstName = x.FirstName,
                                        LastName = x.LastName,
                                        Salary = x.Salary
                                    })
                                .OrderBy(x => x.FirstName)
                                .ThenBy(x => x.LastName)
                                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} ({e.Salary:f2})");
            }

            return sb.ToString();
        }

        //Excercise 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(x => x.FirstName.StartsWith("Sa"))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.Salary:f2} - ({e.Salary:f2})");
            }

            return sb.ToString();
        }

        //Excercise 14
        public static string DeleteProjectById(SoftUniContext context)
        {

            var townToDell = context.Towns.First(x => x.Name == "Seattle");

           

            IQueryable<Address> addressesToDell = context.Addresses
                    .Where(x => x.TownId == townToDell.TownId);

            IQueryable<Employee> employees = context.Employees
                    .Where(x => addressesToDell
                            .Any(a=> a.AddressId == x.AddressId));

            foreach (var e in employees)
            {
                e.AddressId = null;
            }

            int removedAddresses = 0;
            foreach (var address in addressesToDell)
            {
                context.Addresses.Remove(address);
                removedAddresses++;
            }

            context.Towns.Remove(townToDell);

            context.SaveChanges();

            return $"{removedAddresses} addresses in Seattle were deleted";
        }
    }
}
