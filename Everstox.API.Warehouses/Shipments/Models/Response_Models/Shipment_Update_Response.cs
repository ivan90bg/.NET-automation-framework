using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everstox.API.Warehouses.Shipments.Models.Response_Models
{
    public class Shipment_Update_Response
    {
        public CarrierUpdate carrier { get; set; }
        public bool forwarded_to_shop { get; set; }
        public string id { get; set; }
        public DateTime shipment_date { get; set; }
        public List<ShipmentItemUpdate> shipment_items { get; set; }
        public string tracking_code { get; set; }
        public List<string> tracking_codes { get; set; }
        public List<string> tracking_urls { get; set; }
    }

    public class ShopUpdate
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class CarrierUpdate
    {
        public string id { get; set; }
        public string name { get; set; }
        public ShopUpdate shop { get; set; }
        public string status { get; set; }
    }

    public class FulfillmentItemUpdate
    {
        public string id { get; set; }
        public int quantity { get; set; }
        public string state { get; set; }
    }

    public class ProductUpdate
    {
        public string name { get; set; }
        public string sku { get; set; }
    }

    public class ShipmentItemUpdate
    {
        public FulfillmentItemUpdate fulfillment_item { get; set; }
        public string id { get; set; }
        public ProductUpdate product { get; set; }
        public int quantity { get; set; }
        public string shipped_batches { get; set; }
    }
}
