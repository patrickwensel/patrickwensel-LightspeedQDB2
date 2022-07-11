using QBD2.Entities;
using System.ComponentModel.DataAnnotations;

namespace QBD2.Models
{
    public class ScarCarModel
    {
            public int ScarCarId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Containment { get; set; }
            public string RootCause { get; set; }
            public DateTime OpenDate { get; set; }
            public DateTime DueDate { get; set; }

            public IList<ScarCarNote> ScarCarNotes { get; set; }
            public IList<ScarCarAttachment> ScarCarAttachments { get; set; }

            public int ScarCarImpactId { get; set; }
            public virtual ScarCarImpact ScarCarImpact { get; set; }

            public int ScarCarResolutionId { get; set; }
            public virtual ScarCarResolution ScarCarResolution { get; set; }

            public int ScarCarStatusId { get; set; }
            public virtual ScarCarStatus ScarCarStatus { get; set; }

            public int ScarCarPriorityId { get; set; }
            public virtual ScarCarPriority ScarCarPriority { get; set; }

            public int ScarCarCategoryId { get; set; }
            public virtual ScarCarCategory ScarCarCategory { get; set; }

            public int ScarCarProjectId { get; set; }
            public virtual ScarCarProject ScarCarProject { get; set; }

            public string ApplicationUserId { get; set; }
            public virtual ApplicationUser AssignedUser { get; set; }
    }

    public class ScarCarNote
    {
        public int ScarCarNoteId { get; set; }

        [Required]
        public string Note { get; set; }
        public DateTime AddedDate { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int ScarCarId { get; set; }
        public virtual ScarCar ScarCar { get; set; }
    }
}