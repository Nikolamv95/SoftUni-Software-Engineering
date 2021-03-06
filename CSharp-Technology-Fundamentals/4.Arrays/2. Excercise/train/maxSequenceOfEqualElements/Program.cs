﻿using System;
using System.Linq;

namespace maxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            //Стъпка 1 - създаваме масива
            string[] array = Console.ReadLine()
                             .Split();

            int bestCount = 0;
            int bestIndex = 0;

            // Стъпка 2 - Започваме да въртим масива от първият му индекс [0]
            for (int i = 0; i < array.Length; i++)
            {
                // Взимаме стойността на текущия индекс чрез променлива
                string curr = array[i];
                // Създаваме брояч който ще бори колко пъти даден символ се повтаря с друг последователно
                int currCounter = 1;

                // Стъпка 3 - създаваме нов фор цикъл с който започваме да проверяваме стойностите на масива след тази на curr
                for (int j = i + 1; j < array.Length; j++)
                {
                    // Стъпка 4 - създаваме if проверка в която проверяваме дали стойността на curr съвпада със стойността на сегашната стойност от масива
                    if (curr == array [j])
                    {
                        // При всяко влизане в проверката увеличаваме currCounter с 1;
                        currCounter += 1;
                    }
                    // В първия слувай в който не съвпадне break-ваме цикъла защото последователността се прекъсва
                    else
                    {
                        break;
                    }
                }
                
                // Стъпка 5 - проверяваме дали currCounter е по-голям от BestCount. Не слагаме = защото искаме да отпечатаме първата последователностт,
                // която сме намерили в случай на наличието на 2 последователности
                if (currCounter > bestCount)
                {
                    bestCount = currCounter;
                    // Запазваме индекса, от който е тръгнала най-добрата последователност в променливата bestIndex. На по-късент етап ще достъпим
                    // и стойността на индекса от масива.
                    bestIndex = i;
                }
            }

            // Стъпка 6 - създаваме нов цикъл с който ще изпишем дължината на последователността
            for (int i = 0; i < bestCount; i++)
            {
                // достъпваме стойността на индекса от който започва последователността
                string output = array[bestIndex];
                Console.Write($"{output} ");
            }
        }
    }
}
