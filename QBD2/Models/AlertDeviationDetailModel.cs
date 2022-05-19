using QBD2.Entities;

namespace QBD2.Models
{
    public class AlertDeviationDetailModel
    {
        public int AlertId { get; set; }
        public int DeviationId { get; set; }
        public string? Title { get; set; }
        public int MasterPartId { get; set; }
        public string? MasterPartNumber { get; set; }
        public string? MasterPartDescription { get; set; }
        public Alert Alert { get; set; }
        public Deviation Deviation { get; set; }
        public List<Part> PartList { get; set; }
    }
}