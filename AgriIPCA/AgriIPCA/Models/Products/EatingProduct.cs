using System;
using System.ComponentModel.DataAnnotations.Schema;
using AgriIPCA.Interfaces;

namespace AgriIPCA.Models.Products
{
    [Table("EatingProducts")]
    public abstract class EatingProduct : Product, IPerishable 
    {
        protected EatingProduct()
        {
            
        }

        protected EatingProduct(string name, decimal price, int quantity) : base(name, price, quantity)
        {
        }

        protected EatingProduct(string name, decimal price, int quantity, DateTime bestBefore) : base(name, price, quantity)
        {
            this.BestBefore = bestBefore;
        }

        public DateTime BestBefore { get; set; }
    }
}
