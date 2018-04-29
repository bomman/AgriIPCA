using System;
using AgriIPCA.Database;
using AgriIPCA.Interfaces;
using AgriIPCA.Models.Users;

namespace AgriIPCA.Core
{
    public class CommandManager : ICommandManager
    {
        private IWriter writer;
        private IReader reader;
        private Warehouse warehouse;
        private Person loggedInUser;

        public CommandManager(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
            this.warehouse = new Warehouse();
        }

        public void PreLogInExecute(int command)
        {
            switch (command)
            {
                case 1:
                    this.writer.Write(this.CreateAccount());
                    break;
                case 2:
                    this.writer.Write(this.Login());
                    break;
                case 3:
                    Environment.Exit(1);
                    break;
                default:
                    throw new Exception("Invalid command.");
            }
        }

        private string CreateAccount()
        {
            this.writer.Write("Username: ");
            string username = this.reader.Read();
            this.writer.Write("Password: ");
            string password = this.reader.Read();
            this.writer.Write("Confirm Password: ");
            string confirmPassword = this.reader.Read();

            if (password != confirmPassword)
            {
                throw  new Exception("Not matching passwords.");
            }

            this.writer.Write("Address: ");
            string address = this.reader.Read();

            Person user = new User(username, password, address);
            this.warehouse.AddPerson(user);

            return "Account successfully created. Now you can enter 2 to login.";
        }

        public string Login()
        {
            this.writer.Write("Username: ");
            string username = this.reader.Read();
            this.writer.Write("Password: ");
            string password = this.reader.Read();

            
            if (!this.warehouse.Persons.ContainsKey(username))
            {
                throw  new Exception("Invalid password or username. Enter 2 to login again.");
            }

            Person targetPerson = this.warehouse.Persons[username];

            if (targetPerson.Password != password)
            {
                throw new Exception("Invalid password or username. Enter 2 to login again.");
            }

            this.loggedInUser = targetPerson;

            return "You have successfully logged in.";
        }
    }
}
