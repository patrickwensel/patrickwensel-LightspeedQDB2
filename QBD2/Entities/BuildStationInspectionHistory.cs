using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QBD2.Entities
{
    public class BuildStationInspectionHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BuildStationInspectionHistoryId { get; set; }

        public bool Pass { get; set; }
        public string? GeneralComments { get; set; }

        [ForeignKey("Part")]
        public int PartId { get; set; }
        public virtual Part Part { get; set; }

        [ForeignKey("BuildStation")]
        public int BuildStationId { get; set; }
        public virtual BuildStation BuildStation { get; set; }

        [ForeignKey("WorkOrder")]
        public int WorkOrderId { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }

        public DateTime UpdateDate { get; set; }

        public bool IsCompleteBuildStation { get; set; }
    }
}
