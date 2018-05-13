using System.ComponentModel.DataAnnotations;

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

        public override string ToString()
        {
            return $"-- {this.Id};{this.Name};{this.Quantity};{this.Price}";
        }
    }
}
