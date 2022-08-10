using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QBD2.Entities
{
    public class BuildTemplate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BuildTemplateId { get; set; }

        public string Name { get; set; }

        [ForeignKey("MasterPart")]
        public int MasterPartId { get; set; }
        public virtual MasterPart MasterPart { get; set; }

        [ForeignKey("BuildStation")]
        public int BuildStationId { get; set; }
        public virtual BuildStation BuildStation { get; set; }
    }
}
