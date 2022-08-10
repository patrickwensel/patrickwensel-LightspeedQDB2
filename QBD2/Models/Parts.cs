namespace QBD2.Models
{
    public class Parts
    {
        public int PartId { get; set; }
        public string SerialNumber { get; set; }
        public int MasterPartId { get; set; }
        public int? ParentPartId { get; set; }
        public string PartNumber { get; set; }
        public string Description { get; set; }
        public DateTime UpdateDate { get; set; }

        public int PartStatusId { get; set; }
        public string PartStatus { get; set; }

        public int? GLCodeId { get; set; }
        public string GLCode { get; set; }

        public int? FailureCodeId { get; set; }
        public string FailureCode { get; set; }

        public int? BuildStationId { get; set; }
        public string? BuildStations { get; set; }

        public bool? SerialNumberRequired { get; set; }

        public List<Parts> ChildParts { get; set; }
        public string InspectionStatus { get; set; }
    }
}
