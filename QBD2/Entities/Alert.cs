using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QBD2.Entities
{
    public class Alert
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlertId { get; set; }

        public string? Title { get; set; }

        public DateTime? DateCreated { get; set; }

        public string? ReasonforManufacturingDeviation { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public virtual List<PartAlert> PartAlerts { get; set; }

        [ForeignKey("MasterPart")]
        public int MasterPartId { get; set; }
        public virtual MasterPart MasterPart { get; set; }

        public string MasterPartNumber
        {
            get
            {
                if (MasterPart != null)
                {
                    return MasterPart.PartNumber;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public string MasterPartDescription
        {
            get
            {
                if (MasterPart != null)
                {
                    return MasterPart.Description;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}