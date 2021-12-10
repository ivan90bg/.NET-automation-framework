namespace Everstox.API.Warehouses.Shipments.Models.Request_Models
{
    public class Shipment_Update_Model
    {
        public string carrier_id { get; set; }
        public bool forwarded_to_shop { get; set; }
        public DateTime shipment_date { get; set; }
        public List<ShipmentItemUpdate> shipment_items { get; set; }
        public string tracking_code { get; set; }
        public List<string> tracking_codes { get; set; }
        public List<string> tracking_urls { get; set; }
    }

    public class ShipmentItemUpdate
    {
        public string fulfillment_item_id { get; set; }
        public string id { get; set; }
        public int quantity { get; set; }
    }
}
