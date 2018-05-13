using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIPCA.Models.Products
{
    [Table("Flowers")]
    public class Flower : Plant
    {
        public Flower()
        {
            
        }

        public Flower(string name, decimal price, int quantity) : base(name, price, quantity)
        {
        }


        public Flower(string name, decimal price, int quantity, string species) : base(name, price, quantity, species)
        {
        }

        public string Color { get; set; }
    }
}
