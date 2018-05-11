using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIPCA.Models.Products
{
    [Table("Vegetables")]
    public class Vegatable : EatingProduct
    {
        public Vegatable(string name, decimal price, DateTime bestBefore) : base(name, price, bestBefore)
        {
        }
    }
}
