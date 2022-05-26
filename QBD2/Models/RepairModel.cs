namespace QBD2.Models
{
    public class RepairModel
    {
        public string Family { get; set; }
        public string Description { get; set; }
        public string SerialNumber { get; set; }
        public string PartNumber { get; set; }
        public int PartId { get; set; }
        public int MasterPartId { get; set; }
    }
}