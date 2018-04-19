using System;
using AgriIPCA.Interfaces;

namespace AgriIPCA.Core
{
    public class Engine : IEngine
    {
        private ICommandManager manager;

        public Engine()
        {
            this.manager = new CommandManager();  
        }

        public void Run()
        {
            PrintNotLoggedInMenu();

            while (true)
            {
                try
                {
                    int input = int.Parse(Console.ReadLine());
                    this.manager.PreLogInExecute(input);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }

        private void PrintNotLoggedInMenu()
        {
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Enter the number of command you want to execute: ");
        }
    }
}
