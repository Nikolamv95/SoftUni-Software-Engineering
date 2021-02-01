using System;
using System.Linq;

namespace RactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] board = new char[numbers[0], numbers[1]];
            char[,] boardToRecord = new char[numbers[0], numbers[1]];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                char[] currInput = Console.ReadLine().ToCharArray();

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = currInput[col];
                    boardToRecord[row, col] = currInput[col];
                }
            }

            char[] playerMove = Console.ReadLine().ToCharArray();
            int movesToDo = 0;
            bool isWinner = false;
            bool isDied = false;
            int currRowPlayer = -1;
            int currColPlayer = -1;
            int diedPlayerRow = -1;
            int diedPlayerCol = -1;

            while (movesToDo < playerMove.Length)
            {
                char currMove = playerMove[movesToDo];
                currRowPlayer = -1;
                currColPlayer = -1;

                //Намирам къде се намира играча
                FindThePlayer(board, boardToRecord, ref currRowPlayer, ref currColPlayer);
                //Предвижвам играчан а друга позиция
                switch (currMove)
                {
                    case 'U':
                        if (currRowPlayer - 1 >= 0)
                        {
                            if (boardToRecord[currRowPlayer - 1, currColPlayer] == 'B')
                            {
                                boardToRecord[currRowPlayer, currColPlayer] = '.';
                                isDied = true;
                                currRowPlayer = currRowPlayer - 1;                               
                            }
                            else
                            {
                                boardToRecord[currRowPlayer, currColPlayer] = '.';
                                boardToRecord[currRowPlayer - 1, currColPlayer] = 'P';
                            }
                        }
                        else
                        {
                            isWinner = true;
                            boardToRecord[currRowPlayer, currColPlayer] = '.';
                        }
                        break;
                    case 'D':
                        if (currRowPlayer + 1 < board.GetLength(0))
                        {
                            if (boardToRecord[currRowPlayer + 1, currColPlayer] == 'B')
                            {
                                boardToRecord[currRowPlayer, currColPlayer] = '.';
                                isDied = true;
                                currRowPlayer = currRowPlayer + 1;
                            }
                            else
                            {
                                boardToRecord[currRowPlayer, currColPlayer] = '.';
                                boardToRecord[currRowPlayer + 1, currColPlayer] = 'P';
                            }
                        }
                        else
                        {
                            isWinner = true;
                            boardToRecord[currRowPlayer, currColPlayer] = '.';
                        }
                        break;
                    case 'R':
                        if (currColPlayer + 1 < board.GetLength(1))
                        {
                            if (boardToRecord[currRowPlayer, currColPlayer + 1] == 'B')
                            {
                                boardToRecord[currRowPlayer, currColPlayer] = '.';
                                isDied = true;
                                currColPlayer = currColPlayer + 1;
                            }
                            else
                            {
                                boardToRecord[currRowPlayer, currColPlayer] = '.';
                                boardToRecord[currRowPlayer, currColPlayer + 1] = 'P';
                            }

                        }
                        else
                        {
                            isWinner = true;
                            boardToRecord[currRowPlayer, currColPlayer] = '.';
                        }
                        break;
                    case 'L':
                        if (currColPlayer - 1 >= 0)
                        {
                            if (boardToRecord[currRowPlayer, currColPlayer - 1] == 'B')
                            {
                                boardToRecord[currRowPlayer, currColPlayer] = '.';
                                isDied = true;
                                currColPlayer = currColPlayer - 1;
                            }
                            else
                            {
                                boardToRecord[currRowPlayer, currColPlayer] = '.';
                                boardToRecord[currRowPlayer, currColPlayer - 1] = 'P';
                            }
                        }
                        else
                        {
                            isWinner = true;
                            boardToRecord[currRowPlayer, currColPlayer] = '.';
                        }
                        break;
                }

                //Мултиплицирам зайците
                diedPlayerRow = -1;
                diedPlayerCol = -1;

                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        if (board[row, col] == 'B')
                        {
                            //Right
                            if (col + 1 < board.GetLength(1))
                            {
                                if (boardToRecord[row, col + 1] == 'P')
                                {
                                    isWinner = false;
                                    diedPlayerRow = row;
                                    diedPlayerCol = col;
                                }
                                else
                                {
                                    boardToRecord[row, col + 1] = 'B';
                                }
                            }
                            //Left
                            if (col - 1 >= 0)
                            {
                                if (boardToRecord[row, col - 1] == 'P')
                                {
                                    isWinner = false;
                                    diedPlayerRow = row;
                                    diedPlayerCol = col;
                                }
                                else
                                {
                                    boardToRecord[row, col - 1] = 'B';
                                }
                            }
                            //UP
                            if (row - 1 >= 0)
                            {
                                if (boardToRecord[row - 1, col] == 'P')
                                {
                                    isWinner = false;
                                    diedPlayerRow = row;
                                    diedPlayerCol = col;
                                }
                                else
                                {
                                    boardToRecord[row - 1, col] = 'B';
                                }
                            }
                            //Down
                            if (row + 1 < board.GetLength(0))
                            {
                                if (boardToRecord[row + 1, col] == 'P')
                                {
                                    isWinner = false;
                                    diedPlayerRow = row;
                                    diedPlayerCol = col;
                                }
                                else
                                {
                                    boardToRecord[row + 1, col] = 'B';
                                }
                            }
                        }
                    }
                }

                //Презаписване на данните от единия масив в другия
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        char currValue = boardToRecord[row, col];
                        board[row, col] = currValue;
                    }
                }

                if (isWinner)
                {
                    break;
                }
                if (isDied)
                {
                    break;
                }

                movesToDo++;
            }


            //Print
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write($"{board[row, col]}");
                }
                Console.WriteLine();
            }

            if (isWinner)
            {
                Console.WriteLine($"won: {currRowPlayer} {currColPlayer}");
            }
            else
            {
                if (isDied)
                {
                    Console.WriteLine($"dead: {currRowPlayer} {currColPlayer}");
                }
                else
                {
                    Console.WriteLine($"dead: {diedPlayerRow} {diedPlayerCol}");
                }

            }
        }

        private static void FindThePlayer(char[,] board, char[,] boardToRecord, ref int currRowPlayer, ref int currColPlayer)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (boardToRecord[row, col] == 'P')
                    {
                        currRowPlayer = row;
                        currColPlayer = col;
                    }
                }
            }
        }
    }
}
