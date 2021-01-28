using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountOfFood = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine()
                                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray();

            Queue<int> queOfOrders = new Queue<int>(orders);

            Console.WriteLine(queOfOrders.Max());

            for (int i = 0; i < orders.Length; i++)
            {
                
                if (amountOfFood >= queOfOrders.Peek())
                {
                    int amountOrder = queOfOrders.Dequeue();
                    amountOfFood -= amountOrder;
                }
                else
                {
                    break;
                }
            }

            if (queOfOrders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(' ', queOfOrders)} ");
            }
        }
    }
}
