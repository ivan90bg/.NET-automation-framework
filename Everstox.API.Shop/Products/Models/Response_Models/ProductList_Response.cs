using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everstox.API.Shop.Products.Models.Response_Models
{
    public class ProductList_Response
    {
        public int count { get; set; }
        public bool estimated { get; set; }
        public List<Item> items { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
    }

    public class Unit_P_List
    {
        public string base_unit_id { get; set; }
        public string base_unit_name { get; set; }
        public bool default_unit { get; set; }
        public string gtin { get; set; }
        public double? height_in_cm { get; set; }
        public string id { get; set; }
        public int? length_in_cm { get; set; }
        public string name { get; set; }
        public int quantity_of_base_unit { get; set; }
        public double? weight_gross_in_kg { get; set; }
        public double? weight_net_in_kg { get; set; }
        public double? width_in_cm { get; set; }
    }

    public class StockQuantity_P_List
    {
        public int quantity { get; set; }
        public string stock_type { get; set; }
    }

    public class Stock_P_List
    {
        public object batch { get; set; }
        public string id { get; set; }
        public DateTime latest_stock_update { get; set; }
        public int quantity { get; set; }
        public List<StockQuantity_P_List> stock_quantities { get; set; }
        public object stock_runway { get; set; }
        public DateTime updated_date { get; set; }
    }

    public class Warehouse_P_List
    {
        public string id { get; set; }
        public DateTime latest_stock_update { get; set; }
        public string name { get; set; }
        public object stock_runway { get; set; }
        public List<Stock_P_List> stocks { get; set; }
        public int total_stock { get; set; }
    }

    public class Item
    {
        public bool batch_product { get; set; }
        public bool bundle_product { get; set; }
        public List<object> bundles { get; set; }
        public string color { get; set; }
        public string country_of_origin { get; set; }
        public DateTime creation_date { get; set; }
        public List<object> custom_attributes { get; set; }
        public string customs_code { get; set; }
        public string customs_description { get; set; }
        public string id { get; set; }
        public bool ignore_during_import { get; set; }
        public bool ignore_during_shipment { get; set; }
        public List<object> image_urls { get; set; }
        public DateTime last_stock_update { get; set; }
        public string name { get; set; }
        public string shop_id { get; set; }
        public string size { get; set; }
        public string sku { get; set; }
        public string status { get; set; }
        public int total_stock { get; set; }
        public List<Unit_P_List> units { get; set; }
        public DateTime updated_date { get; set; }
        public List<Warehouse_P_List> warehouses { get; set; }
    }
}
