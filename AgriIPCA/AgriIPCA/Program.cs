using AgriIPCA.Core;
using AgriIPCA.Interfaces;

namespace AgriIPCA
{
    class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
