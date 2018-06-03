using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using AgriIPCA.Database;
using AgriIPCA.Interfaces;
using AgriIPCA.Models.Products;
using Timer = System.Timers.Timer;

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

            
            this.SetDatabaseChecker();

            while (true)
            {
                try
                {
                    if (!isLoggedIn)
                    {
                        this.writer.Write(PrintNotLoggedInMenu());
                        string[] input = this.reader.Read().Split(' ');
                        this.manager.PreLogInExecute(input, ref isLoggedIn);
                    }
                    else
                    {
                        this.writer.Write(PrintLoggedInMenu());
                        string[] input = this.reader.Read().Split(' ');
                        this.manager.LogInExecute(input, ref isLoggedIn);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void SetDatabaseChecker()
        {
            Timer timer = new Timer();
            // every day
            timer.Interval = 1000 * 60 * 60 * 24;
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Enabled = true;
            timer.Start();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            List<EatingProduct> perishedProducts = this.context.Products
                .Select(p => p as EatingProduct)
                .Where(p => p != null)
                .Where(p => p.IsGoneOff == false)
                .Where(p => DateTime.Compare(p.BestBefore, DateTime.Now) < 0)
                .ToList();

            foreach (EatingProduct product in perishedProducts)
            {
                product.GoOff();
            }

            this.context.SaveChangesAsync();
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
            output.AppendLine("2. Buy Products");
            output.AppendLine("3. Profile Details");
            output.AppendLine("4. Admin");
            output.AppendLine("5. Help");
            output.AppendLine("6. Log out");
            output.AppendLine("7. Exit");
            output.AppendLine(" ------------------ ");
            output.Append("Enter the number of command you want to execute: ");

            return output.ToString();
        }
    }
}
