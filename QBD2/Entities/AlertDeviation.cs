using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QBD2.Entities
{
    public class AlertDeviation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlertDeviationId { get; set; }
        public string Name { get; set; }


    }
}
