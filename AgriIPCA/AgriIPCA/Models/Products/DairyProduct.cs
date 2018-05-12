using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIPCA.Models.Products
{
    [Table("DairyProducts")]
    public class DairyProduct : AnimalProvided
    {
        public DairyProduct()
        {
            
        }

        public DairyProduct(string name, decimal price, int quantity, DateTime bestBefore) : base(name, price, quantity, bestBefore)
        {
        }
    }
}
