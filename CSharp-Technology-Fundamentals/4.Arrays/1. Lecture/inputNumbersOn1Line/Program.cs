using System;
using System.Linq;

namespace inputNumbersOn1Line
{
    class Program
    {
        static void Main(string[] args)
        {
            //Вариант 1 = Вкарване на много стойности на 1 ред с разделите (space)

            string values = Console.ReadLine(); //дефинираш променливата със стойностите - Винаги е String
            string[] array = values.Split(); //създаваш масив от тип String в който вкарваш тези стойности с функция Split
            int [] intArray = new int[array.Length]; //взимаш дължината на горния масив и я придаваш на новия

            for (int i = 0; i < array.Length; i++)
            {
                intArray[i] = int.Parse(array[i]); // придаваш стойностите от масив array[i] и ги предаваш на масив intArray[i]
            }

            //Вариант 2
            string valuesN = Console.ReadLine(); //дефинираш променливата със стойностите - Винаги е String

            //създаваш масив от тип String в който вкарваш тези стойности с функция Split, като добавяш още една опция REmoveEmpyEntries
            //за да нямащ празни стойности в случай че имаш няколко разделящи елемента ,(space) , 
            string[] arrayN = values.Split(", ", StringSplitOptions.RemoveEmptyEntries); 
            
            int[] intArrayN = arrayN.Select(int.Parse).ToArray();
            //От arrayN стринга с функцията Select, избираш конкретния [i] от масива
            //и го преобразуваш в int с int.Parse, но тъй като стринг не може да го преобразува в int, избираш функцията ToArray
            //която вече преобразува int-a и го вкарва в масива intArrayN

            //Вариант3
            int[] intArrayNN = Console.ReadLine() //въвеждаш стойностите
                              .Split(", ", StringSplitOptions.RemoveEmptyEntries)//разделяш ги и трие празните пространства
                              .Select(int.Parse)//извикваш стойностите които си вкарал и им казваш че ще бъдат в int и ги преобразуваш
                              .ToArray();//вкарваш ги в масива


        }
    }
}
