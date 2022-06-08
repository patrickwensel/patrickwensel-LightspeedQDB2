using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QBD2.Entities
{
    public class ScarCarNote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScarCarProjectId { get; set; }

        public string Note { get; set; }
        public DateTime AddedDate { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("ScarCar")]
        public int ScarCarId { get; set; }
        public virtual ScarCar ScarCar { get; set; }
    }
}
