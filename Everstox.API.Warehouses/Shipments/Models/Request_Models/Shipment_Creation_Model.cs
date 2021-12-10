using Everstox.API.Shop.Orders.Models.Response_Models;
using Newtonsoft.Json;

namespace Everstox.API.Warehouses.Shipments.Models.Request_Models
{
    public class Shipment_Creation_Model
    {
        public string carrier_id { get; set; }
        public string carrier_name { get; set; }

        public string fulfillment_id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string order_number { get; set; }
        public DateTime shipment_date { get; set; }
        public List<ShipmentItem> shipment_items { get; set; }
        public string tracking_code { get; set; }
        public List<string> tracking_codes { get; set; }
        public List<string> tracking_urls { get; set; }

        //public Shipment_Creation_Model(Order_Response_Model model)
        //{
        //    order_number = model.order_number;
        //    fulfillment_id = model.fulfillments[0].id;
        //    shipment_items = new List<ShipmentItem>() {
        //            new ShipmentItem {
        //                product = new ProductShipment() {
        //                    sku =model.order_items[0].product.sku },
        //            quantity = model.order_items[0].quantity } };

        //    shipment_items = model.order_items.Select(item => new ShipmentItem
        //    {
        //        product = new ProductShipment
        //        {
        //            sku = item.product.sku
        //        },
        //        quantity = item.quantity
        //    }).ToList();
        //}

        //public Shipment_Creation_Model(string orderNumber, string trackingCode) : this(orderNumber)
        //{
        //    tracking_code = tracking_code;
        //}
    }

    public class ProductShipment
    {
        public string sku { get; set; }
    }

    public class ShippedBatch
    {
        public string batch { get; set; }
        public int quantity { get; set; }
        public string sku { get; set; }
    }

    public class ShipmentItem
    {
        public ProductShipment product { get; set; }
        public int quantity { get; set; }

        public List<ShippedBatch> shipped_batches = new List<ShippedBatch>();
    }

}
