using System;

namespace MultidimensionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = { { 1, 2 }, { 3, 4 }, { 6, 7 }, { 8, 9 } };//Вход
            int element11 = array[1, 1];//Достъп
            Console.WriteLine(element11);// result = 4

            //Записваме данни;
            array[1, 1] = 5;
            element11 = array[1, 1];
            Console.WriteLine(element11);

            //Така четем двумерния масив .GetLenght и му подаваме измерениет
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    Console.Write($"{array[row, col]} ");
                }
                Console.WriteLine();
            }

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
