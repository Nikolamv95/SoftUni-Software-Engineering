using Telephony.Contracts;
using Telephony.Core;
using Telephony.IO;

namespace Telephony
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter wrietr = new ConsoleWriter();
            Engine engine = new Engine(reader, wrietr);
            engine.Run();
        }
    }
}
