using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QBD2.Entities
{
    public class PartDeviation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PartDeviationId { get; set; }

        [ForeignKey("Part")]
        public int PartId { get; set; }
        public virtual Part Part { get; set; }

        [ForeignKey("Deviation")]
        public int DeviationId { get; set; }
        public virtual Deviation Deviation { get; set; }
    }
}
