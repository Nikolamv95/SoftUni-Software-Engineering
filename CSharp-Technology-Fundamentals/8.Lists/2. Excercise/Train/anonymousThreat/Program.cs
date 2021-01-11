using System;
using System.Collections.Generic;
using System.Linq;
namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();
            
            string command = Console.ReadLine();

            while (command != "3:1")
            {
                List<string> tokens = command.Split().ToList();

                if (tokens[0] == "merge")
                {   //Взимаме си startIndex и endIndex
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);
                    //Проверка дали startIndex е по-малък от 0;
                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    //Проверка дали startIndex е по-голям от размера на листа;
                    else if (startIndex > input.Count - 1)
                    {
                        startIndex = input.Count - 1;
                    }
                    //Проверка дали endIndex е по-малък от 0;
                    if (endIndex < 0)
                    {
                        endIndex = 0;
                    }
                    //Проверка дали endIndex е по-голям от размера на листа;
                    else if (endIndex > input.Count - 1)
                    {
                        endIndex = input.Count - 1;
                    }
                    //Създаваме нов лист в който да напълним данните
                    List<string> temp = new List<string>();
                    //Добавяме стойностите в новия лист Temp
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        temp.Add(input[i]);
                    }
                    //в началния лист input добавяме новия списък temp без разстояние между стойностите защото имаме фунцкия merge
                    //като позицията на която го добавяме е startIndex защото от там е започнало обединяването на стойностите.
                    input[startIndex] = string.Join("", temp);
                    //Изтриваме всички стойности след вече добавената от temp, затова е startIndex +1
                    for (int i = startIndex + 1; i <= endIndex; i++)
                    {
                        input.RemoveAt(startIndex + 1);
                    }
                }
                else if (tokens[0] == "divide")
                {   //създаваме нов лист temp(той е различен от този в горния if
                    List<string> temp = new List<string>();
                    //Взимаме си toDivide и partitions
                    string toDivide = input[int.Parse(tokens[1])];
                    int partitions = int.Parse(tokens[2]);

                    int partLength = toDivide.Length / int.Parse(tokens[2]);
                    int additionalPartLength = toDivide.Length % int.Parse(tokens[2]);

                    for (int i = 0; i < partitions; i++)
                    {
                        if (i == partitions - 1)
                        {
                            partLength += additionalPartLength;
                        }
                        temp.Add(toDivide.Substring(0, partLength));
                        toDivide = toDivide.Remove(0, partLength);
                    }
                    input.RemoveAt(int.Parse(tokens[1]));
                    input.InsertRange(int.Parse(tokens[1]), temp);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", input));
        }
    }
}