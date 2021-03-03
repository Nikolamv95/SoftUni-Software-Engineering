using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<string> input = new List<string>();
            bool isEnd = true;

            while (isEnd)
            {
                command = command.Remove(0, 6);
                input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                ListyIterator<string> listy = new ListyIterator<string>(input);

                while ((command = Console.ReadLine()) != "END")
                {
                    switch (command)
                    {
                        case "HasNext":
                            Console.WriteLine(listy.HasNext()); 
                            break;
                        case "Move":
                            Console.WriteLine(listy.Move());
                            break;
                        case "Print":
                            listy.Print();
                            break;
                        case "PrintAll":
                            foreach (var item in listy)
                            {
                                Console.Write($"{item} ");
                            }
                            Console.WriteLine();
                            break;
                    }
                }
                isEnd = false;
            }
        }
    }
}
