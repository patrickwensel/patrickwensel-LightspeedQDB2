using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QBD2.Entities
{
    public class BuildStationInspectionFailureHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BuildStationInspectionFailureHistoryId { get; set; }

        public string? Comment { get; set; }

        [ForeignKey("BuildStationInspectionHistory")]
        public int BuildStationInspectionHistoryId { get; set; }
        public virtual BuildStationInspectionHistory BuildStationInspectionHistory { get; set; }

        [ForeignKey("FailureType")]
        public int? FailureTypeId { get; set; }
        public virtual FailureType FailureType { get; set; }
    }
}
