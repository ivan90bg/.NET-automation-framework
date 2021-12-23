using Newtonsoft.Json;

namespace Everstox.API.Warehouses.Stocks.Models.Request_Models
{
    public class Stock_Request
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Batch_Req batch { get; set; }
        public Product_Stock product { get; set; }
        public int quantity { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int quantity_blocked { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int quantity_on_hand { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int quantity_ordered { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int quantity_sellable { get; set; }
    }

    public class Batch_Req
    {
        public string batch { get; set; }
        public DateTime expiration_date { get; set; }
    }

    public class Product_Stock
    {
        public string shop_id { get; set; }
        public string sku { get; set; }
    }

}
