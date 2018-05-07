using System;

namespace AgriIPCA.Models.Products
{
    public abstract class AnimalProvided : EatingProduct
    {
        protected AnimalProvided(string name, DateTime bestBefore) : base(name, bestBefore)
        {
        }
    }
}
