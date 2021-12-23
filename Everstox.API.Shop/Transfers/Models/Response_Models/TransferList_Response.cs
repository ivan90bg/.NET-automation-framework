namespace Everstox.API.Shop.Transfers.Models.Response_Models
{
    public class TransferList_Response
    {
        public int count { get; set; }
        public bool estimated { get; set; }
        public List<Transfer_Response> items { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
    }

}
