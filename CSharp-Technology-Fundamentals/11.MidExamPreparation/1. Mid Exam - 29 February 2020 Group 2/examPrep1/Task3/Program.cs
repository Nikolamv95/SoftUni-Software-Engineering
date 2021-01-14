using System;
using System.Linq;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Стъпка 1 - взимаме кварталите с брой сърца и премахваме @ като знак
            int[] neighbourhood = Console.ReadLine()
                                         .Split("@")
                                         .Select(int.Parse)
                                         .ToArray();
            
            //Създаваме позицията на която купидон ще скача
            int jumpedPosition = 0;
            //Дефинираме че при всеки скок премахва 2 сърца от конкретния квартал
            int heartsToDel = 2;
            //Взимаме инпута Jump X
            string[] command = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

            
            //Стъпка 2 - създаваме While цикъл в който правим проверка дали command != Love
            while (command[0] != "Love!")
            {   //Взимаме дължината на скока който прави купидон
                int lenght = int.Parse(command[1]);
                //ВАЖНООООООООООООООООООООООООООООО!
                jumpedPosition += lenght;

                //Стъпка 3 - Правим проверка дали купидон скача в индекс който е по-голям или малък от дължината на neighbourhood.Length
                if (jumpedPosition >= 0 && jumpedPosition < neighbourhood.Length)
                {
                    //Ако индекса е вярен махаме 2 сърца от конкретния квартал(индекс)
                    neighbourhood[jumpedPosition] -= heartsToDel;
                }
                else
                {
                    //Ако индекса не е верен Купидон се връща винаги на индекс 0 и от него махаме 2 сърца
                    jumpedPosition = 0;
                    neighbourhood[jumpedPosition] -= heartsToDel;
                }

                //Стъпка 4 - Проверяваме каква е последната стойност на индекса в която се намира Купидон
                //Ако тя е нула означава, че току що сме махнали 2 сърца и индекса ще има СВ Валентин
                if (neighbourhood[jumpedPosition] == 0)
                {
                    //Печатаме това съобщение
                    Console.WriteLine($"Place {jumpedPosition} has Valentine's day.");
                }
                else if (neighbourhood[jumpedPosition] < 0)
                {
                    //Ако индекса е с - стойност означава, че ние продължаваме да махаме сърца от конкретната позиция
                    //и този квартал вече е имал СВ Валентин. Индекса продължава да се намаля защото по условие ако 
                    //вече си имал СВ Валентин не е нужно да пазиш стойност 0.
                    Console.WriteLine($"Place {jumpedPosition} already had Valentine's day.");
                }

                command = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();
            }

            //Стъпка 5 - Печатаме коя е последната позиция на купидон
            Console.WriteLine($"Cupid's last position was {jumpedPosition}.");

            //Стъпка 6 - Проверяваме колко квартала имат стойност над 0
            int failedCount = neighbourhood.Count(x => x > 0);

            //Ако няма квартали със стойности над 0 мисята е успешна
            if (failedCount == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {   //В противен случай отпечатваме колко е бройката на кварталите в които 
                //купидон не е успял
                Console.WriteLine($"Cupid has failed {failedCount} places.");
            }
        }
    }
}
