using System;

namespace AgriIPCA.Models.Products
{
    public abstract class AnimalProvided : EatingProduct
    {
        protected AnimalProvided(string name, decimal price, DateTime bestBefore) : base(name, price, bestBefore)
        {
        }
    }
}
