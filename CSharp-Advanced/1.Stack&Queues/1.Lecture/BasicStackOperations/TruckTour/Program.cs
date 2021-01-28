using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 - Взимаме броя pumps които ще трябва да запишем
            int n = int.Parse(Console.ReadLine());
            //2 - Създаваме опшка с вложен масив вътре
            Queue<int[]> pumps = new Queue<int[]>();
            //3 - Правим метод с който пълним опашката
            FillQueue(n, pumps);

            int counter = 0;
            //4 - Създаваме цикъл с който ще проверим от кой pump ще се премине дистанцията
            while (true)
            {
                //5 - Започваме от първата помпа, при повторното завъртане, вече ще започним от следващата помпа
                int fuellAmount = 0;
                bool foundPoint = true;

                //6 - Използваме форийч за да обходим колекцията от опашки
                foreach (var pump in pumps)
                {
                    //7 - Записваме горивото на помпата
                    fuellAmount += pump[0];

                    //8 - Проверяваме дали горивото е по-голяма от дистанцията
                    if (fuellAmount < pump[1])
                    {//ако не е влизаме и брейкваме форийча (той само чете данните)
                        foundPoint = false;
                        break;
                    }
                    else
                    {//ако не е премахваме дистанцията от горивото и му оставяме остатъка
                        fuellAmount -= pump[1];
                    }
                }

                //9 - Проверяваме дали дистанцията е извървяна и ако е прекъсваме цикъла
                if (foundPoint == true)
                {
                    break;
                }

                //10 - Увеличаваме каунтъра с 1
                counter++;

                //11- Най-предния Pump отива най-отзад на опащката
                pumps.Enqueue(pumps.Dequeue());
            }

            Console.WriteLine(counter);

        }

        private static void FillQueue(int lines, Queue<int[]> queOfPumps)
        {
            for (int i = 0; i < lines; i++)
            {
                int[] input = Console.ReadLine()
                                .Split(' ')
                                .Select(int.Parse)
                                .ToArray();

                queOfPumps.Enqueue(input);
            }
        }
    }
}
