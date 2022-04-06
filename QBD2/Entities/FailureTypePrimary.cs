using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QBD2.Entities
{
    public class FailureTypePrimary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FailureTypePrimaryId { get; set; }
        public string Name { get; set; }
    }
}
