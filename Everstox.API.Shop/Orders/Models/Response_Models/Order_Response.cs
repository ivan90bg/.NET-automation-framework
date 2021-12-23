namespace Everstox.API.Shop.Orders.Models.Response_Models
{
    public class Order_Response
    {
        public List<Attachment> attachments { get; set; }
        public BillingAddress billing_address { get; set; }
        public List<CustomAttribute> custom_attributes { get; set; }
        public string customer_email { get; set; }
        public List<string> errors { get; set; }
        public string financial_status { get; set; }
        public List<Fulfillment> fulfillments { get; set; }
        public int hours_late { get; set; }
        public string id { get; set; }
        public DateTime? order_date { get; set; }
        public List<OrderItem> order_items { get; set; }
        public string order_number { get; set; }
        public int order_priority { get; set; }
        public int out_of_stock_hours { get; set; }
        public PaymentMethod payment_method { get; set; }
        public DateTime? requested_delivery_date { get; set; }
        public string requested_warehouse_id { get; set; }
        public List<Return> returns { get; set; }
        public ShippingAddress shipping_address { get; set; }
        public ShippingPrice shipping_price { get; set; }
        public string shop_id { get; set; }
        public ShopInstance shop_instance { get; set; }
        public string state { get; set; }
        public int warehouse_late_hours { get; set; }
    }

    public class Attachment
    {
        public string attachment_type { get; set; }
        public string download_url { get; set; }
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

    public class Cancellation
    {
        public DateTime? creation_date { get; set; }
        public string email { get; set; }
        public string id { get; set; }
        public string state { get; set; }
        public DateTime? updated_date { get; set; }
    }

    public class PriceSet
    {
        public string currency { get; set; }
        public string discount { get; set; }
        public string discount_gross { get; set; }
        public string discount_net { get; set; }
        public string price_gross { get; set; }
        public string price_net_after_discount { get; set; }
        public string price_net_before_discount { get; set; }
        public int quantity { get; set; }
        public string tax { get; set; }
        public string tax_amount { get; set; }
        public string tax_rate { get; set; }
    }

    public class Product
    {
        public string id { get; set; }
        public string name { get; set; }
        public string sku { get; set; }
        public bool batch_product { get; set; }
    }

    public class FulfillmentItem
    {
        public List<string> errors { get; set; }
        public string id { get; set; }
        public List<PriceSet> price_set { get; set; }
        public Product product { get; set; }
        public int quantity { get; set; }
        public string state { get; set; }
    }

    public class ShippedBatch
    {
        public string batch { get; set; }
        public string id { get; set; }
        public int quantity { get; set; }
        public string sku { get; set; }
    }

    public class ShipmentItem
    {
        public string fulfillment_item_id { get; set; }
        public string id { get; set; }
        public int quantity { get; set; }
        public List<ShippedBatch> shipped_batches { get; set; }
    }

    public class Shipment
    {
        public string carrier_id { get; set; }
        public bool forwarded_to_shop { get; set; }
        public DateTime? shipment_date { get; set; }
        public List<ShipmentItem> shipment_items { get; set; }
        public string tracking_code { get; set; }
        public List<string> tracking_codes { get; set; }
        public List<string> tracking_urls { get; set; }
    }
    
    public  class Fulfillment
    {
        public List<Cancellation> cancellations { get; set; }
        public DateTime creation_date { get; set; }
        public List<string> errors { get; set; }
        public List<FulfillmentItem> fulfillment_items { get; set; }
        public int hours_late { get; set; }
        public string id { get; set; }
        public int out_of_stock_hours { get; set; }
        public List<Shipment> shipments { get; set; }
        public string state { get; set; }
        public Warehouse warehouse { get; set; }
        public int warehouse_late_hours { get; set; }
    }

    public class Warehouse
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Shop
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class ShipmentOption
    {
        public string external_identifier { get; set; }
        public string id { get; set; }
        public bool ignored { get; set; }
        public string name { get; set; }
        public Shop shop { get; set; }
        public string status { get; set; }
    }

    public class OrderItem
    {
        public List<CustomAttribute> custom_attributes { get; set; }
        public string id { get; set; }
        public List<PriceSet> price_set { get; set; }
        public Product product { get; set; }
        public int quantity { get; set; }
        public string requested_batch { get; set; }
        public DateTime? requested_batch_expiration_date { get; set; }
        public List<ShipmentOption> shipment_options { get; set; }
        public string state { get; set; }
    }

    public class PaymentMethod
    {
        public string id { get; set; }
        public string name { get; set; }
        public Shop shop { get; set; }
        public string status { get; set; }
    }

    public class ReturnItem
    {
        public string customer_service_state { get; set; }
        public string id { get; set; }
        public Product product { get; set; }
        public int quantity { get; set; }
        public string return_reason { get; set; }
        public string return_reason_code { get; set; }
        public string stock_state { get; set; }
    }

    public class Return
    {
        public string id { get; set; }
        public DateTime? return_date { get; set; }
        public List<ReturnItem> return_items { get; set; }
        public string return_reference { get; set; }
        public string rma_num { get; set; }
        public string state { get; set; }
        public DateTime? updated_date { get; set; }
        public Warehouse warehouse { get; set; }
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
        public string discount_gross { get; set; }
        public string discount_net { get; set; }
        public string price { get; set; }
        public string price_gross { get; set; }
        public string price_net_after_discount { get; set; }
        public string price_net_before_discount { get; set; }
        public string tax { get; set; }
        public string tax_amount { get; set; }
        public string tax_rate { get; set; }
    }

    public class ShopInstance
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}
