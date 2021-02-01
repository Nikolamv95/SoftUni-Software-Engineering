using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveMutantVampireBunniesV2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimension = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimension[0];
            int cols = dimension[1];
            char[,] matrix = new char[rows, cols];
            int playerRow = -1;
            int playerCol = -1;

            //Стъпка 1 - Вкарване на данните в масива и намиране на позицията на играча
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currInput = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currInput[col];
                    if (currInput[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            //Стъпка 2 - Прочитане на командите, преместване на позицията на играча
            //и мултиплициране на зайците
            char[] directions = Console.ReadLine().ToCharArray();
            bool isWon = false;
            foreach (char move in directions)
            {
                int currentPlayerRow = playerRow;
                int currentPlayerCol = playerCol;

                //2.1 - Прочитане на хода който трябва да направи играча
                switch (move)
                {
                    case 'U':
                        currentPlayerRow--;
                        break;
                    case 'D':
                        currentPlayerRow++;
                        break;
                    case 'L':
                        currentPlayerCol--;
                        break;
                    case 'R':
                        currentPlayerCol++;
                        break;
                }

                //2.2 - Проверка дали играча хипотетично се намира още в матрицата
                isWon = IsWon(matrix, currentPlayerRow, currentPlayerCol);

                //2.3 - Проверяваме дали условието е вярно или грешно
                if (isWon)
                {
                    //2.3.1 - 
                    matrix[playerRow, playerCol] = '.';
                }
                else
                {
                    //2.3.2 - тъй като условието е грешно проверяваме дали след като преместим играча
                    // той ще стъпи на заек
                    if (matrix[currentPlayerRow, currentPlayerCol] == 'B')
                    {
                        //2.3.3 - Ако е хипотетично стъпва на заек, на текущите му кординати записваме . 
                        //и записваме кординатите на които би трябвало да стъпу върху заек, за да можем
                        //в края на задачите да отпечатаме кординатите на които е стъпил и загубил
                        matrix[playerRow, playerCol] = '.';
                        playerRow = currentPlayerRow;
                        playerCol = currentPlayerCol;
                    }
                    else
                    {
                        //2.3.4 - играча не стъпва на заек и затова му променяме позицията. 
                        //На текущата позиция записваме точка, а на следващата му позиция записваме 'P'.
                        //Също така записваме кординатите на хода който той кара.
                        matrix[playerRow, playerCol] = '.';
                        matrix[currentPlayerRow, currentPlayerCol] = 'P';
                        playerRow = currentPlayerRow;
                        playerCol = currentPlayerCol;
                    }
                }

                //2.4 - Мултиплицираме зайците като вкарваме първоначалните им кординати в колекция
                //и правим проверка, дали могат да се мултиплицират на кординатите според условите
                List<int> bunnies = new List<int>();

                //2.4.1 - Добавяме зайците в списъка, като индекс 0 е реда а индекс 1 е колоната 
                //на която се намира заека. След всяко завъртане на командата за ход на играча, в списъка ще се 
                //добавят и новите мултиплицирани зайци.
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (matrix[row,col] == 'B')
                        {
                            bunnies.Add(row);
                            bunnies.Add(col);
                        }
                    }
                }

                //2.4.2 Взимане на кординатите на заека и мултиплицирането му
                for (int i = 0; i < bunnies.Count; i+= 2)
                {
                    int bunnyRow = bunnies[i];
                    int bunnyCol = bunnies[i+1];
                    SpreadBunny(matrix, bunnyRow, bunnyCol);
                }

                //2.4.3 Проверяваме 2 неща в тази проверка, 
                //1 - Ако играча е спечели и излязъл от полето влизаме и прекъсваме цикъла
                //2 - Ако играча е все още на полето и след мултиплицирането на зайците някой от тях
                //го е ударил и се е мултиплицирал върху него.
                if (isWon || matrix[playerRow, playerCol] == 'B')
                {
                    break;
                }
            }

            //Стъпка 3 - печатаме текущата матрица и изписваме дали играчът е спечелил или не
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }

            //3.1 - Ако е спечелил изписваме текста won с последните му кординати, ако не текста за загуба
            if (isWon)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
            else
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }

        }

        //Масива е референтен тип данни и не връщаме стойност от метода, защото се презаписва
        private static void SpreadBunny(char[,] matrix, int bunnyRow, int bunnyCol)
        {
            //Проверка за ред нагоре
            if (bunnyRow - 1 >= 0)
            {
                matrix[bunnyRow - 1, bunnyCol] = 'B';
            }
            //Проверка за ред надолу
            if (bunnyRow + 1 < matrix.GetLength(0))
            {
                matrix[bunnyRow + 1, bunnyCol] = 'B';
            }
            //Проверка за колона на ляво
            if (bunnyCol - 1 >= 0)
            {
                matrix[bunnyRow, bunnyCol - 1] = 'B';
            }
            //Проверка за колона на дясно
            if (bunnyCol + 1 < matrix.GetLength(1))
            {
                matrix[bunnyRow, bunnyCol + 1] = 'B';
            }
        }

        private static bool IsWon(char[,] matrix, int currentPlayerRow, int currentPlayerCol)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            //Проверяваме дали с текущите хипотетични кординати играча ще се намира все още на дъската или ще е излезнал
            return currentPlayerRow < 0 || currentPlayerRow >= n || currentPlayerCol < 0 || currentPlayerCol >= m;
        }
    }
}
