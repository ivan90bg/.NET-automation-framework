using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everstox.API.Shop.Products.Models.Request_Models
{
    public class Product_Request
    {
        public bool batch_product = false;

        public bool bundle_product = false;

        public List<Bundle_P_Req> bundles = new List<Bundle_P_Req>();
        public string color { get; set; }
        public string country_of_origin { get; set; }

        public List<CustomAttribute_P_Req> custom_attributes = new List<CustomAttribute_P_Req>();
        public string customs_code { get; set; }
        public string customs_description { get; set; }

        public bool ignore_during_import = false;
        public bool ignore_during_shipment { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<ImageUrl_P_Req> image_urls { get; set; }
        public string name { get; set; }
        public string size { get; set; }
        public string sku { get; set; }
        public string status { get; set; }
        public List<Unit_P_Req> units { get; set; }
    }

    public class Bundle_P_Req
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string product_id { get; set; }
        public string product_sku { get; set; }
        public int quantity { get; set; }
    }

    public class CustomAttribute_P_Req
    {
        public string attribute_key { get; set; }
        public string attribute_value { get; set; }
    }

    public class ImageUrl_P_Req
    {
        public bool @default { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Unit_P_Req
    {
        public bool default_unit { get; set; }
        public string gtin { get; set; }
        public float height_in_cm { get; set; }
        public float length_in_cm { get; set; }
        public string name { get; set; }
        public float quantity_of_base_unit { get; set; }
        public float weight_gross_in_kg { get; set; }
        public float weight_net_in_kg { get; set; }
        public float width_in_cm { get; set; }
    }
}
