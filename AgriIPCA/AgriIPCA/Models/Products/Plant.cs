using System.ComponentModel.DataAnnotations;
using System.Text;

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

        public override string Details()
        {
            StringBuilder output = new StringBuilder(base.Details());
            output.AppendLine($"Species: {this.Species}");

            return output.ToString();
        }
    }
}
