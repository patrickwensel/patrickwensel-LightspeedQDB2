using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QBD2.Entities
{
    public class BuildStationInspection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BuildStationInspectionId { get; set; }

        public bool Pass { get; set; }
        public string? GeneralComments { get; set; }

        public virtual List<BuildStationInspectionFailure> BuildStationInspectionFailures { get; set; }


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

        public string Status
        {
            get
            {
                if (Pass == true)
                {
                    return "PASSED";
                }
                else
                {
                    return "FAILED";
                }
            }
        }
    }
}
