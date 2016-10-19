using CheckoutKata.Business.Providers;
using CheckoutKata.Data.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace CheckoutKata.Web.Service.Controllers
{
    [RoutePrefix("api")]
    public class CheckoutController : ApiController
    {
        readonly CartProvider CartProvider;
        readonly ProductProvider ProductProvider;

        public CheckoutController(CartProvider cartProvider, ProductProvider productProvider)
        {
            CartProvider = cartProvider;
            ProductProvider = productProvider;
        }

        [HttpGet]
        [Route("products")]
        public List<Product> Products()
        {
            return ProductProvider.GetAll();
        }
        
        [HttpGet]
        [Route("clear")]
        public Cart Clear()
        {
            return CartProvider.ClearCart();
        }

        [HttpGet]
        [Route("increment")]
        public Cart Increment(string sku)
        {
            return CartProvider.IncrementItem(sku);
        }

        [HttpGet]
        [Route("decrement")]
        public Cart Decrement(string sku)
        {
            return CartProvider.DecrementItem(sku);
        }
    }
}
