using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgriIPCA.Models.Products
{
    public abstract class Product
    {
        protected Product()
        {
            
        }

        protected Product(string name, decimal price, int quantity)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public virtual string Details()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(new string('-', 20));
            output.AppendLine("\tDetails\t");
            output.AppendLine(new string('-', 20));

            output.AppendLine($"Id: {this.Id}");
            output.AppendLine($"Name: {this.Name}");
            output.AppendLine($"Quantity: {this.Quantity}");
            output.AppendLine($"Price: {this.Price}");
            output.AppendLine(this.Description == null
                ? "Description: (no description)"
                : $"Description: {this.Description}");

            return output.ToString();
        }

        public override string ToString()
        {
            return $"-- {this.Id};{this.Name};{this.Quantity};{this.Price}";
        }
    }
}
