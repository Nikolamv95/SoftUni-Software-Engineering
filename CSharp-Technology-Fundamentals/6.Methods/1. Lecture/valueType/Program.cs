using System;

namespace refferenceType
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Създаваме променлива със стойност 8
            int number = 8;
            //2. Създаваме променлива със стойност 2
            int add = 2;
            //4. Прехвърляме стойностите на number, add към метод Calculations
            Calculation(number, add);
            //7. Компилатора отпечатва стойността на number Която е от метод MAIN и е със стойност 8, а не 10. Стойноста 10 си остава
            // в долния метод Calculations
            Console.WriteLine(number);
        }

        //3. Създаваме метод с декларирани променливи number и add (те са независими от променливите в горния метод),
        // които от своя страна ще приемат стойностите на number и add.
        static void Calculation(int number, int add)
        {
            //5. number e ъс стойност 8, но към него се добавя 2 и резултата е = 10;
            number += add;
            //6. Компилатора се връща в Main метода но НЕ презаписва стойността на number от metod CALCULATIONS
            // в променливата number от метод Main
        }
    }
}
