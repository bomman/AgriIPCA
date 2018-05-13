using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIPCA.Models.Users
{
    [NotMapped]
    public class BasketItem
    {
        public BasketItem(int productId, string productName, int quantity, decimal price)
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{ProductName} - {this.Quantity} x {this.Price} euros";
        }
    }
}
