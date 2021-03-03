using VehiclesV2.Contracts;
using VehiclesV2.Core;
using VehiclesV2.IO;
using VehiclesV2.IO.Contracts;

namespace VehiclesV2
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
