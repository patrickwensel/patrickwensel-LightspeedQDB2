using System.ComponentModel.DataAnnotations;

namespace QBD2.Models
{
    public class AddEditBuildTemplateModel
    {
        public int BuildTemplateId { get; set; }

        public int BuildTemplatePartId { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Master Part field is required.")]
        public int? MasterPartId { get; set; }

        [Required(ErrorMessage = "The Build Station field is required.")]
        public int? BuildStationId { get; set; }

        public bool SerialNumberRequired { get; set; }
    }
}