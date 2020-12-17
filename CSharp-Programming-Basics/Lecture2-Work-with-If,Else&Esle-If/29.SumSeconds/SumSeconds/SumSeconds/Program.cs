using System;

namespace SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int competitor1 = int.Parse(Console.ReadLine());
            int competitor2 = int.Parse(Console.ReadLine());
            int competitor3 = int.Parse(Console.ReadLine());

            int totalTime = competitor1 + competitor2 + competitor3;

            int minutes = totalTime / 60;
            int seconds = totalTime % 60;

            if (seconds < 10)
            {
                Console.WriteLine($"{minutes}:0{seconds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:{seconds}");
            }

            //Console.Writeline($"{minutes}:{seconds:d2}")
            //Това е друго решение без да използваме If проверка.
            //d допълва символ "0" към променливата
            //Ако променливата има 1 цифра {seconds} = 6, с добавянето на {seconds:d2} числото ще стане 06.
        }
    }
}
