using System;

namespace AgriIPCA.Models.Products
{
    public class Meat : AnimalProvided
    {
        public Meat(string name, DateTime bestBefore) : base(name, bestBefore)
        {
        }
    }
}
