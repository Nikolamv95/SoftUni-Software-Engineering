using System;

namespace _7._ProjectCreation_Architect
{
    class Program
    {
        static void Main(string[] args)
        {
            string architectName1 = Console.ReadLine();
            int numberProjects1 = int.Parse(Console.ReadLine());
            int hours1 = numberProjects1 * 3;
            Console.WriteLine($"The architect {architectName1} will need {hours1} hours to complete {numberProjects1} project/s.");

        }
    }
}
