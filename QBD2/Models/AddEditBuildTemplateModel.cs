using System.ComponentModel.DataAnnotations;

namespace QBD2.Models
{
    public class AddEditBuildTemplateModel
    {
        public AddEditBuildTemplateModel()
        {
            AddEditBuildTemplatePartModels = new List<AddEditBuildTemplatePartModel>();
            AddEditBuildTemplateStationModels = new List<AddEditBuildTemplateStationModel>();
        }
        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Build Station field is required.")]
        public int? BuildStationId { get; set; }
        public int MasterPartId { get; set; }
        [Required(ErrorMessage = "The Part Number field is required.")]
        public string MasterPartNumber { get; set; }
        public List<AddEditBuildTemplateStationModel> AddEditBuildTemplateStationModels { get; set; }
        public List<AddEditBuildTemplatePartModel> AddEditBuildTemplatePartModels { get; set; }
    }

    public class AddEditBuildTemplateStationModel
    {
        [Required]
        public int? BuildStationId { get; set; }
        public string BuildStationName { get; set; }
        
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public int? OrderNumber { get; set; }
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