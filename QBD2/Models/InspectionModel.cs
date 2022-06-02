namespace QBD2.Models
{
    public class InspectionModel
    {
        public string Family { get; set; }
        public string Description { get; set; }
        public string SerialNumber { get; set; }
        public string PartNumber { get; set; }
        public int PartId { get; set; }
        public int MasterPartId { get; set; }
        public Inspection Inspection { get; set; }
        public List<InspectionFailed> InspectionFailedList { get; set; }

    }
    public class Inspection
    {
        public int InspectionId { get; set; }
        public bool Pass { get; set; }
        public string GeneralComments { get; set; }
        public int PartId { get; set; }
        public int StationId { get; set; }
        public List<InspectionFailed> InspectionFailedList { get; set; }
    }

    public class InspectionFailed
    {
        public int InspectionFailureId { get; set; }
        public string Comment { get; set; }
        public int FailureTypeId { get; set; }
        public string FailureName { get; set; }
        public int FailurePrimaryTypeId { get; set; }
        public string FailurePrimaryName { get; set; }

    }
}
