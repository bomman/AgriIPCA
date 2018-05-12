using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgriIPCA.Models.Users
{
    [Table("Users")]
    public class User
    {
        public User()
        {
            
        }

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
            this.Role = Role.User;
        }

        public User(string username, string password, Role role)
        {
            this.Username = username;
            this.Password = password;
            this.Role = role;
        }

        public User(string username, string password, Role role, string address)
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

        public string PrintDetails()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Username: {this.Username}");
            output.Append($"Address: {this.Address}");

            return output.ToString();
        }

        public override string ToString()
        {
            return $"-- {this.Id};{this.Username};{this.Address}";
        }
    }
}
