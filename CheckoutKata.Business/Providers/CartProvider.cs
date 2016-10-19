using CheckoutKata.Data.Models;
using System;
using System.Linq;

namespace CheckoutKata.Business.Providers
{
    public class CartProvider
    {
        Cart cart;

        public CartProvider()
        {
            cart = new Cart();
        }

        public Cart ClearCart()
        {
            cart = new Cart();

            return cart;
        }

        public Cart DecrementItem(string sku)
        {
            if (cart.CartItems
                .Where(ci => ci.Product.SKU == sku)
                .Any())
            {
                cart.CartItems
                .Where(ci => ci.Product.SKU == sku)
                .FirstOrDefault()
                .Quantity--;

                ValidateCart();
            }

            return cart;
        }

        public Cart IncrementItem(string sku)
        {
            var product = new ProductProvider()
                .GetAll()
                .Where(p => p.SKU == sku)
                .FirstOrDefault();

            if (cart.CartItems
                .Where(ci => ci.Product.SKU == sku)
                .Any())
            {
                cart.CartItems
                .Where(ci => ci.Product.SKU == sku)
                .FirstOrDefault()
                .Quantity++;

                ValidateCart();
            }
            else if (product != null)
            {
                cart.CartItems.Add(
                    new CartItem
                    {
                        Product = product,
                        Quantity = 1
                    });

                ValidateCart();
            }

            return cart;
        }

        void ValidateCart()
        {
            // Remove non-qty items
            while (cart.CartItems
                .Where(ci => ci.Quantity < 1)
                .Any())
            {
                cart.CartItems
                    .Remove(cart.CartItems
                        .Where(ci => ci.Quantity < 1)
                        .FirstOrDefault());
            }

            cart.Total = 0;

            // Recalc Offer totals
            foreach (var cartItem in cart.CartItems
                .Where(ci => ci.Product.Offer != null))
            {
                var numberOfOffersPresent = Math.Floor(new decimal(cartItem.Quantity / cartItem.Product.Offer.Quantity));

                cartItem.Subtotal =
                    (numberOfOffersPresent * cartItem.Product.Offer.Price)
                    + ((cartItem.Quantity - (numberOfOffersPresent * cartItem.Product.Offer.Quantity)) * cartItem.Product.Price);

                cart.Total += cartItem.Subtotal;
            }

            // Recalc non-Offer totals
            foreach (var cartItem in cart.CartItems
                .Where(ci => ci.Product.Offer == null))
            {
                cartItem.Subtotal = cartItem.Quantity * cartItem.Product.Price;

                cart.Total += cartItem.Subtotal;
            }
        }
        
    }
}
