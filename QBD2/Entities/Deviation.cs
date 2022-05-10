using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QBD2.Entities
{
    public class Deviation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeviationId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Item { get; set; }
        public string Originator { get; set; }
        public string ItemPartNumber { get; set; }
        public string PartDescription { get; set; }
        public string ReasonforManufacturingDeviation { get; set; }
        public bool ECORequired { get; set; }
        public string ECONumber { get; set; }
        public string CommentCorrectiveAction { get; set; }

        [ForeignKey("MasterPart")]
        public int MasterPartId { get; set; }
        public virtual MasterPart MasterPart { get; set; }
    }
}
