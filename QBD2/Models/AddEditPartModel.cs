using System.ComponentModel.DataAnnotations;

namespace QBD2.Models
{
    public class AddEditPartModel
    {
        public int PartId { get; set; }

        public int MasterPartId { get; set; }

        [Required(ErrorMessage = "The Part Number field is required.")]
        public string? MasterPartNumber { get; set; }

        [Required(ErrorMessage = "The Serial Number field is required.")]
        public string? SerialNumber { get; set; }
    }
}