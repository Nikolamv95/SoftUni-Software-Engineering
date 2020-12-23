using System;

namespace padawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int studentsNum = int.Parse(Console.ReadLine());
            double lightsabersP = double.Parse(Console.ReadLine());
            double robesP = double.Parse(Console.ReadLine());
            double beltsP = double.Parse(Console.ReadLine());

            double sumLightSabers = (lightsabersP * Math.Ceiling(studentsNum * 1.1));
            double sumLRobes = robesP * studentsNum;
            double sumLBelts = beltsP * (studentsNum - (studentsNum / 6));

            double totalSum = sumLBelts + sumLRobes + sumLightSabers;


            if (totalSum <= money)
            {
                Console.WriteLine($"The money is enough - it would cost {totalSum:f2}lv.");
            }
            else
            {
                totalSum = totalSum - money;
                Console.WriteLine($"Ivan Cho will need {totalSum:f2}lv more.");
            }
        }
    }
}
