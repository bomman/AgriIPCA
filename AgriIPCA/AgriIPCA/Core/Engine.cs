using System;
using System.Text;
using AgriIPCA.Database;
using AgriIPCA.Interfaces;

namespace AgriIPCA.Core
{
    public class Engine : IEngine
    {
        private ICommandManager manager;
        private AgriIPCAContext context;
        private IWriter writer;
        private IReader reader;
        private bool isLoggedIn;

        public Engine(IWriter writer, IReader reader)
        {
            this.context = new AgriIPCAContext();
            this.manager = new CommandManager(writer, reader, this.context);
            this.writer = writer;
            this.reader = reader;
            isLoggedIn = false;
        }

        public void Run()
        {
            if (!this.context.Database.Exists())
            {
                this.writer.Write("Creating database...");
                this.context.Database.Initialize(true);
            }

            while (true)
            {
                try
                {
                    if (!isLoggedIn)
                    {
                        this.writer.Write(PrintNotLoggedInMenu());
                        int input = int.Parse(this.reader.Read());
                        this.manager.PreLogInExecute(input, out isLoggedIn);
                    }
                    else
                    {
                        this.writer.Write(PrintLoggedInMenu());
                        int input = int.Parse(this.reader.Read());
                        this.manager.LogInExecute(input, out isLoggedIn);
                    }
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


            output.AppendLine(" -----  Menu  ----- ");
            output.AppendLine("1. Create Account");
            output.AppendLine("2. Login");
            output.AppendLine("3. Exit");
            output.AppendLine(" ------------------ ");
            output.Append("Enter the number of command you want to execute: ");

            return output.ToString();
        }

        private string PrintLoggedInMenu()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine(" -----  Menu  ----- ");
            output.AppendLine("1. List Products");
            output.AppendLine("2. Order Products");
            output.AppendLine("3. Profile Details");
            output.AppendLine("4. Admin");
            output.AppendLine("5. Log out");
            output.AppendLine("6. Exit");
            output.AppendLine(" ------------------ ");
            output.Append("Enter the number of command you want to execute: ");

            return output.ToString();
        }
    }
}
