using System;
using System.Linq;
using System.Text;

namespace multyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string longNumber = Console.ReadLine().Trim('0');
            int num = int.Parse(Console.ReadLine());
            int temp = 0;
            StringBuilder sb = new StringBuilder();

            //Правим проверка дали ни дават грешни данни. Ако условието е вярно
            //връщаме 0 и прекратяваме програмата

            if (num == 0 || longNumber == "")
            {
                Console.WriteLine(0);
                return;
            }

            //Минаваме през всеки един символ в longNumber като започваме да умножаваме
            //от последния му символ. Затова обръщаме стринга.
            foreach (char ch in longNumber.Reverse())
            {
                //Стъпка 1 - Взимаме стойността на вече обърнатия стринг -> първия му char и умножаваме
                int digit = int.Parse(ch.ToString());
                int result = digit * num + temp;


                //Стъпка 2 - взимаме последния елемент от числото
                int restDigit = result % 10;
                //Стъпка 3 - разделяме резултата на 10;
                temp = result / 10;

                //Записваме последния елемтн от числото на първи иденкс в стринга
                sb.Insert(0, restDigit);
            }

            if (temp > 0)
            {
                sb.Insert(0, temp);
            }

            Console.WriteLine(sb);
        }
    }
}
