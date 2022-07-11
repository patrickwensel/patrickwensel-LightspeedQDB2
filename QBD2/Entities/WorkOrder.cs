﻿using System.ComponentModel;
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


        [ForeignKey("WorkOrderType")]
        public int WorkOrderTypeId { get; set; }
        public virtual WorkOrderType WorkOrderType { get; set; }

        [ForeignKey("WorkOrderStatus")]
        public int WorkOrderStatusId { get; set; }
        public virtual WorkOrderStatus WorkOrderStatus { get; set; }

        [ForeignKey("WorkOrderPriority")]
        public int WorkOrderPriorityID { get; set; }
        public virtual WorkOrderPriority WorkOrderPriority { get; set; }
    }
}