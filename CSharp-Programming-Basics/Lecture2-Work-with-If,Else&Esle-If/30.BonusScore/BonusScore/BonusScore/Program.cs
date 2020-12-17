using System;

namespace BonusScore
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int startPoints = int.Parse(Console.ReadLine());
            double bonus = 0.0;
            double bonusOver100 = 0.20;
            double bonusover1000 = 0.10;

            //Calculations If
            if (startPoints <= 100) // Проверяваме дали числото е над или равно на 100
            {
                bonus = 5;
            }
            else if (startPoints > 1000) // Проверяваме дали числото е над 1000
            {
             bonus = startPoints * bonusover1000;
            }
            else // В случай, че числото е над 100, но под 1000 се изпълнява функцията Else,
                // защото тя хваща числата между 100 и 1000
            {
             bonus = startPoints * bonusOver100;
            }
            //Правим проверка дали числото е четно, за бонус брой точки. Ако числото не е четно функсията If се пропуска
            // и се преминава към Else if където ще проверим дали числото завършва на 5.
            if (startPoints % 2 == 0)
            {
                bonus = bonus + 1;
            }
            else if (startPoints % 10 == 5) //Проверяваме дали числото завършва на 5, ако не завърша минаваме към Console.Writeline
            {
             bonus = bonus + 2;
            }

            //Output
            Console.WriteLine($"{bonus}");
            Console.WriteLine($"{bonus + startPoints}");
        }
    }
}
