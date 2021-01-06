using System;
using System.Linq;

namespace printNumbersinReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задаваме каква е дължината на масива
            int input = int.Parse(Console.ReadLine()); // променлива
            int[] array = new int[input]; // Създаване на масива и задаване на дължината му, чрез променливата

            //Записване на стойности в масива (input -> n на брой числа)
            for (int i = 0; i < input; i++)
            {
                //създаване на нова променлива от тип int чрез която ще записваме стойностите в масива
                int numberToArray = int.Parse(Console.ReadLine());
                //извикваме масива array[i] (i е индекс и е просто СИНeТАКСИС) и му казваме
                //да записва числата които вкарваме от numberToArray
                array[i] = numberToArray;
                // Може да използваме директно array[i] = int.Parse(Console.ReadLine());
                // за да си попълним стойностите в масива
            }

            //Започваме да въртим цикъла от последната записана стойност в масива
            for (int j = array.Length - 1; j >= 0; j--)
            {
                //достъпваме масива с последната му стойност - Вариант 1
                Console.Write($"{array[j]} ");
                //Вариант 2 - записваме последната стойност на масива в променлива
                //int numberToPrint = array[j];
                //Console.Write($"{numberToPrint} ");
            }

            //Вариант 2
            //изпускаме последния for цикъл и използваме Extensions на масивите
            Console.WriteLine(string.Join(' ', array.Reverse()));

        }
    }
}
