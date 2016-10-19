using CheckoutKata.Data.Models;
using System.Collections.Generic;

namespace CheckoutKata.Business.Providers
{
    public class ProductProvider
    {
        public List<Product> GetAll()
        {
            return new List<Product>()
            {
                new Product { SKU = "A", Price = 50, Offer = new Offer { Quantity = 3, Price = 130 } },
                new Product { SKU = "B", Price = 30, Offer = new Offer { Quantity = 2, Price = 45 } },
                new Product { SKU = "C", Price = 20 },
                new Product { SKU = "D", Price = 15, Offer = null }
            };
        }
    }
}
