using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIPCA.Models.Products
{
    [Table("DairyProducts")]
    public class DairyProduct : AnimalProvided
    {
        public DairyProduct(string name, decimal price, DateTime bestBefore) : base(name, price, bestBefore)
        {
        }
    }
}
