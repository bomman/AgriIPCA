using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgriIPCA.Models.Products;
using AgriIPCA.Models.Users;

namespace AgriIPCA.Models.Purchases
{
    [Table("Purchases")]
    public class Purchase
    {
        public Purchase()
        {
            
        }

        public Purchase(int productId, int userId, DateTime date, int quantity, decimal price)
        {
            ProductId = productId;
            UserId = userId;
            Date = date;
            Quantity = quantity;
            Price = price;
        }

        
        [Index]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{this.Id};{this.Product.Name}{this.User.Username};{this.Price * this.Quantity}";
        }
    }
}
