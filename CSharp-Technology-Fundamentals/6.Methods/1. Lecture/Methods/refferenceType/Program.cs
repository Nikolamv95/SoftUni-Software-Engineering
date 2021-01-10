using System;

namespace refferenceType
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Създаваме масив със големина 1 и стойност 8
            int[] number = {8};
            //2. Създаваме променлива със стойност 2
            int add = 2;
            //4. Прехвърляме стойностите на number, add към метод Calculations
            Calculation(number, add);
            //7. Компилатора отпечатва стойността на number[0]
            Console.WriteLine(number[0]);
        }

        //3. Създаваме метод с деклариран масив NewNumber и променлива add2, Които от своя страна ще приемат стойностите на 
        // масив number [] и add.
        static void Calculation(int [] newNumber, int add2)
        {
            //5. New number e ъс стойност 8, но към него се добавя 2 и резултата е = 10;
            newNumber [0] += add2;
            //6. Компилатора се връща в Main метода но презаписва стойността на newNumber [] в стойността на масива Number[]
        }
    }
}
