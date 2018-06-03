using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgriIPCA.Models.Products
{
    [Table("Animals")]
    public class Animal : Product
    {
        public Animal() : base()
        {
            
        }

        public Animal(string name, decimal price, int quantity) : base(name, price, quantity)
        {
            
        }

        public Animal(string name, decimal price, int quantity, string breed) : base(name, price, quantity)
        {
            this.Breed = breed;
        }

        public string Breed { get; set; }

        public override string Details()
        {
            StringBuilder output = new StringBuilder(base.Details());
            output.AppendLine($"Breed: {this.Breed}");

            return output.ToString();
        }
    }
}
