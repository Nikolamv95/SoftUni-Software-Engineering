using System;
using System.Linq;

namespace arrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string [] array = Console.ReadLine()
                              .Split()
                              .ToArray();

            int rotations = int.Parse(Console.ReadLine());

            
            //Стъпка 1 създай FOR цикъл с който ще преместиш n на брой числа
            for (int i = 0; i < rotations; i++)
            {
                // Стъпка 2 - Вземи Първият символ от масива който ще преместиш и го запази;
                string elementToRotate = array[0];

                // Стъпка 3 - Създай for цикъл с който ще обходиш и размениш позициите на числата в масива.
                // ВАЖНО!! - J започва от 1 (втора позиция в масива) защототи вече си взел стойността на [0] (първат позиция)
                for (int j = 1; j < array.Length; j++)
                {
                    // Стъпка 4 - с променливата вземи стойността на втората позиция в масива [1]. 
                    // В случая j е със стойност 1 (декларирана по-горе във for цикъла).
                    // Array[j] да се разбира като Array[1]; Array[j] записва сегашната си стойност в currentElement.
                    string currentElement = array[j];

                    // Стъпка 4 - запиши стойността на currentElement в предходната позиция на масива.
                    array[j - 1] = currentElement;
                    // Array[0]  =    Array[1]
                    // Със завъртането на for цикъла изразът ще се превърне в Array[1]  = Array[2]
                }
                // Стъпка 5 запиши първият елемент който си взел в началото на първия for цикъл и го запиши
                // на последно място в масива. Пример: array[последна позция] = array [0];
                array[array.Length - 1] = elementToRotate;

                // С всяко завъртане на циклите стойностите се променят.
            }
            // Стъпка 6 - отпечата масива с интервал между стойностите.
            Console.WriteLine(string.Join(' ', array));
        }
    }
}
