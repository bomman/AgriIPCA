using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIPCA.Models.Products
{
    [Table("Fruits")]
    public class Fruit : EatingProduct
    {
        public Fruit(string name, decimal price, DateTime bestBefore) : base(name, price, bestBefore)
        {
        }
    }
}
