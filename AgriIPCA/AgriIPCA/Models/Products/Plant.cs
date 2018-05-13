using System.ComponentModel.DataAnnotations;

namespace AgriIPCA.Models.Products
{
    public abstract class Plant : Product
    {
        protected Plant()
        {
            
        }

        protected Plant(string name, decimal price, int quantity) : base(name, price, quantity)
        {
        }


        protected Plant(string name, decimal price, int quantity, string species) : base(name, price, quantity)
        {
            this.Species = species;
        }

        [Required]
        public string Species { get; set; }
    }
}
