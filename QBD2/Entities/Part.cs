using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QBD2.Entities
{
    public class Part
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PartId { get; set; }
        public string SerialNumber { get; set; }

        public virtual List<Deviation> Deviations { get; set; }

        [ForeignKey("MasterPart")]
        public int MasterPartId { get; set; }
        public virtual MasterPart MasterPart { get; set; }

        [ForeignKey("ParentPart")]
        public int? ParentPartId { get; set; }
        public virtual Part ParentPart { get; set; }

        [ForeignKey("PartStatus")]
        public int PartStatusId { get; set; }
        public virtual PartStatus PartStatus { get; set; }

        [ForeignKey("GLCode")]
        public int? GLCodeId { get; set; }
        public virtual GLCode GLCode { get; set; }

        [ForeignKey("FailureCode")]
        public int? FailureCodeId { get; set; }
        public virtual FailureCode FailureCode { get; set; }
    }
}
