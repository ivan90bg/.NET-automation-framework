namespace Everstox.API.Shop.Orders.Models.Response_Models
{
    public class OrderList_Response
    {
        public int count { get; set; }
        public bool estimated { get; set; }
        public List<Item_O_List> items { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
    }

    public class BillingAddress_O_List
    {
        public object VAT_number { get; set; }
        public string address_1 { get; set; }
        public string address_2 { get; set; }
        public string city { get; set; }
        public string company { get; set; }
        public object contact_person { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
        public object department { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int latitude { get; set; }
        public int longitude { get; set; }
        public string phone { get; set; }
        public object province { get; set; }
        public object province_code { get; set; }
        public object sub_department { get; set; }
        public string title { get; set; }
        public string zip { get; set; }
    }

    public class CustomAttribute_O_List
    {
        public string attribute_key { get; set; }
        public string attribute_value { get; set; }
    }

    public class Product_O_List
    {
        public string id { get; set; }
        public string name { get; set; }
        public string sku { get; set; }
    }

    public class FulfillmentItem_O_List
    {
        public List<object> errors { get; set; }
        public string id { get; set; }
        public Product_O_List product { get; set; }
        public int quantity { get; set; }
        public string state { get; set; }
    }

    public class Warehouse_O_List
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Fulfillment_O_List
    {
        public List<object> cancellations { get; set; }
        public List<object> errors { get; set; }
        public List<FulfillmentItem_O_List> fulfillment_items { get; set; }
        public int hours_late { get; set; }
        public string id { get; set; }
        public List<object> shipments { get; set; }
        public string state { get; set; }
        public Warehouse_O_List warehouse { get; set; }
    }

    public class PriceSet_O_List
    {
        public string currency { get; set; }
        public string discount { get; set; }
        public string discount_gross { get; set; }
        public string discount_net { get; set; }
        public string price { get; set; }
        public string price_gross { get; set; }
        public string price_net_after_discount { get; set; }
        public string price_net_before_discount { get; set; }
        public int quantity { get; set; }
        public string tax { get; set; }
        public string tax_amount { get; set; }
        public string tax_rate { get; set; }
    }

    public class ShipmentOption_O_List
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class OrderItem_O_List
    {
        public List<CustomAttribute_O_List> custom_attributes { get; set; }
        public List<object> errors { get; set; }
        public string id { get; set; }
        public List<PriceSet_O_List> price_set { get; set; }
        public Product_O_List product { get; set; }
        public int quantity { get; set; }
        public object requested_batch { get; set; }
        public object requested_batch_expiration_date { get; set; }
        public List<ShipmentOption_O_List> shipment_options { get; set; }
        public string state { get; set; }
    }

    public class PaymentMethod_O_List
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class ShippingAddress_O_List
    {
        public string address_1 { get; set; }
        public string address_2 { get; set; }
        public string city { get; set; }
        public string company { get; set; }
        public object contact_person { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
        public object department { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int latitude { get; set; }
        public int longitude { get; set; }
        public string phone { get; set; }
        public object province { get; set; }
        public object province_code { get; set; }
        public object sub_department { get; set; }
        public object title { get; set; }
        public string zip { get; set; }
    }

    public class ShippingPrice_O_List
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

    public class ShopInstance_O_List
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Item_O_List
    {
        public List<object> attachments { get; set; }
        public BillingAddress_O_List billing_address { get; set; }
        public DateTime creation_date { get; set; }
        public List<CustomAttribute_O_List> custom_attributes { get; set; }
        public string customer_email { get; set; }
        public List<object> errors { get; set; }
        public string financial_status { get; set; }
        public List<Fulfillment_O_List> fulfillments { get; set; }
        public int hours_late { get; set; }
        public string id { get; set; }
        public DateTime order_date { get; set; }
        public List<OrderItem_O_List> order_items { get; set; }
        public string order_number { get; set; }
        public int order_priority { get; set; }
        public int out_of_stock_hours { get; set; }
        public PaymentMethod_O_List payment_method { get; set; }
        public DateTime requested_delivery_date { get; set; }
        public object requested_warehouse_id { get; set; }
        public List<object> returns { get; set; }
        public ShippingAddress_O_List shipping_address { get; set; }
        public ShippingPrice_O_List shipping_price { get; set; }
        public string shop_id { get; set; }
        public ShopInstance_O_List shop_instance { get; set; }
        public string state { get; set; }
        public DateTime updated_date { get; set; }
    }
}
