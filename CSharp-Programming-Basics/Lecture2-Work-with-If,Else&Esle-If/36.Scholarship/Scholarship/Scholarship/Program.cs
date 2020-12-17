using System;
using System.Runtime.InteropServices.ComTypes;

namespace Scholarship
{   class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double averageGrade = double.Parse(Console.ReadLine());
            double minimalSalary = double.Parse(Console.ReadLine());

            double socialScholarship = Math.Floor(minimalSalary * 0.35);
            double excellentScholarship = Math.Floor(averageGrade * 25);
            ;
            if (income >= minimalSalary && averageGrade >= 5.50)
            {
                Console.WriteLine($"You get a scholarship for excellent results {excellentScholarship} BGN");
            }
            else if (income >= minimalSalary && averageGrade < 5.50)
            {
                Console.WriteLine($"You cannot get a scholarship!");
            }
            else if (income < minimalSalary && averageGrade >= 5.50 && socialScholarship <= excellentScholarship)
            {
                Console.WriteLine($"You get a scholarship for excellent results {excellentScholarship} BGN");
            }
            else if (income <= minimalSalary && averageGrade > 4.50)
            {
                Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
            }
            else if (income <= minimalSalary && averageGrade <= 4.50)
            {
                Console.WriteLine($"You cannot get a scholarship!");
            }
        }
    }        
} 
