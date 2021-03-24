using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HttpDemo
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            const string newLine = "\r\n";

            //1-Open port
            //My machine to be a server with port 80
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 12345);
            //2- start to receive information
            tcpListener.Start();

            while (true)
            {
                //3-Get the client
                var client = tcpListener.AcceptTcpClient();
                //4-Get the stream of it
                using (
                    var stream = client.GetStream())
                {
                    //5-Real the info from the client
                    byte[] buffer = new byte[1000000];
                    var lenght = stream.Read(buffer, 0, buffer.Length);

                    //6-convert tha data from bytes ti string
                    string requestString = Encoding.UTF8.GetString(buffer, 0, lenght);
                    //7-write it on the console
                    Console.WriteLine(requestString);

                    //8-Our server returns a respond GET
                    string html = $"<h1>Hello from Niki server {DateTime.Now}</h1>" +
                                  $"<form method=post><input name=username /><input name=password />" +
                                  $"<input type=submit /></form>";

                    //8-Our server returns a respond POST
                    //string html = $"<h1>Hello from Niki server {DateTime.Now}</h1>" + 
                    //              $"<form><input name=username /><input name=password />" +
                    //              $"<input type=submit /></form>";

                    //200 OK
                    //string response = "HTTP/1.1 200 OK" + newLine +
                    //                  "Server: NikiServer 2021" + newLine +
                    //                  "Content-Type: text/html; charset=utf-8" + newLine +
                    //                  "Content-Lenght: " + html.Length + newLine +
                    //                  newLine +
                    //                  html
                    //                  + newLine;

                    //307 Redirect
                    //string response = "HTTP/1.1 307 Redirect" + newLine +
                    //                  "Server: NikiServer 2021" + newLine +
                    //                  "Location: https://softuni.bg" + newLine +
                    //                  "Content-Type: text/html; charset=utf-8" + newLine +
                    //                  "Content-Lenght: " + html.Length + newLine +
                    //                  newLine +
                    //                  html + newLine;

                    //200 OK PNG
                    //string response = "HTTP/1.1 200 OK" + newLine +
                    //                  "Server: NikiServer 2021" + newLine +
                    //                  "Content-Type: image/png; charset=utf-8" + newLine +
                    //                  "Content-Lenght: " + html.Length + newLine +
                    //                  newLine +
                    //                  html
                    //                  + newLine;

                    ////200 OK TEXT
                    //string response = "HTTP/1.1 200 OK" + newLine +
                    //                  "Server: NikiServer 2021" + newLine +
                    //                  "Content-Type: text/plain; charset=utf-8" + newLine +
                    //                  "Content-Lenght: " + html.Length + newLine +
                    //                  newLine +
                    //                  html
                    //                  + newLine;

                    //200 OK XML
                    //string response = "HTTP/1.1 200 OK" + newLine +
                    //                  "Server: NikiServer 2021" + newLine +
                    //                  "Content-Type: application/xml; charset=utf-8" + newLine +
                    //                  "Content-Lenght: " + html.Length + newLine +
                    //                  newLine +
                    //                  html
                    //                  + newLine;

                    //200 OK XML
                    //string response = "HTTP/1.1 200 OK" + newLine +
                    //                  "Server: NikiServer 2021" + newLine +
                    //                  "Content-Type: application/xml; charset=utf-8" + newLine +
                    //                  "Content-Lenght: " + html.Length + newLine +
                    //                  newLine +
                    //                  html
                    //                  + newLine;

                    //Content Disposition -> attach and download file
                    //string response = "HTTP/1.1 200 OK" + newLine +
                    //                  "Server: NikiServer 2021" + newLine +
                    //                  "Content-Type: text/html; charset=utf-8" + newLine +
                    //                  "Content-Disposition: attachment; filename=niki.txt" + newLine +
                    //                  "Content-Lenght: " + html.Length + newLine +
                    //                  newLine +
                    //                  html
                    //                  + newLine;

                    //200 OK FORM
                    string response = "HTTP/1.1 200 OK" + newLine +
                                      "Server: NikiServer 2021" + newLine +
                                      "Content-Type: text/html; charset=utf-8" + newLine +
                                      "Content-Lenght: " + html.Length + newLine +
                                      newLine +
                                      html
                                      + newLine;


                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);

                    stream.Write(responseBytes);

                    Console.WriteLine(new string('=', 80));
                }
                
            }
        }

        public static async Task ReadData()
        {
            //This is a GET Request in which we want to take the HTML of a URL
            Console.OutputEncoding = Encoding.UTF8;

            string url = "https://softuni.bg/";

            HttpClient httpClient = new HttpClient();

            var html = await httpClient.GetStringAsync(url);
            var response = await httpClient.GetAsync(url);
            var header = string.Join(Environment.NewLine, response.Headers.Select(x => x.Key + ":" + x.Value.First()));

            Console.WriteLine(response.StatusCode);
            Console.WriteLine(header);
        }
    }
}
