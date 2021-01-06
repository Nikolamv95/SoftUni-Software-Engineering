using System;
using System.Linq;

namespace topIntegers
{
    class Program
    {
        static void Main(string[] args)
        {   
            // Стъпка 1 - дефинираме масива
            int[] array = Console.ReadLine()
                                      .Split()
                                      .Select(int.Parse)
                                      .ToArray();
           
            bool isBigger = true;
           
            for (int i = 0; i < array.Length; i++)
            {
                // Стъпка 2 - взимаме стойността на цифрата която ще сравняваме
                int numberToCompare = array[i];

                for (int j = i + 1; j < array.Length; j++)
                {
                    // Стъпка 3 - Взимаме стойностите на числата които са от дясно
                    // на цифрата която вече сме взели.
                    int currentNumber = array[j];

                    // Стъпка 4 - Сравняваме числата от дясно на цифрата която сме взели с нея.
                    // 14 13 12 21 -> взели сме цифрата 14 (numberToCompare) дали от дясно на нея
                    // има число което е по-голямо -> 13, 12, 21 >= 14
                    // ако едно от числата е по-голямо от 14 влиза в проверката
                    // и дава стойност False на isBigger, която предварително е дефинирана с TRUE;
                    if (currentNumber >= numberToCompare)
                    {
                        isBigger = false;
                        break;
                        // Ако един път currentNumber >= numberToCompare няма смисъл да проверяваме
                        // останалите числа след него. Спираме цикъла с break;
                    }
                }

                // Стъпка 5 - след приключване на проверките ако numberToCompare е по-голямо от всички числа
                // след него, то няма да влезе в проверката и isBigger ще си остане със стойност TRUE,
                // което ще му позволи да влезе и да се отпечата 
                if (isBigger)
                {
                    Console.Write($"{numberToCompare} ");
                }

                // ВАЖНО!! - ако isBigger получи стойност False, преди да премине към следвощото число от поредицата
                //currentNumber трябва да му се придаде отново стойност TRUE!
                isBigger = true;

                // Последното число винаги ще се изписва защото няма с какво да се сравни, не влиза
                // във тория for цикъл и isBigger винаги ще има стойност true за него

            }
        }
    }
}
