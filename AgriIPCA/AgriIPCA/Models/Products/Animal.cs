using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIPCA.Models.Products
{
    [Table("Animals")]
    public class Animal : Product
    {
        public Animal() : base()
        {
            
        }

        public Animal(string name, decimal price, int quantity) : base(name, price, quantity)
        {
            
        }

        public Animal(string name, decimal price, int quantity, string breed) : base(name, price, quantity)
        {
            this.Breed = breed;
        }

        public string Breed { get; set; }
    }
}
