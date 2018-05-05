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

        public void LogInExecute(int command, out bool isLoggedIn)
        {
            switch (command)
            {
                case 1:
                    isLoggedIn = true;
                    this.writer.Write(this.ListStocks());
                    break;
                case 2:
                    isLoggedIn = true;
                    this.writer.Write(this.OrderStocks());
                    break;
                case 3:
                    isLoggedIn = true;
                    this.writer.Write(this.loggedInUser.PrintDetails());
                    this.writer.Write(this.EditProfile());
                    break;
                case 4:
                    isLoggedIn = true;
                    // TODO: some admin stuffs
                    break;
                case 5:
                    this.writer.Write("You have successfully logged out.");
                    isLoggedIn = false;
                    break;
                case 6:
                    isLoggedIn = false;
                    Environment.Exit(1);
                    break;
                default:
                    isLoggedIn = true;
                    throw new Exception("Invalid command.");
            }
        }

        private string EditProfile()
        {
            this.writer.Write("Do you want to edit your pofile? Y/N");
            string input = this.reader.Read().ToLower();

            if (input == "n")
            {
                throw new Exception("");
            }

            this.writer.Write("Username: ");
            string username = this.reader.Read();
            this.writer.Write("Password: ");
            string password = this.reader.Read();
            this.writer.Write("Confirm Password: ");
            string confirmPassword = this.reader.Read();

            if (password != confirmPassword)
            {
                throw new Exception("Not matching passwords.");
            }

            this.writer.Write("Address: ");
            string address = this.reader.Read();

            this.loggedInUser = this.warehouse.UpdateUser(this.loggedInUser, username, password, address);

            return "Your profile has been successfully edited.";
        }

        private string OrderStocks()
        {
            throw new NotImplementedException();
        }

        private string ListStocks()
        {
            throw new NotImplementedException();
        }

        #region Not Logged In

        public void PreLogInExecute(int command, out bool isLoggedIn)
        {
            switch (command)
            {
                case 1:
                    this.writer.Write(this.CreateAccount());
                    isLoggedIn = false;
                    break;
                case 2:
                    this.writer.Write(this.Login());
                    isLoggedIn = true;
                    break;
                case 3:
                    isLoggedIn = false;
                    Environment.Exit(1);
                    break;
                default:
                    isLoggedIn = false;
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
                throw new Exception("Not matching passwords.");
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
                throw new Exception("Invalid password or username. Enter 2 to login again.");
            }

            Person targetPerson = this.warehouse.Persons[username];

            if (targetPerson.Password != password)
            {
                throw new Exception("Invalid password or username. Enter 2 to login again.");
            }

            this.loggedInUser = targetPerson;

            return "You have successfully logged in.";
        }

        #endregion
    }
}
