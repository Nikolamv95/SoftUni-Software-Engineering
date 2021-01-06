using System;

namespace dayofWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            // 7 елемента вътре
            string[] days = new string [] 
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday",
            };

            // вкарваме число
            int dayNum = int.Parse(Console.ReadLine());
            
            //Тъй като денят от седмицата не започва с 0, а е от 1 до 7, всеки знак под 1 и над 7 е грешка;
            if (dayNum < 1 || dayNum > days.Length)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                // тъй като масива започва от 0 до 6, за да достъпим желаният ден от седмицата
                // ние трябва да вкараме число между 1 и 7, но масива е от 0 до 6, затова от масива
                // изваждаме 1 число и ако въведем 1 става 1-1 и достъпваме 0 от масива което е Понедленики
                Console.WriteLine(days[dayNum - 1]);
            }
        }
    }
}
