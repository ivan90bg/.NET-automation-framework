namespace Everstox.API.Warehouses.Transfers.Models.Request_Models
{
    public class Receive_TransferShipment_Model
    {
        public DateTime shipment_received_date = DateTime.Now;
        public string transfer_id { get; set; }
        public List<TransferItemsUpdate> transfer_items_updates { get; set; }
        public string transfer_number { get; set; }
    }

    public class TransferItemsUpdate
    {
        public int quantity_received { get; set; }
        public int quantity_stocked { get; set; }
        public string sku { get; set; }
    }
}
