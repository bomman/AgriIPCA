using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIPCA.Models.Products
{
    [Table("Meat")]
    public class Meat : AnimalProvided
    {
        public Meat(string name, decimal price, DateTime bestBefore) : base(name, price, bestBefore)
        {
        }
    }
}
