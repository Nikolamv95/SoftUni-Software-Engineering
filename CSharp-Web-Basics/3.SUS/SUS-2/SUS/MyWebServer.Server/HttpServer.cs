using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MyWebServer.Server.Http;

namespace MyWebServer.Server
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener listener;

        public HttpServer(string ipAddress, int port)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;
            this.listener = new TcpListener(this.ipAddress, this.port);
        }

        public async Task Start()
        {
            this.listener.Start();

            Console.WriteLine($"Server started on port {port}");
            Console.WriteLine($"Listening for requests...");

            while (true)
            {
                var connection = await this.listener.AcceptTcpClientAsync();
                var networkStream = connection.GetStream();

                var requestText = await this.ReadRequest(networkStream);
                var request = HttpRequest.Parse(requestText);
                Console.WriteLine(requestText);

                await this.WriteResponse(networkStream);
                connection.Close();
            }
        }

        private async Task<string> ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var totalBytes = 0;

            var buffer = new byte[bufferLength];
            var requestBuilder = new StringBuilder();

            while (networkStream.DataAvailable)
            {
                var bytesRead = await networkStream.ReadAsync(buffer, 0, bufferLength);
                totalBytes += bytesRead;

                if (totalBytes > 10 * 1024)
                {
                    throw new InvalidOperationException("Request is to large!");
                }

                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }

            return requestBuilder.ToString();
        }

        private async Task WriteResponse(NetworkStream networkStream)
        {
            var content = @"
<html>
<head>
</head>
<body>
<h1>Hello from my server!<h1>
</body>
</html>";

            var contentLength = Encoding.UTF8.GetByteCount(content);

            var response = $@"HTTP1/1 200 OK
Server: My Web Server
Date: {DateTime.UtcNow:r}
Content-length: {contentLength}
Content-Type: text/html; charset=UTF-8

{content}";

            var responseBytes = Encoding.UTF8.GetBytes(response);
            await networkStream.WriteAsync(responseBytes);
        }
    }
}
