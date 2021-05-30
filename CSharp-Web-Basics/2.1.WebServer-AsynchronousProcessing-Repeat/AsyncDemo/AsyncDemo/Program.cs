using System;
using System.Threading.Tasks;

namespace AsyncDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> task = Task.Run(() =>
            {
                var result = 0;
                for (int i = 0; i < 1000; i++)
                {
                    result++;
                    Console.WriteLine($"In Task {i}");
                }

                return result;
            });

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Outside Task {i}");
            }

            task.Wait();
            var taskResult = task.Result;
            Console.WriteLine(taskResult);
        }
    }
}
