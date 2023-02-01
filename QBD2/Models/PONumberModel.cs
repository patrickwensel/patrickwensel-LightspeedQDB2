namespace QBD2.Models
{
    public class WorkOrderDropDown
    {
        public int WorkOrderId { get; set; }
        public string DisplayName { get; set; }
        public string? PONumber { get; set; }
    }

    public class UserWorkOrder
    {
        public string SerialNumber { get; set; }
        public string PONumber { get; set; }
        public int WorkOrderId { get; set; }
        public UserWorkOrderDetail UserWorkOrderDetail { get; set; }
    }

    public class UserWorkOrderDetail
    {
        public UserWorkOrderDetail()
        {
            Parts = new List<EditPartModel>();
            BuildStationInspectionModel = new BuildStationInspectionModel();
        }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string StationName { get; set; }
        public bool IsFoundInCompleteStation { get; set; }
        public string ErrorMessage { get; set; }
        public List<EditPartModel> Parts { get; set; }
        public BuildStationInspectionModel BuildStationInspectionModel { get; set; }
    }

}
