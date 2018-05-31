using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace AgriIPCA.Models.Users
{
    [Table("Users")]
    public class User
    {
        public User()
        {
            this.Basket = new Basket();
        }

        public User(string username, string password) : this()
        {
            this.Username = username;
            this.Password = password;
            this.Role = Role.User;
        }

        public User(string username, string password, Role role) : this()
        {
            this.Username = username;
            this.Password = password;
            this.Role = role;
        }

        public User(string username, string password, Role role, string address) : this()
        {
            this.Username = username;
            this.Password = password;
            this.Role = role;
            this.Address = address;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Address { get; set; }

        [Required]
        public Role Role { get; set; }

        [NotMapped]
        public Basket Basket { get; set; }

        public string PrintBasket()
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < this.Basket.Count; i++)
            {
                output.AppendLine($"{i + 1}. {this.Basket[i].ToString()}");
            }

            decimal sum = this.Basket.Sum(p => p.Price * p.Quantity);
            output.AppendLine($"Total: {sum}");

            return output.ToString();
        }

        public string PrintDetails()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Username: {this.Username}");
            output.Append(this.Address == null ? "Address: (no address)" : $"Address: {this.Address}");

            return output.ToString();
        }

        public override string ToString()
        {
            return $"-- {this.Id};{this.Username};{this.Address}";
        }
    }
}
