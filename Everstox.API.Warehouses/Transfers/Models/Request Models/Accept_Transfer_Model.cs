namespace Everstox.API.Warehouses.Transfers.Models.Request_Models
{
    public class Accept_Transfer_Model
    {
        public bool accepted { get; set; }
        public string transfer_id { get; set; }
        public string transfer_number { get; set; }
    }
}
