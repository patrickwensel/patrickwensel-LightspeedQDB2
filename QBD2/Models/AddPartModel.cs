namespace QBD2.Models
{
    public class AddPartModel
    {
        public int PartId { get; set; }
        public string SerialNumber { get; set; }
        public string PartNumber { get; set; }
        public int? GLCodeId { get; set; }
        public int SelectedPartId { get; set; }
    }
}
