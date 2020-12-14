using System;

namespace graduationPt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Напишете програма, която изчислява средната оценка на ученик от цялото му обучение.
            //На първия ред ще получите името на ученика, а на всеки следващ ред неговите годишни оценки.

            //Ученикът преминава в следващия клас, ако годишната му оценка е по-голяма или равна на 4.00.
            //Ако ученикът бъде скъсан повече от един път, то той бива изключен и програмата приключва, като
            //се отпечатва името на ученика и в кой клас бива изключен.

            string nameStudent = Console.ReadLine();
            double gradeYear = double.Parse(Console.ReadLine());

            double averageGrade = 0;
            double nextGrade = 0;
            double notPassed = 0;

            while (true)
            {
                if (gradeYear >= 4.00)
                {
                    nextGrade += 1;
                    averageGrade += gradeYear;

                    if (nextGrade >= 12)
                    {
                        averageGrade = averageGrade / nextGrade;
                        Console.WriteLine($"{nameStudent} graduated. Average grade: {averageGrade:f2}");
                        break;
                    }
                }

                else if  (gradeYear < 4.00)
                {
                    notPassed += 1;

                    if (notPassed >= 2)
                    {
                        nextGrade += 1;
                        Console.WriteLine($"{nameStudent} has been excluded at {nextGrade} grade");
                        break;
                    }
                }

                gradeYear = double.Parse(Console.ReadLine());
            }
        }
    }
}
