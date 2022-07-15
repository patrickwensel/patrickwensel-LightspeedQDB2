using QBD2.Entities;

namespace QBD2.Models
{
    public class WorkOrderModel
    {
        public int WorkOrderId { get; set; }

        public DateTime CreateDate { get; set; }

        public int WorkOrderTypeId { get; set; }
        public virtual WorkOrderType WorkOrderType { get; set; }

        public int WorkOrderStatusId { get; set; }
        public virtual WorkOrderStatus WorkOrderStatus { get; set; }

        public int WorkOrderPriorityID { get; set; }
        public virtual WorkOrderPriority WorkOrderPriority { get; set; }

        public int BuildTemplateId { get; set; }
        public virtual BuildTemplate BuildTemplate { get; set; }

        public int Quantity { get; set; }

        public string BuildTemplateMasterPartName { get; set; }

        public List<WorkOrderPart> WorkOrderPartList { get; set; }

        public List<Part> PartsList { get; set; }
    }
}