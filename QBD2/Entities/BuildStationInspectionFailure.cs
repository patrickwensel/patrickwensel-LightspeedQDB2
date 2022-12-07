using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QBD2.Entities
{
    public class BuildStationInspectionFailure
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BuildStationInspectionFailureId { get; set; }
        public string? Comment { get; set; }

        [ForeignKey("BuildStationInspection")]
        public int BuildStationInspectionId { get; set; }
        public virtual BuildStationInspection BuildStationInspection { get; set; }

        [ForeignKey("FailureType")]
        public int? FailureTypeId { get; set; }
        public virtual FailureType FailureType { get; set; }
        
    }
}
