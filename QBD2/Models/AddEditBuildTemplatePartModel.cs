using System.ComponentModel.DataAnnotations;

namespace QBD2.Models
{
    public class AddEditBuildTemplatePartModel
    {
        public int BuildTemplatePartId { get; set; }

        [Required(ErrorMessage = "The Build Template field is required.")]
        public int? BuildTemplateId { get; set; }

        [Required(ErrorMessage = "The Master Part field is required.")]
        public int? MasterPartId { get; set; }

        [Required(ErrorMessage = "The Build Station field is required.")]
        public int? BuildStationId { get; set; }

        public bool SerialNumberRequired { get; set; }
    }
}