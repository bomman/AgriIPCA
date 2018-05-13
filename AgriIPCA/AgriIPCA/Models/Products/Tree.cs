using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIPCA.Models.Products
{
    [Table("Tree")]
    public class Tree : Plant
    {
        public Tree()
        {  
        }

        public Tree(string name, decimal price, int quantity) : base(name, price, quantity)
        {
        }


        public Tree(string name, decimal price, int quantity, string species) : base(name, price, quantity, species)
        {
        }
    }
}
