using System;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string gender = Console.ReadLine();
            double weigth = double.Parse(Console.ReadLine());
            double heigth = double.Parse(Console.ReadLine());
            double age = double.Parse(Console.ReadLine());
            string activity = Console.ReadLine();

            double bnmMens = 0;
            double bnmWomens = 0;
            double finalResult = 0;

            if (gender == "m")
            {
                bnmMens = 66 + (13.7 * weigth) +(5 * (heigth*100)) -(6.8 * age);
                finalResult = bnmMens;
            }
            else if (gender == "f")
            {
                bnmWomens = 655 + (9.6 * weigth) + (1.8 * (heigth * 100)) - (4.7 * age);
                finalResult = bnmWomens;
            }

            switch (activity)
            {
                case "sedentary":
                    finalResult *= 1.2;
                    break;
                case "lightly active":
                    finalResult *= 1.375;
                    break;
                case "moderately active":
                    finalResult *= 1.55;
                    break;
                case "very active":
                    finalResult *= 1.725;
                    break;
            }

            Console.WriteLine($"To maintain your current weight you will need {Math.Ceiling(finalResult)} calories per day.");
        }
    }
}
