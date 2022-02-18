using Newtonsoft.Json;

namespace Everstox.API.Shop.Orders.Models.Request_Models
{
    public class Order_Request
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Attachment> attachments { get; set; }
        public BillingAddress billing_address { get; set; }
        public List<CustomAttribute> custom_attributes { get; set; }
        public string customer_email { get; set; }
        public string financial_status { get; set; }

        public DateTime order_date = DateTime.UtcNow;
        public List<OrderItem> order_items { get; set; }
        public string order_number { get; set; }
        public int order_priority { get; set; }
        public string payment_method_id { get; set; }
        public string payment_method_name { get; set; }
        public DateTimeOffset requested_delivery_date { get; set; }
        public string requested_warehouse_id { get; set; }
        public string requested_warehouse_name { get; set; }
        public ShippingAddress shipping_address { get; set; }
        public ShippingPrice shipping_price { get; set; }
        public string shop_instance_id { get; set; }

    }

    public class Attachment
    {
        public string attachment_type { get; set; }
        public string content { get; set; }
        public string file_name { get; set; }
        public string url { get; set; }
    }

    public class BillingAddress
    {
        public string address_1 { get; set; }
        public string address_2 { get; set; }
        public string city { get; set; }
        public string company { get; set; }
        public string contact_person { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
        public string department { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public long latitude { get; set; }
        public long longitude { get; set; }
        public string phone { get; set; }
        public string province { get; set; }
        public string province_code { get; set; }
        public string sub_department { get; set; }
        public string title { get; set; }
        public string zip { get; set; }
        public string VAT_number { get; set; }
    }

    public class CustomAttribute
    {
        public string attribute_key { get; set; }
        public string attribute_value { get; set; }
    }

    public class PriceSet
    {
        public string currency { get; set; }
        public string discount { get; set; }
        public string price { get; set; }
        public int quantity { get; set; }
        public string tax { get; set; }
        public string tax_rate { get; set; }
    }

    public class Product
    {
        public string sku { get; set; }
    }

    public class ShipmentOption
    {
        public string name { get; set; }
    }

    public class OrderItem
    {
        public List<CustomAttribute> custom_attributes { get; set; }
        public List<PriceSet> price_set { get; set; }
        public Product product { get; set; }
        public int quantity { get; set; }
        public List<ShipmentOption> shipment_options { get; set; }
    }

    public class ShippingAddress
    {
        public string address_1 { get; set; }
        public string address_2 { get; set; }
        public string city { get; set; }
        public string company { get; set; }
        public string contact_person { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
        public string department { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public long latitude { get; set; }
        public long longitude { get; set; }
        public string phone { get; set; }
        public string province { get; set; }
        public string province_code { get; set; }
        public string sub_department { get; set; }
        public string title { get; set; }
        public string zip { get; set; }
    }

    public class ShippingPrice
    {
        public string currency { get; set; }
        public string discount { get; set; }
        public string price { get; set; }
        public string tax { get; set; }
    }
}
