using System;
using System.Linq;
using System.Text;
using AgriIPCA.Database;
using AgriIPCA.Interfaces;
using AgriIPCA.Models.Products;
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
                    this.writer.Write(this.ListProducts());
                    break;
                case 2:
                    isLoggedIn = true;
                    this.writer.Write(this.OrderProducts());
                    break;
                case 3:
                    isLoggedIn = true;
                    this.writer.Write(this.loggedInUser.PrintDetails());
                    this.writer.Write(this.EditProfile());
                    break;
                case 4:
                    isLoggedIn = true;
                    this.writer.Write(this.ExecuteAdminOperations());
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

        private string ExecuteAdminOperations()
        {
            if (this.loggedInUser.Role == Role.User)
            {
                throw new Exception("Sorry! You do not have access to the admin part.");
            }

            string[] commandArgs;

            while (true)
            {
                this.writer.Write(this.PrintAdminMenu());

                commandArgs = this.reader.Read().Split(' ');
                switch (commandArgs[0].ToLower())
                {
                    // menu
                    case "1":
                    case "list products":
                        this.writer.Write(this.ListProducts());
                        break;
                    case "2":
                    case "list users":
                        this.writer.Write(this.ListUsers());
                        break;
                    case "3":
                    case "help":
                        this.writer.Write(this.AdminHelp());
                        break;
                    case "4":
                    case "back":
                        return "";

                    // hidden commands
                    case "create":
                        if (commandArgs[1] == "product")
                        {
                            this.writer.Write(this.CreateProduct());
                        }
                        else if (commandArgs[1] == "user")
                        {
                            this.writer.Write(this.CreateUser());
                        }
                        else
                        {
                            this.writer.Write("Incorrect command.");
                        }
                        break;
                    case "edit":
                        if (commandArgs[1] == "product")
                        {
                            this.writer.Write(this.EditProduct(int.Parse(commandArgs[2])));
                        }
                        else if (commandArgs[1] == "user")
                        {
                            this.writer.Write(this.EditUser(commandArgs[2]));
                        }
                        else
                        {
                            this.writer.Write("Incorrect command.");
                        }
                        break;
                    case "delete":
                        if (commandArgs[1] == "product")
                        {
                            this.writer.Write(this.DeleteProduct(int.Parse(commandArgs[2])));
                        }
                        else if (commandArgs[1] == "user")
                        {
                            this.writer.Write(this.DeleteUser(commandArgs[2]));
                        }
                        else
                        {
                            this.writer.Write("Incorrect command.");
                        }
                        break;
                }
            }
        }

        private string CreateProduct()
        {
            throw new NotImplementedException();
        }

        private string CreateUser()
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

            return "Account successfully created.";
        }

        private string DeleteProduct(int id)
        {
            Product product = this.context.Products.FirstOrDefault(u => u.Id == id);

            if (product == null)
            {
                return "Not existing product.";
            }

            this.writer.Write(product.ToString());
            this.writer.Write("Do you want to delete the current product? Y/N");
            string confirmation = this.reader.Read().ToLower();

            if (confirmation == "y")
            {
                this.context.Products.Remove(product);
                this.context.SaveChanges();

                return "The product has been successfully deleted.";
            }

            return "";
        }

        private string DeleteUser(string username)
        {
            User user = this.context.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return "Not existing user.";
            }

            this.writer.Write(user.ToString());
            this.writer.Write("Do you want to delete the current user? Y/N");
            string confirmation = this.reader.Read().ToLower();

            if (confirmation == "y")
            {
                this.context.Users.Remove(user);
                this.context.SaveChanges();

                return "The user has been successfully deleted.";
            }

            return "";
        }

        private string EditUser(string username)
        {
            User user = this.context.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return "Not existing user.";
            }

            this.writer.Write(user.ToString());

            this.writer.Write("Username: ");
            string newUsername = this.reader.Read();
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
            user.Username = newUsername;
            user.Password = password;
            user.Address = address;
            this.context.SaveChanges();

            return "The user has been successfully edited.";
        }

        private string EditProduct(int id)
        {
            Product product = this.context.Products.FirstOrDefault(p => id == p.Id);

            if (product == null)
            {
                return "Not existing product";
            }

            this.writer.Write(product.ToString());

            this.writer.Write($"{product.Name}:");
            string newName = this.reader.Read();
            this.writer.Write($"{product.Quantity}: ");
            int newQuantity = int.Parse(this.reader.Read());
            this.writer.Write($"{product.Price}: ");
            decimal newPrice = decimal.Parse(this.reader.Read());

            product.Name = newName;
            product.Quantity = newQuantity;
            product.Price = newPrice;
            this.context.SaveChanges();

            return "Product successfully edited.";
        }

        private string AdminHelp()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("Enter: ");
            output.AppendLine("-- 'list products' or '1' to see a list of all products");
            output.AppendLine("-- 'list users' or '2' to see a list of all users");
            output.AppendLine("-- 'create product' to create a product");
            output.AppendLine("-- 'edit product [product id]' to edit a product");
            output.AppendLine("-- 'delete product [product id]' to delete a product");
            output.AppendLine("-- 'create user' to create a new user");
            output.AppendLine("-- 'edit user [username]' to edit a user");
            output.AppendLine("-- 'delete user [username]' to delete a user");

            return output.ToString();
        }

        private string ListUsers()
        {
            var users = this.context.Users;
            StringBuilder output = new StringBuilder();
            output.AppendLine("All registered users: ");
            foreach (User user in users)
            {
                output.AppendLine(user.ToString());
            }

            return output.ToString();
        }

        private string PrintAdminMenu()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("1. List products");
            output.AppendLine("2. List users");
            output.AppendLine("3. Help");
            output.Append("4. Back to Main Menu");

            return output.ToString();
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

        private string OrderProducts()
        {
            throw new NotImplementedException();
        }

        private string ListProducts()
        {
            var products = this.context.Products;
            StringBuilder output = new StringBuilder();
            output.AppendLine("Currently available products: ");
            output.AppendLine("Name\tQuantity\tPrice");
            foreach (Product product in products)
            {
                output.AppendLine(product.ToString());
            }

            return output.ToString();
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

        private string Login()
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
