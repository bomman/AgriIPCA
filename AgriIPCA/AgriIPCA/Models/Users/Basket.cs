using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AgriIPCA.Models.Users
{
    [NotMapped]
    public class Basket : IEnumerable<BasketItem>
    {
        private IList<BasketItem> basket;

        public Basket()
        {
            this.basket = new List<BasketItem>();
        }

        public BasketItem this[int index]
        {
            get
            {
                return this.basket[index];
            }
            set
            {
                this.basket[index] = value;
            }
        }

        public int Count => this.basket.Count;

        public IEnumerator<BasketItem> GetEnumerator()
        {
            return this.basket.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(BasketItem newItem)
        {
            if (newItem == null)
            {
                throw new Exception("Basket item is null.");
            }

            BasketItem item = this.basket
                .FirstOrDefault(p => p.ProductId == newItem.ProductId);
            if (item == null)
            {
                this.basket.Add(newItem);
            }
            else
            {
                item.Quantity += newItem.Quantity;
            }
        }

        public void Clear()
        {
            this.basket.Clear();
        }
    }
}
