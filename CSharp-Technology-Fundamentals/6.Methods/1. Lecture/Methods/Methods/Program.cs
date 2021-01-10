using System;

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintText("Hello World");
            PrintNumber(7);
        }

        static void PrintText(string text)
        {
            Console.WriteLine(text);
        }

        static void PrintNumber(int number)
        {
            Console.WriteLine(number);
        }



        //Вариант 2 ВАЖНО!!
        //static void Main(string[] args)
        //{
        //    int num = 0;
        //    int second = 1;
        //    PrintNumberTest(num, second);
        //}
        ////num И second предават стойностите си на Start и End)
        //static void PrintNumberTest(int start, int end)
        //{
        //    Console.WriteLine($"{start}, {end}");
        //}

        // Refference Ty
    }
}
