using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIPCA.Models.Products
{
    [Table("Meat")]
    public class Meat : AnimalProvided
    {
        public Meat()
        {
            
        }

        public Meat(string name, decimal price, int quantity, DateTime bestBefore) : base(name, price, quantity, bestBefore)
        {
        }
    }
}
