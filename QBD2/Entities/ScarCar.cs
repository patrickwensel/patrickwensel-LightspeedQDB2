using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QBD2.Entities
{
    public class ScarCar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScarCarId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Containment { get; set; }
        public string RootCause { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime DueDate { get; set; }

        public IList<ScarCarNote> ScarCarNotes { get; set; }
        public IList<ScarCarAttachment> ScarCarAttachments { get; set; }

        [ForeignKey("ScarCarImpact")]
        public int ScarCarImpactId { get; set; }
        public virtual ScarCarImpact ScarCarImpact { get; set; }

        [ForeignKey("ScarCarResolution")]
        public int ScarCarResolutionId { get; set; }
        public virtual ScarCarResolution ScarCarResolution { get; set; }

        [ForeignKey("ScarCarStatus")]
        public int ScarCarStatusId { get; set; }
        public virtual ScarCarStatus ScarCarStatus { get; set; }

        [ForeignKey("ScarCarPriority")]
        public int ScarCarPriorityId { get; set; }
        public virtual ScarCarPriority ScarCarPriority { get; set; }

        [ForeignKey("ScarCarCategory")]
        public int ScarCarCategoryId { get; set; }
        public virtual ScarCarCategory ScarCarCategory { get; set; }

        [ForeignKey("ScarCarProject")]
        public int ScarCarProjectId { get; set; }
        public virtual ScarCarProject ScarCarProject { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser AssignedUser { get; set; }

    }
}
