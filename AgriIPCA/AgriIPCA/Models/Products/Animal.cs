using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIPCA.Models.Products
{
    [Table("Animals")]
    public class Animal : Product
    {
        public Animal(string name, decimal price) : base(name, price)
        {
            
        }

        public Animal(string name, decimal price, string breed) : base(name, price)
        {
            this.Breed = breed;
        }

        public string Breed { get; set; }
    }
}
