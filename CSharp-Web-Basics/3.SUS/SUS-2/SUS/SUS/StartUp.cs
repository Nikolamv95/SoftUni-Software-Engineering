using MyWebServer.Server;
using System.Threading.Tasks;

namespace MyWebServer
{
    class StartUp
    {
        static async Task Main(string[] args)
        {
            var server = new HttpServer("127.0.0.1", 8080);
            await server.Start();
        }
    }
}