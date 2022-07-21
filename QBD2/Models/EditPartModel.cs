using System.ComponentModel.DataAnnotations;

namespace QBD2.Models
{
    public class EditPartModel
    {
        [Required]
        public int? PartId { get; set; }

        [Required(ErrorMessage = "The Serial Number field is required.")]
        public string? SerialNumber { get; set; }

        public string? PartNumber { get; set; }

        public int? BuildStationId { get; set; }
        public string? BuildStations { get; set; }

        [Required]
        public int? MasterPartId { get; set; }
    }
}