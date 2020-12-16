using System;

namespace salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int openTabs = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());


            for (int i = 0; i < openTabs; i++)
            {
                string typeTab = Console.ReadLine();

                if (typeTab == "Facebook")
                {
                    salary -= 150;
                }
                else if (typeTab == "Instagram")
                {
                    salary -= 100;
                }
                else if (typeTab == "Reddit")
                {
                    salary -= 50;
                }
                if (salary == 0)
                {
                    Console.WriteLine($"You have lost your salary.");
                }
            }

            if (salary > 0)
            {
                Console.WriteLine(salary);
            }


        }

    }
}
