using System;
using AgriIPCA.Interfaces;

namespace AgriIPCA.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string output)
        {
            Console.WriteLine(output);
        }
    }
}
