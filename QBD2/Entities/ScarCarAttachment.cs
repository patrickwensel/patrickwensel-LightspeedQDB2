using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QBD2.Entities
{
    public class ScarCarAttachment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScarCarAttachmentId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        [ForeignKey("ScarCar")]
        public int ScarCarId { get; set; }
        public virtual ScarCar ScarCar { get; set; }
    }
}
