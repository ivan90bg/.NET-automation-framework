namespace Everstox.API.Shop.Transfers.Models.Response_Models
{
    public class Transfer_Response_Model
    {
        public DateTime ETA { get; set; }
        public DateTime creation_date { get; set; }
        public List<object> custom_attributes { get; set; }
        public string destination { get; set; }
        public string destination_name { get; set; }
        public string id { get; set; }
        public string shop_id { get; set; }
        public string source { get; set; }
        public string state { get; set; }
        public List<TransferItem> transfer_items { get; set; }
        public string transfer_number { get; set; }
        public List<object> transfer_shipments { get; set; }
    }

    public class Product
    {
        public string id { get; set; }
        public string name { get; set; }
        public string sku { get; set; }
    }

    public class TransferItem
    {
        public List<object> custom_attributes { get; set; }
        public string id { get; set; }
        public Product product { get; set; }
        public string product_name { get; set; }
        public int quantity_announced { get; set; }
        public int quantity_received { get; set; }
        public int quantity_stocked { get; set; }
        public string sku { get; set; }
        public string state { get; set; }
    }
}
