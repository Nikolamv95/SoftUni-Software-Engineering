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
             number = Calculation(number, add); // 7. Добавяме преди името на метода променливата която ще презапишем number2 -> записва стойността си върху number.
                                                // Как компилатора разбира какво да направи? number e дала стойността си на number 2, следователно сега number2 прави обратното.

            //8. Компилатора ще принтира вече променената променлива със стойност 10, защото ние сме прехврълили стойоността от единия метод
            // в другия Calculations -> Main
            Console.WriteLine(number);
        }

        //3. Създаваме метод с със стойност ! int ! декларирани променливи number2 и add (те са независими от променливите в горния метод),
        // които от своя страна ще приемат стойностите на number и add.
        static int Calculation(int number2, int add)
        {
            //5. number2 e ъс стойност 8, но към него се добавя 2 и резултата е = 10;
            number2 += add;
            //6. Пишем фунцкията return и добавяме към нея променливата която искаме да върнем в метода Main -> return number2;
            return number2;
        }
    }
}
