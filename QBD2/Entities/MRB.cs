using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QBD2.Entities
{
    public class MRB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MRBId { get; set; }

        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public string BarCode { get; set; }

        [ForeignKey("MRBDisposition")]
        public int MRBDispositionId { get; set; }
        public virtual MRBDisposition MRBDisposition { get; set; }
    }
}
