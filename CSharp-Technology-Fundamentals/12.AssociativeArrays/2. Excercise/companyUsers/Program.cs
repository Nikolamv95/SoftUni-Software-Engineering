using System;
using System.Collections.Generic;
using System.Linq;

namespace companyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> listOfCourses = new Dictionary<string, List<string>>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command
                                 .Split(" -> ");

                string company = data[0];
                string newEmployeeId = data[1];

                if (listOfCourses.ContainsKey(company) == false)
                {
                    List<string> employeeId = new List<string> { newEmployeeId };
                    listOfCourses.Add(company, employeeId);
                }
                else
                {
                    if (listOfCourses[company].Contains(newEmployeeId) == false)
                    {
                        listOfCourses[company].Add(newEmployeeId);
                    }
                }
            }

            foreach (var item in listOfCourses.OrderBy(k=>k.Key))
            {
                Console.WriteLine($"{item.Key}");

                foreach (var name in item.Value)
                {
                    Console.WriteLine($"--{name}");
                }
            }
        }
    }
}
