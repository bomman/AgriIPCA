using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIPCA.Models.Products
{
    [Table("Tree")]
    public class Tree : Plant
    {
        public Tree(string name, decimal price) : base(name, price)
        {
        }
    }
}
