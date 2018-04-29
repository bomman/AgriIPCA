using System;
using System.Text;
using AgriIPCA.Interfaces;

namespace AgriIPCA.Core
{
    public class Engine : IEngine
    {
        private ICommandManager manager;
        private IWriter writer;
        private IReader reader;

        public Engine(IWriter writer, IReader reader)
        {
            this.manager = new CommandManager(writer, reader);
            this.writer = writer;
            this.reader = reader;
        }

        public void Run()
        {
            this.writer.Write(PrintNotLoggedInMenu());

            while (true)
            {
                try
                {
                    int input = int.Parse(this.reader.Read());
                    this.manager.PreLogInExecute(input);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private string PrintNotLoggedInMenu()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine("1. Create Account");
            output.AppendLine("2. Login");
            output.AppendLine("3. Exit");
            output.Append("Enter the number of command you want to execute: ");

            return output.ToString();
        }
    }
}
