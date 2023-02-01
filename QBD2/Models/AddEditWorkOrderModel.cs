using System.ComponentModel.DataAnnotations;

namespace QBD2.Models
{
    public class AddEditWorkOrderModel
    {
        public int WorkOrderId { get; set; }

        public DateTime CreateDate { get; set; }

        [Required(ErrorMessage = "The Work Order Type field is required.")]

        public int? WorkOrderTypeId { get; set; }

        [Required(ErrorMessage = "The Work Order Status field is required.")]
        public int? WorkOrderStatusId { get; set; }

        [Required(ErrorMessage = "The Work Order Priority field is required.")]
        public int? WorkOrderPriorityID { get; set; }

        [Required(ErrorMessage = "The Part field is required.")]
        public int? BuildTemplateId { get; set; }

        [Required(ErrorMessage = "The Quantity field is required.")]
        public int? Quantity { get; set; }

        public string? PONumber { get; set; }
    }
}