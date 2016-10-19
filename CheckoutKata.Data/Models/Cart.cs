using System.Collections.Generic;

namespace CheckoutKata.Data.Models
{
    public class Cart
    {
        public List<CartItem> CartItems { get; set; }
        public decimal Total { get; set; }

        public Cart()
        {
            CartItems = new List<CartItem>();
        }
    }
}
