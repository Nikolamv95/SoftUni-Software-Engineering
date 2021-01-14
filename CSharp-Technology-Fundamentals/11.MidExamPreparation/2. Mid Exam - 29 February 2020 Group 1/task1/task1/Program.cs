using System;
using System.Linq;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());
            decimal bestTotalBonus = 0;
            int bestStudent = 0;



            for (int i = 0; i < studentsCount; i++)
            {
                int currStudent = int.Parse(Console.ReadLine());                   
                int studentAttendance = currStudent;
                decimal totalBonus = (decimal)studentAttendance / lecturesCount * (5 + additionalBonus);

                if (totalBonus >= bestTotalBonus)
                {
                    bestTotalBonus = totalBonus;
                    bestStudent = studentAttendance;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Round(bestTotalBonus)}.");
            Console.WriteLine($"The student has attended {bestStudent} lectures.");
        }
    }
}
