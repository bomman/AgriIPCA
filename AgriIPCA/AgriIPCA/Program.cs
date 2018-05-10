using AgriIPCA.Core;
using AgriIPCA.Database;
using AgriIPCA.Interfaces;
using AgriIPCA.IO;
using AgriIPCA.Models.Users;

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
