using System;
using AgriIPCA.Interfaces;

namespace AgriIPCA.IO
{
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            string input = Console.ReadLine();

            return input;
        }
    }
}
