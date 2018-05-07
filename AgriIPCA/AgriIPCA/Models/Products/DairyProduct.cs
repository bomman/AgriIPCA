using System;

namespace AgriIPCA.Models.Products
{
    public class DairyProduct : AnimalProvided
    {
        public DairyProduct(string name, DateTime bestBefore) : base(name, bestBefore)
        {
        }
    }
}
