using System;

namespace Params
{
    class Program
    {
        static void Main(string[] args)
        {
            //2- С този метод подаваме на колекцията множество от данни и ги записваме в нея
            PrintArgs("1", "2", "3");
        }

        //1- Това е метод който принтира стойностите които са записани в колекцията
        static void PrintArgs(params string[] arguments)
        {                    //params записва в колекцията множество от данни на веднъж

            foreach (var item in arguments)
            {
                Console.WriteLine(item);
            }
        }
    }
}
