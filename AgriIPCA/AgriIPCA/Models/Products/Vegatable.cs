using System;

namespace AgriIPCA.Models.Products
{
    public class Vegatable : EatingProduct
    {
        public Vegatable(string name, DateTime bestBefore) : base(name, bestBefore)
        {
        }
    }
}
