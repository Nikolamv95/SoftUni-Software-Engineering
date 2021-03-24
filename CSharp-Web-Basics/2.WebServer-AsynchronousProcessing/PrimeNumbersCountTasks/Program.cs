using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PrimeNumbersCountTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();

            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 100; i++)
            {
                var task = Task.Run(()=> DownloadAsync(i));
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine(sw.Elapsed);
            Console.ReadLine();

        }

        private static async Task DownloadAsync(int i)
        {
            HttpClient httpClient = new HttpClient();
            var url = $"https://vicove.com/vic-{i}";
            var httpResponse = await httpClient.GetAsync(url);
            //Try catch works like usual not like the threads
            try
            {
                var vic = await httpResponse.Content.ReadAsStringAsync();
                Console.WriteLine(vic.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
