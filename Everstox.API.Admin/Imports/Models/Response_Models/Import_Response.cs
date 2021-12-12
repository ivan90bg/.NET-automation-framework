namespace Everstox.API.Admin.Imports.Models.Response_Models
{
    public class Import_Response
    {
        public int count { get; set; }
        public bool estimated { get; set; }
        public List<Item> items { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
    }

    public class Product
    {
        public string sku { get; set; }
    }

    public class Import
    {
        public string item_id { get; set; }
    }

    public class Tags
    {
        public string order_number { get; set; }
    }

    public class Item
    {
        public bool can_resolve { get; set; }
        public bool can_retry { get; set; }
        public DateTime creation_date { get; set; }
        public string data_in { get; set; }
        public object errors { get; set; }
        public string handler_fn_path { get; set; }
        public string id { get; set; }
        public string item_id { get; set; }
        public string item_type { get; set; }
        public object parent_id { get; set; }
        public object resolved { get; set; }
        public object resolved_by_user_id { get; set; }
        public object resolved_comment { get; set; }
        public object resolved_date { get; set; }
        public object response_body { get; set; }
        public int response_code { get; set; }
        public string shop_id { get; set; }
        public string shop_instance_id { get; set; }
        public string state { get; set; }
        public Tags tags { get; set; }
        public string type { get; set; }
        public DateTime updated_date { get; set; }
        public object warehouse_id { get; set; }
    }
}
