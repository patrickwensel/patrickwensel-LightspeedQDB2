using System.ComponentModel.DataAnnotations;

namespace QBD2.Models
{
    public class AddEditScarCarModel
    {
        public int ScarCarId { get; set; }

        [Required(ErrorMessage = "The Title field is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Containment field is required.")]
        public string Containment { get; set; }

        [Required(ErrorMessage = "The Root Cause field is required.")]
        public string RootCause { get; set; }

        [Required(ErrorMessage = "The Open Date field is required.")]
        public DateTime? OpenDate { get; set; }

        [Required(ErrorMessage = "The Due Date field is required.")]
        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage = "The Scar Car Impact field is required.")]
        public int? ScarCarImpactId { get; set; }

        [Required(ErrorMessage = "The Scar Car Resolution field is required.")]
        public int? ScarCarResolutionId { get; set; }

        [Required(ErrorMessage = "The Scar Car Status field is required.")]
        public int? ScarCarStatusId { get; set; }

        [Required(ErrorMessage = "The Scar Car Priority field is required.")]
        public int? ScarCarPriorityId { get; set; }

        [Required(ErrorMessage = "The Scar Car Category field is required.")]
        public int? ScarCarCategoryId { get; set; }

        [Required(ErrorMessage = "The Scar Car Project field is required.")]
        public int? ScarCarProjectId { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public IList<ScarCarNote> ScarCarNoteList { get; set; }
    }
}