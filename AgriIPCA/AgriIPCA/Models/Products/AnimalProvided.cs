using System;

namespace AgriIPCA.Models.Products
{
    public abstract class AnimalProvided : EatingProduct
    {
        protected AnimalProvided()
        {
            
        }

        protected AnimalProvided(string name, decimal price, int quantity, DateTime bestBefore) : base(name, price, quantity, bestBefore)
        {
        }
    }
}
