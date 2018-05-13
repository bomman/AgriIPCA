using System;
using System.Globalization;
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
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly AgriIPCAContext context;
        private User loggedInUser;

        public CommandManager(IWriter writer, IReader reader, AgriIPCAContext context)
        {
            this.writer = writer;
            this.reader = reader;
            this.context = new AgriIPCAContext();
        }

        #region  Logged In
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
                    this.writer.Write(this.BuyProducts());
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

                commandArgs = this.reader.Read().ToLower().Split(' ');
                switch (commandArgs[0])
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
                        if (commandArgs[1] == "user")
                        {
                            this.writer.Write(this.CreateUser());
                        }
                        else
                        {
                            this.writer.Write(this.CreateProduct(commandArgs[1]));
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

        private string CreateProduct(string typeOfProduct)
        {
            switch (typeOfProduct)
            {
                case "animal":
                    return this.CreateAnimal();
                case "cereals":
                    return this.CreateCerials();
                case "dairy":
                    return this.CreateDairyProduct();
                case "flower":
                    return this.CreateFlower();
                case "fruit":
                    return this.CreateFuit();
                case "meat":
                    return this.CreateMeat();
                case "tree":
                    return this.CreateTree();
                case "vegetable":
                    return this.CreateVegetable();
                default:
                    return "Not valid command.";
            }
        }

        private string CreateFuit()
        {
            this.writer.Write("Name: ");
            string name = this.reader.Read();
            this.writer.Write("Price: ");
            decimal price = decimal.Parse(this.reader.Read());
            this.writer.Write("Quantity: ");
            int quantity = int.Parse(this.reader.Read());
            this.writer.Write("Best Before(inserted date should be in format 'dd/mm/yyyy'): ");
            DateTime bestBefore = DateTime.ParseExact(this.reader.Read(), "dd/mm/yyyy", CultureInfo.InvariantCulture);

            Fruit fruit = new Fruit(name, price, quantity, bestBefore);
            this.context.Products.Add(fruit);
            this.context.SaveChanges();

            return "The fruit has been successfully added to the database";
        }

        private string CreateTree()
        {
            this.writer.Write("Name: ");
            string name = this.reader.Read();
            this.writer.Write("Price: ");
            decimal price = decimal.Parse(this.reader.Read());
            this.writer.Write("Quantity: ");
            int quantity = int.Parse(this.reader.Read());
            this.writer.Write("Species: ");
            string species = this.reader.Read();

            Tree tree = new Tree(name, price, quantity, species);
            this.context.Products.Add(tree);
            this.context.SaveChanges();

            return "The tree has been successfully added to the database";
        }

        private string CreateVegetable()
        {
            this.writer.Write("Name: ");
            string name = this.reader.Read();
            this.writer.Write("Price: ");
            decimal price = decimal.Parse(this.reader.Read());
            this.writer.Write("Quantity: ");
            int quantity = int.Parse(this.reader.Read());
            this.writer.Write("Best Before(inserted date should be in format 'dd/mm/yyyy'): ");
            DateTime bestBefore = DateTime.ParseExact(this.reader.Read(), "dd/mm/yyyy", CultureInfo.InvariantCulture);

            Vegatable vegatable = new Vegatable(name, price, quantity, bestBefore);
            this.context.Products.Add(vegatable);
            this.context.SaveChanges();

            return "The vegetable has been successfully added to the database";
        }

        private string CreateMeat()
        {
            this.writer.Write("Name: ");
            string name = this.reader.Read();
            this.writer.Write("Price: ");
            decimal price = decimal.Parse(this.reader.Read());
            this.writer.Write("Quantity: ");
            int quantity = int.Parse(this.reader.Read());
            this.writer.Write("Best Before(inserted date should be in format 'dd/mm/yyyy'): ");
            DateTime bestBefore = DateTime.ParseExact(this.reader.Read(), "dd/mm/yyyy", CultureInfo.InvariantCulture);

            Meat meat = new Meat(name, price, quantity, bestBefore);
            this.context.Products.Add(meat);
            this.context.SaveChanges();

            return "The meat has been successfully added to the database";
        }

        private string CreateFlower()
        {
            this.writer.Write("Name: ");
            string name = this.reader.Read();
            this.writer.Write("Price: ");
            decimal price = decimal.Parse(this.reader.Read());
            this.writer.Write("Quantity: ");
            int quantity = int.Parse(this.reader.Read());
            this.writer.Write("Species: ");
            string species = this.reader.Read();

            Flower flower = new Flower(name, price, quantity, species);
            this.context.Products.Add(flower);
            this.context.SaveChanges();

            return "The flower has been successfully added to the database";
        }

        private string CreateDairyProduct()
        {
            this.writer.Write("Name: ");
            string name = this.reader.Read();
            this.writer.Write("Price: ");
            decimal price = decimal.Parse(this.reader.Read());
            this.writer.Write("Quantity: ");
            int quantity = int.Parse(this.reader.Read());
            this.writer.Write("Best Before(inserted date should be in format 'dd/mm/yyyy'): ");
            DateTime bestBefore = DateTime.ParseExact(this.reader.Read(), "dd/mm/yyyy", CultureInfo.InvariantCulture);

            DairyProduct dairy = new DairyProduct(name, price, quantity, bestBefore);
            this.context.Products.Add(dairy);
            this.context.SaveChanges();

            return "The dairy product has been successfully added to the database";
        }

        private string CreateCerials()
        {
            this.writer.Write("Name: ");
            string name = this.reader.Read();
            this.writer.Write("Price: ");
            decimal price = decimal.Parse(this.reader.Read());
            this.writer.Write("Quantity: ");
            int quantity = int.Parse(this.reader.Read());

            Cereals cereals = new Cereals(name, price, quantity);
            this.context.Products.Add(cereals);

            return "The cereals have been successfully added to the database";
        }

        private string CreateAnimal()
        {
            this.writer.Write("Name: ");
            string name = this.reader.Read();
            this.writer.Write("Price: ");
            decimal price = decimal.Parse(this.reader.Read());
            this.writer.Write("Quantity: ");
            int quantity = int.Parse(this.reader.Read());
            this.writer.Write("Breed: ");
            string breed = this.reader.Read();

            Animal animal = new Animal(name, price, quantity, breed);
            this.context.Products.Add(animal);
            this.context.SaveChanges();

            return "The animal has been successfully added to the database";
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
            output.AppendLine("-- 'create [type of  product]' to create a product");
            output.AppendLine("-- 'edit product [product id]' to edit a product");
            output.AppendLine("-- 'delete product [product id]' to delete a product");
            output.AppendLine("-- 'create user' to create a new user");
            output.AppendLine("-- 'edit user [username]' to edit a user");
            output.AppendLine("-- 'delete user [username]' to delete a user");
            output.Append(new string('-', 30));

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

        private string BuyProducts()
        {
            this.writer.Write(this.ListProducts());
            this.writer.Write("What would you like to order? Enter the code of the product: ");
            int id = int.Parse(this.reader.Read());

            Product product = this.context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new Exception("Not found product.");
            }

            this.writer.Write("What quantity do you want?");
            int quantity = int.Parse(this.reader.Read());

            if (quantity > product.Quantity)
            {
                throw new Exception($"Sorry! We dont have enough from this product. You can order maximum {product.Quantity}.");
            }

            BasketItem newItem = new BasketItem(product.Id, product.Name, quantity, product.Price);
            this.loggedInUser.Basket.Add(newItem);
            this.writer.Write(this.loggedInUser.PrintBasket());

            this.writer.Write("Would you like to order another product? Y/N");
            string agreement = this.reader.Read().ToLower();

            if (agreement == "y")
            {
                this.BuyProducts();
            }
            else
            {
                this.writer.Write("Order details: ");
                this.writer.Write(this.loggedInUser.PrintBasket());
                this.writer.Write("Do you confirm your order? Y/N");
                string confirmation = this.reader.Read().ToLower();

                if (confirmation == "n")
                {
                    this.BuyProducts();
                }
                else
                {
                    foreach (BasketItem basketProduct in this.loggedInUser.Basket)
                    {
                        Product databaseProduct = this.context.Products.FirstOrDefault(p => p.Id == basketProduct.ProductId);
                        databaseProduct.Quantity -= basketProduct.Quantity;
                    }

                    this.context.SaveChanges();
                    this.loggedInUser.Basket.Clear();

                    return "You have successfully ordered your products.";
                }
            }

            return "";
        }

        private string ListProducts()
        {
            var products = this.context.Products;
            StringBuilder output = new StringBuilder();
            output.AppendLine("Currently available products: ");
            output.AppendLine("Id\tName\tQuantity\tPrice");
            foreach (Product product in products)
            {
                output.AppendLine(product.ToString());
            }

            return output.ToString();
        }

        #endregion

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

            //TODO: add check for the username

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