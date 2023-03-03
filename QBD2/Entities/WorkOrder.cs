using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QBD2.Entities
{
    public class WorkOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkOrderId { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual List<WorkOrderPart>  WorkOrderParts { get; set; }

        [ForeignKey("WorkOrderType")]
        public int WorkOrderTypeId { get; set; }
        public virtual WorkOrderType WorkOrderType { get; set; }

        [ForeignKey("WorkOrderStatus")]
        public int WorkOrderStatusId { get; set; }
        public virtual WorkOrderStatus WorkOrderStatus { get; set; }

        [ForeignKey("WorkOrderPriority")]
        public int WorkOrderPriorityID { get; set; }
        public virtual WorkOrderPriority WorkOrderPriority { get; set; }

        [ForeignKey("BuildTemplate")]
        public int BuildTemplateId { get; set; }
        public virtual BuildTemplate BuildTemplate { get; set; }

        public int Quantity { get; set; }

        public string? PONumber { get; set; }

        public virtual List<BuildStationInspectionHistory> BuildStationInspectionHistories { get; set; }
    }
}
