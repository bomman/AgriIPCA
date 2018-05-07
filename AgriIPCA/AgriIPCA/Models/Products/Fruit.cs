using System;

namespace AgriIPCA.Models.Products
{
    public class Fruit : EatingProduct
    {
        public Fruit(string name, DateTime bestBefore) : base(name, bestBefore)
        {
        }
    }
}
