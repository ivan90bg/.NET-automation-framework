using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everstox.API.Warehouses.Fulfillments.Models.Response_Model
{
    public class FulfillmentList_Response
    {
        public int count { get; set; }
        public bool estimated { get; set; }
        public List<Item_F_List> items { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
    }

    public class BillingAddress_F_List
    {
        public object VAT_number { get; set; }
        public string address_1 { get; set; }
        public object address_2 { get; set; }
        public string city { get; set; }
        public object company { get; set; }
        public object contact_person { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
        public object department { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public object latitude { get; set; }
        public object longitude { get; set; }
        public object phone { get; set; }
        public object province { get; set; }
        public object province_code { get; set; }
        public object sub_department { get; set; }
        public object title { get; set; }
        public string zip { get; set; }
    }

    public class CustomAttribute_F_List
    {
        public string attribute_key { get; set; }
        public string attribute_value { get; set; }
    }

    public class OrderItem_F_List
    {
        public List<CustomAttribute_F_List> custom_attributes { get; set; }
        public object requested_batch { get; set; }
        public object requested_batch_expiration_date { get; set; }
    }

    public class PriceSet_F_List
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

    public class Product_F_List
    {
        public bool batch_product { get; set; }
        public List<CustomAttribute_F_List> custom_attributes { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string sku { get; set; }
        public int total_stock { get; set; }
    }

    public class ShipmentOption_F_List
    {
        public object external_identifier { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Attachment_F_List
    {
        public string attachment_type { get; set; }
        public string download_url { get; set; }
        public string url { get; set; }
    }
    public class FulfillmentItem_F_List
    {
        public string id { get; set; }
        public OrderItem_F_List order_item { get; set; }
        public List<PriceSet_F_List> price_set { get; set; }
        public Product_F_List product { get; set; }
        public int quantity { get; set; }
        public List<ShipmentOption_F_List> shipment_options { get; set; }
        public string state { get; set; }
    }

    public class Order_F_List
    {
        public List<Attachment_F_List> attachments { get; set; }
        public List<CustomAttribute_F_List> custom_attributes { get; set; }
        public string customer_email { get; set; }
        public string financial_status { get; set; }
        public DateTime order_date { get; set; }
        public string order_number { get; set; }
        public int order_priority { get; set; }
        public DateTime requested_delivery_date { get; set; }
    }

    public class ShippingAddress_F_List
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
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string phone { get; set; }
        public string province { get; set; }
        public string province_code { get; set; }
        public string sub_department { get; set; }
        public string title { get; set; }
        public string zip { get; set; }
    }

    public class ShippingPrice_F_List
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

    public class Shop_F_List
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class ShopInstance_F_List
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Cancellation_F_List
    {
        public DateTime? creation_date { get; set; }
        public string email { get; set; }
        public string id { get; set; }
        public string state { get; set; }
        public DateTime? updated_date { get; set; }
    }

    public class PaymentMethod_F_List
    {
        public string id { get; set; }
        public string name { get; set; }
        public Shop_F_List shop { get; set; }
        public string status { get; set; }
    }

    public class Item_F_List
    {
        public BillingAddress_F_List billing_address { get; set; }
        public List<Cancellation_F_List> cancellations { get; set; }
        public DateTime creation_date { get; set; }
        public List<FulfillmentItem_F_List> fulfillment_items { get; set; }
        public string fulfillment_state { get; set; }
        public int hours_late { get; set; }
        public string id { get; set; }
        public Order_F_List order { get; set; }
        public int out_of_stock_hours { get; set; }
        public PaymentMethod_F_List payment_method { get; set; }
        public ShippingAddress_F_List shipping_address { get; set; }
        public ShippingPrice_F_List shipping_price { get; set; }
        public Shop_F_List shop { get; set; }
        public ShopInstance_F_List shop_instance { get; set; }
        public string state { get; set; }
        public DateTime updated_date { get; set; }
        public string warehouse_id { get; set; }
    }
}
