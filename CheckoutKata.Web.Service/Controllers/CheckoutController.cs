using CheckoutKata.Business.Providers;
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
        public IHttpActionResult Products()
        {
            return Json(
                ProductProvider.GetAll());
        }
        
        [HttpGet]
        [Route("clear")]
        public IHttpActionResult Clear()
        {
            return Json(
                CartProvider.ClearCart());
        }

        [HttpGet]
        [Route("increment")]
        public IHttpActionResult Increment(string sku)
        {
            return Json(
                CartProvider.IncrementItem(sku));
        }

        [HttpGet]
        [Route("decrement")]
        public IHttpActionResult Decrement(string sku)
        {
            return Json(
                CartProvider.DecrementItem(sku));
        }
    }
}
