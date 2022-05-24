using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QBD2.Entities
{
    public class PartStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PartStatusId { get; set; }
        public string Name { get; set; }

        public virtual List<Part> Parts { get; set; }
    }
}
