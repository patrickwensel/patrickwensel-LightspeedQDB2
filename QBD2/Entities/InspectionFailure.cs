using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QBD2.Entities
{
    public class InspectionFailure
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InspectionFailureId { get; set; }
        public string Comment { get; set; }

        [ForeignKey("Inspection")]
        public int InspectionId { get; set; }
        public virtual Inspection Inspection { get; set; }

        [ForeignKey("FailureType")]
        public int? FailureTypeId { get; set; }
        public virtual FailureType FailureType { get; set; }

        [ForeignKey("BuildStationFailureCode")]
        public int? BuildStationFailureCodeId { get; set; }
        public virtual BuildStationFailureCode BuildStationFailureCode { get; set; }
    }
}
