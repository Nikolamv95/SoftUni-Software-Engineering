using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace HttpDemo
{
    public class Program
    {
        static Dictionary<string, int> SessionStorage = new Dictionary<string, int>();
        const string newLine = "\r\n";

        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 80);
            tcpListener.Start();

            while (true)
            {
                var client = tcpListener.AcceptTcpClient();
                ProcessClientAsync(client);
            }
        }

        public static async Task ProcessClientAsync(TcpClient client)
        {
            await using var stream = client.GetStream();

            byte[] buffer = new byte[1000000];
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            var length = await stream.ReadAsync(buffer, 0, buffer.Length);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            string requestString = Encoding.UTF8.GetString(buffer, 0, length);
            Console.WriteLine(requestString);

            var sid = Guid.NewGuid().ToString();
            var match = Regex.Match(requestString, @"sid=[^\n]*\r\n");
            if (match.Success)
            {
                sid = match.Value.Substring(4);
            }

            if (!SessionStorage.ContainsKey(sid))
            {
                SessionStorage.Add(sid, 0);
            }

            SessionStorage[sid]++;
            var num = SessionStorage[sid];

            string html = $"<h1>Hello from Niki server {DateTime.Now} for the {num} time.</h1>" +
                          $"<form method=post><input name=username /><input name=password />" +
                          $"<input type=submit /></form>" + DateTime.Now;

            string response = "HTTP/1.1 200 OK" + newLine +
                              "Server: NikiServer 2021" + newLine +
                              "Content-Type: text/html; charset=utf-8" + newLine +
                              $"Set-Cookie: sid={sid}; Path=/; Secure; HttpOnly; Max-Age=" + (3 * 60) + newLine +
                              "Content-Lenght: " + html.Length + newLine +
                              newLine +
                              html + newLine;

            byte[] responseBytes = Encoding.UTF8.GetBytes(response);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            await stream.WriteAsync(responseBytes);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine(new string('=', 80));
        }

        public static async Task ReadData()
        {
            Console.OutputEncoding = Encoding.UTF8;

            string url = "https://softuni.bg/";

            HttpClient httpClient = new HttpClient();
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            var html = await httpClient.GetStringAsync(url);
            var response = await httpClient.GetAsync(url);

            var header = string.Join(Environment.NewLine, response.Headers.Select(x => x.Key + ":" + x.Value.First()));

            Console.WriteLine(response.StatusCode);
            Console.WriteLine(header);
        }
    }
}
