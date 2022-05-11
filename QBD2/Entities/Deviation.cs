using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QBD2.Entities
{
    public class Deviation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeviationId { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? Originator { get; set; }
        public string? ReasonforManufacturingDeviation { get; set; }
        public bool ECORequired { get; set; }
        public string? ECONumber { get; set; }
        public string? CommentCorrectiveAction { get; set; }
        public string? VendorSVPART { get; set; }
        public string? VendorSEVE { get; set; }
        public string? Vendor2 { get; set; }
        public string? VendorWIP { get; set; }
        public string? Vendor3FGI { get; set; }
        public string? LSASVPART { get; set; }
        public string? LSASEVE { get; set; }
        public string? LSA2 { get; set; }
        public string? LSAWIP { get; set; }
        public string? LSAFGI { get; set; }

        public virtual List<PartDeviation> PartDeviations { get; set; }

        [ForeignKey("MasterPart")]
        public int MasterPartId { get; set; }
        public virtual MasterPart MasterPart { get; set; }
    }
}
