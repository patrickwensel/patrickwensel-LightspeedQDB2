namespace QBD2.Models
{
    public class BuildStationInspectionModel
    {
        public int BuildStationInspectionId { get; set; }
        public bool Pass { get; set; }
        public string GeneralComments { get; set; }
        public int PartId { get; set; }
        public int BuildStationId { get; set; }
        public int WorkOrderId { get; set; }
        public bool IsCompleteBuildStation { get; set; }

        public BuildStationInspectionFailed BuildStationInspectionFailed { get; set; }
        public List<BuildStationInspectionFailed> BuildStationInspectionFailedList { get; set; }

    }


    public class BuildStationInspectionFailed
    {
        public int BuildStationInspectionFailureId { get; set; }
        public string Comment { get; set; }
        public int? FailureTypeId { get; set; }
        public string FailureName { get; set; }
        public int? FailurePrimaryTypeId { get; set; }
        public string FailurePrimaryName { get; set; }

    }
}
