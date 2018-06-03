using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIPCA.Models.Products
{
    public enum MeatKind
    {
        Other, Pork, Beef, Goat, Lamb, Chicken, Seafood
    }

    [Table("Meat")]
    public class Meat : AnimalProvided
    {
        public Meat()
        {
            
        }

        public Meat(string name, decimal price, int quantity, DateTime bestBefore) : base(name, price, quantity, bestBefore)
        {
            this.Kind = MeatKind.Other;
        }

        public Meat(string name, decimal price, int quantity, DateTime bestBefore, MeatKind kind) : base(name, price, quantity, bestBefore)
        {
            this.Kind = kind;
        }

        public MeatKind Kind { get; set; }
    }
}
