using System.ComponentModel.DataAnnotations;

namespace QBD2.Models
{
    public class AddEditBuildTemplateModel
    {
        public AddEditBuildTemplateModel()
        {
            AddEditBuildTemplatePartModels = new List<AddEditBuildTemplatePartModel>();
        }
        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Build Station field is required.")]
        public int? BuildStationId { get; set; }
        public int MasterPartId { get; set; }
        [Required(ErrorMessage = "The Part Number field is required.")]
        public string MasterPartNumber { get; set; }
        public List<AddEditBuildTemplatePartModel> AddEditBuildTemplatePartModels { get; set; }
    }

    public class AddEditBuildTemplatePartModel
    {
        [Required]
        public int? BuildStationId { get; set; }
        public string BuildStationName { get; set; }
        public int MasterPartId { get; set; }
        [Required]
        public string MasterPartNumber { get; set; }
        public bool SerialNumberRequired { get; set; }

    }
}