using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIPCA.Models.Products
{
    [Table("Flowers")]
    public class Flower : Plant
    {
        public Flower(string name, decimal price) : base(name, price)
        {
        }

        public string Species { get; set; }

        public string Color { get; set; }
    }
}
