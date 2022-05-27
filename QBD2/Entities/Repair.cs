using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QBD2.Entities
{
    public class Repair
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RepairId { get; set; }
        public string Description { get; set; }

        [ForeignKey("GLCode")]
        public int GLCodeId { get; set; }
        public virtual GLCode GLCode { get; set; }

        [ForeignKey("FailureCode")]
        public int FailureCodeId { get; set; }
        public virtual FailureCode FailureCode { get; set; }

        [ForeignKey("Part")]
        public int PartId { get; set; }
        public virtual Part Part { get; set; }

        public DateTime UpdateDate { get; set; }

        public string PartSerialNumber
        {
            get
            {
                if (Part != null)
                {
                    return Part.SerialNumber;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}
