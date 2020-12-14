using System;

namespace examPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxBadGrades = int.Parse(Console.ReadLine());
            int currentBadGrade = 0;

            int doneTasks = 0;
            double taskGradeNew = 0;
            string lastTask = "";

            while (currentBadGrade < maxBadGrades)
            {

                string nameTask = Console.ReadLine();

                if (nameTask == "Enough")
                {
                    double averageScore = taskGradeNew / doneTasks;

                    Console.WriteLine($"Average score: {averageScore:f2}");
                    Console.WriteLine($"Number of problems: {doneTasks}");
                    Console.WriteLine($"Last problem: {lastTask}");
                    Environment.Exit(0);
                }

                double taskGrad = double.Parse(Console.ReadLine());

                if (taskGrad <= 4.00)
                {
                    currentBadGrade += 1;
                }

                doneTasks += 1;
                taskGradeNew += taskGrad;
                lastTask = nameTask;
            }

            Console.WriteLine($"You need a break, {maxBadGrades} poor grades.");
        }
    }
}
