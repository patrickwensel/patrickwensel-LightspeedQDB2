using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QBD2.Entities
{
    public class BuildTemplateStation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BuildTemplateStationId { get; set; }

        [ForeignKey("BuildTemplate")]
        public int BuildTemplateId { get; set; }
        public virtual BuildTemplate BuildTemplate { get; set; }

        [ForeignKey("BuildStation")]
        public int BuildStationId { get; set; }
        public virtual BuildStation BuildStation { get; set; }

        public int OrderNumber { get; set; }
    }
}
