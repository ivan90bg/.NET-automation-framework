using Newtonsoft.Json;

namespace Everstox.API.Shop.Transfers.Models.Request_Models
{
    public class Transfer_Request
    {
        public DateTime ETA = DateTime.Now.AddDays(7);

        public List<CustomAttribute> custom_attributes =  new List<CustomAttribute>();

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string destination { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string destination_name { get; set; }
        public string source { get; set; }
        public List<TransferItem_T> transfer_items { get; set; }
        public string transfer_number { get; set; }
    }

    public class CustomAttribute
    {
        public string attribute_key { get; set; }
        public string attribute_value { get; set; }
    }

    public class TransferItem_T
    {
        public List<CustomAttribute> custom_attributes = new List<CustomAttribute>();

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string product_id { get; set; }
        public int quantity_announced { get; set; }
        public string sku { get; set; }
    }
}
