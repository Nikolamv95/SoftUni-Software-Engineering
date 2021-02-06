﻿using System;

namespace stringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            //Стъпка 1 - взимаме инпута
            var field = Console.ReadLine();
            //дефинираме бомбата
            int bomb = 0;

            //Стъпка 2 - създаваме форцикъл през който ще обходим индексите на field
            for (int i = 0; i < field.Length; i++)
            {
                //Стъпка 3 - взимаме чара на конкретния индекс от field
                var currChar = field[i];

                //Стъпка 4 - проверяваме дали текущия чар == на >
                if (currChar == '>')
                {
                    //Ако текущия индекс е > то взимаме стойността на чара след него, който 
                    //се предполага че е цифра.
                    bomb += int.Parse(field[i + 1].ToString());
                    //продължаваме към следващия индекс за да не изтъркаме текущия който е >
                    continue;
                }

                //Влизаме в бомата ако има стойност над 0
                if (bomb > 0)
                {
                    //Трием само елемента на който се намира i в момента
                    field = field.Remove(i, 1);
                    //Тъй като сме изтрили един индекс и на негово място идва друг
                    //махаме -- от стойността на i за да премине през новия елемент, който се намира
                    //на същия индекс пример абц: трием б и остава ац затова минаваме отново през ц с i--
                    i--;
                    //Целта ни е да изтрием само 1 индекс, за да избегнем случай в който ще изтрием >
                    //Ако има такъв случай >2>1cc ще изтрием само 2, ще запазим 1 като стойност на бомбата
                    //и при следващото минаваме през проверката за > ще добавим 1 към стойността на бомбата и
                    //ще премахнем 1c И ще остане >>c
                    bomb--;
                }
            }

            Console.WriteLine(field);
        }
    }
}

