using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIPCA.Models.Products
{
    public abstract class Product
    {
        protected Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{this.Name} - {this.Price}";
        }
    }
}
