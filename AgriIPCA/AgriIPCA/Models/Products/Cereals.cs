using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIPCA.Models.Products
{
    [Table("Cereals")]
    public class Cereals : Product
    {
        public Cereals()
        {
            
        }

        public Cereals(string name, decimal price, int quantity) : base(name, price, quantity)
        {
            
        }
    }
}
