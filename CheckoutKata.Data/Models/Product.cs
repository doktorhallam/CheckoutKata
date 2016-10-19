namespace CheckoutKata.Data.Models
{
    public class Product
    {
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public Offer Offer { get; set; }
    }
}
