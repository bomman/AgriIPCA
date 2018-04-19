using System.Text;

namespace AgriIPCA.Models.Users
{
    public abstract class Person
    {
        protected Person(string username, string password, string address)
        {
            this.Username = username;
            this.Password = password;
            this.Address = address;
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Username: {this.Username}");
            output.AppendLine($"Address: {this.Address}");

            return output.ToString();

        }
    }
}
