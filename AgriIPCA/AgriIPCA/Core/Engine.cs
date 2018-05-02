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
        private bool isLoggedIn;

        public Engine(IWriter writer, IReader reader)
        {
            this.manager = new CommandManager(writer, reader);
            this.writer = writer;
            this.reader = reader;
        }

        public void Run()
        {
           isLoggedIn = false;

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
            output.AppendLine("1. List Stocks");
            output.AppendLine("2. Order Stocks");
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
