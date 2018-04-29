using AgriIPCA.Core;
using AgriIPCA.Interfaces;
using AgriIPCA.IO;

namespace AgriIPCA
{
    class Program
    {
        static void Main(string[] args)
        {
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();
            
            IEngine engine = new Engine(writer, reader);
            engine.Run();
        }
    }
}
