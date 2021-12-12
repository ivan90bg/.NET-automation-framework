namespace Everstox.API.Warehouses.Shipments.Models.Response_Models
{
    public class Shipment_Response
    {
        public Carrier carrier { get; set; }
        public bool forwarded_to_shop { get; set; }
        public string id { get; set; }
        public DateTime shipment_date { get; set; }
        public List<ShipmentItem> shipment_items { get; set; }
        public string tracking_code { get; set; }
        public List<string> tracking_codes { get; set; }
        public List<string> tracking_urls { get; set; }
    }

    public class Shop
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Carrier
    {
        public string id { get; set; }
        public string name { get; set; }
        public Shop shop { get; set; }
        public string status { get; set; }
    }

    public class FulfillmentItem
    {
        public string id { get; set; }
        public int quantity { get; set; }
        public string state { get; set; }
    }

    public class Product
    {
        public string name { get; set; }
        public string sku { get; set; }
    }

    public class ShipmentItem
    {
        public FulfillmentItem fulfillment_item { get; set; }
        public string id { get; set; }
        public Product product { get; set; }
        public int quantity { get; set; }
        public string shipped_batches { get; set; }
    }
}
