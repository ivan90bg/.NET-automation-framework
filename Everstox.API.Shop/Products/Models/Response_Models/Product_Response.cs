using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everstox.API.Shop.Products.Models.Response_Models
{
    public class Product_Response
    {
        public bool batch_product { get; set; }
        public bool bundle_product { get; set; }
        public List<object> bundles { get; set; }
        public string color { get; set; }
        public string country_of_origin { get; set; }
        public DateTime creation_date { get; set; }
        public List<CustomAttribute> custom_attributes { get; set; }
        public string customs_code { get; set; }
        public string customs_description { get; set; }
        public string id { get; set; }
        public bool ignore_during_import { get; set; }
        public bool ignore_during_shipment { get; set; }
        public List<ImageUrl> image_urls { get; set; }
        public object last_stock_update { get; set; }
        public string name { get; set; }
        public string shop_id { get; set; }
        public string size { get; set; }
        public string sku { get; set; }
        public string status { get; set; }
        public int total_stock { get; set; }
        public List<Unit> units { get; set; }
        public DateTime updated_date { get; set; }
        public List<object> warehouses { get; set; }
    }

    public class CustomAttribute
    {
        public string attribute_key { get; set; }
        public string attribute_value { get; set; }
    }

    public class ImageUrl
    {
        public bool @default { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Unit
    {
        public object base_unit_id { get; set; }
        public object base_unit_name { get; set; }
        public bool default_unit { get; set; }
        public string gtin { get; set; }
        public double height_in_cm { get; set; }
        public string id { get; set; }
        public double length_in_cm { get; set; }
        public string name { get; set; }
        public double quantity_of_base_unit { get; set; }
        public double weight_gross_in_kg { get; set; }
        public double weight_net_in_kg { get; set; }
        public double width_in_cm { get; set; }
    }
}
