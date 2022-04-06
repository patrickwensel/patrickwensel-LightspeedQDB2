using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QBD2.Entities
{
    public class FailureType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FailureTypeId { get; set; }

        public string Name { get; set; }

        [ForeignKey("FailureTypePrimary")]
        public int FailureTypePrimaryId { get; set; }
        public virtual FailureTypePrimary FailureTypePrimary { get; set; }

    }
}
