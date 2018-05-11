using System;
using System.ComponentModel.DataAnnotations.Schema;
using AgriIPCA.Interfaces;

namespace AgriIPCA.Models.Products
{
    [Table("EatingProducts")]
    public abstract class EatingProduct : Product, IPerishable 
    {
        protected EatingProduct(string name, decimal price) : base(name, price)
        {
        }

        protected EatingProduct(string name, decimal price, DateTime bestBefore) : base(name, price)
        {
            this.BestBefore = bestBefore;
        }

        public DateTime BestBefore { get; set; }
    }
}
