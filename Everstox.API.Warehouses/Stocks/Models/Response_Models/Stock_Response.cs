namespace Everstox.API.Warehouses.Stocks.Models.Response_Models
{
    public class Stock_Response
    {
        public Batch batch { get; set; }
        public string id { get; set; }
        public Product product { get; set; }
        public int quantity { get; set; }
        public bool updated { get; set; }
    }

    public class Batch
    {
        public string batch { get; set; }
        public DateTime expiration_date { get; set; }
    }

    public class Product
    {
        public string shop_id { get; set; }
        public string sku { get; set; }
    }
}
