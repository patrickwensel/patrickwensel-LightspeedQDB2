using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QBD2.Entities
{
    public partial class MasterPart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MasterPartId { get; set; }
        public string PartNumber { get; set; }
        public string Description { get; set; }
        public string? Itemno { get; set; }


        [ForeignKey("ProductFamily")]
        public int? ProductFamilyId { get; set; }
        public virtual ProductFamily ProductFamily { get; set; }

        public virtual List<Deviation> Deviations { get; set; }
        
    }
}
