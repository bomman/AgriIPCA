using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIPCA.Models.Products
{
    [Table("Vegetables")]
    public class Vegatable : EatingProduct
    {
        public Vegatable()
        {
            
        }

        public Vegatable(string name, decimal price, int quantity, DateTime bestBefore) : base(name, price, quantity, bestBefore)
        {
        }
    }
}
