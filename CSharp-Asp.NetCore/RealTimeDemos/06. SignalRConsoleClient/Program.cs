using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace SignalRConsoleClient
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.SignalR.Client;
    using Microsoft.Extensions.DependencyInjection;

    public static class Program
    {
        public static async Task Main()
        {

            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44305/coffeehub", options => {
                    var handler = new HttpClientHandler
                    {
                        ClientCertificateOptions = ClientCertificateOption.Manual,
                        ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
                    };
                    options.HttpMessageHandlerFactory = _ => handler;
                })
                .AddMessagePackProtocol()
                .Build();

            connection.On<Order>(
                "NewOrder",
                order => Console.WriteLine($"Somebody ordered {order.Size} {order.Product}"));

            await connection.StartAsync();

            Console.WriteLine("Listening. Press enter to exit...");
            Console.ReadLine();
        }
    }
}
