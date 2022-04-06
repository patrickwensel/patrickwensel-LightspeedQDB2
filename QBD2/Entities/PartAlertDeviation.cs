using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QBD2.Entities
{
    public class PartAlertDeviation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PartAlertDeviationId { get; set; }

        [ForeignKey("Part")]
        public int PartId { get; set; }
        public virtual Part Part { get; set; }

        [ForeignKey("AlertDeviation")]
        public int AlertDeviationId { get; set; }
        public virtual AlertDeviation AlertDeviation { get; set; }
    }
}
