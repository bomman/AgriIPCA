using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIPCA.Models.Products
{
    [Table("Cereals")]
    public class Cereals : Product
    {
        public Cereals(string name, decimal price) : base(name, price)
        {
            
        }
    }
}
