using System;
using System.Linq;
using AgriIPCA.Database;
using AgriIPCA.Interfaces;
using AgriIPCA.Models.Users;

namespace AgriIPCA.Core
{
    public class CommandManager : ICommandManager
    {
        private IWriter writer;
        private IReader reader;
        private AgriIPCAContext context;
        private User loggedInUser;

        public CommandManager(IWriter writer, IReader reader, AgriIPCAContext context)
        {
            this.writer = writer;
            this.reader = reader;
            this.context = new AgriIPCAContext();
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

            //update user details
            this.loggedInUser.Username = username;
            this.loggedInUser.Password = password;
            this.loggedInUser.Address = address;
            this.context.SaveChanges();

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

            User user = new User(username, password, Role.User, address);
            this.context.Users.Add(user);
            this.context.SaveChanges();

            return "Account successfully created. Now you can enter 2 to login.";
        }

        public string Login()
        {
            this.writer.Write("Username: ");
            string username = this.reader.Read();
            this.writer.Write("Password: ");
            string password = this.reader.Read();

            User targetPerson = this.context.Users.FirstOrDefault(user => user.Username == username);
            if (targetPerson == null)
            {
                throw new Exception("Invalid password or username. Enter 2 to login again.");
            }

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
