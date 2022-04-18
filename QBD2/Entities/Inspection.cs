using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QBD2.Entities
{
    public class Inspection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InspectionId { get; set; }
        
        public bool Pass { get; set; }
        public string GeneralComments { get; set; }

        public virtual List<InspectionFailure> InspectionFailures { get; set; }

        [ForeignKey("Part")]
        public int PartId { get; set; }
        public virtual Part Part { get; set; }

        [ForeignKey("Station")]
        public int StationId { get; set; }
        public virtual Station Station { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
