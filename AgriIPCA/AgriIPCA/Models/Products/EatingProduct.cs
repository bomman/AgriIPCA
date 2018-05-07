using System;
using AgriIPCA.Interfaces;

namespace AgriIPCA.Models.Products
{
    public abstract class EatingProduct : Product, IPerishable 
    {
        protected EatingProduct(string name, DateTime bestBefore) : base(name)
        {
            this.BestBefore = bestBefore;
        }

        public DateTime BestBefore { get; private set; }
    }
}
