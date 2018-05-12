using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIPCA.Models.Products
{
    [Table("Fruits")]
    public class Fruit : EatingProduct
    {
        public Fruit()
        {
            
        }

        public Fruit(string name, decimal price, int quantity, DateTime bestBefore) : base(name, price, quantity, bestBefore)
        {
        }
    }
}
