using System.ComponentModel.DataAnnotations;
namespace QBD2.Models
{
    public class AddPartModel
    {
        public int PartId { get; set; }

        public int SelectedPartId { get; set; }

        public string? SerialNumber { get; set; }

        [Required(ErrorMessage = "The Part Number field is required.")]
        public string? PartNumber { get; set; }

        [Required(ErrorMessage = "The GL Code field is required.")]
        public int? GLCodeId { get; set; }

        [Required(ErrorMessage = "The Failure Type Primary field is required.")]
        public int? FailureTypePrimaryId { get; set; }

        [Required(ErrorMessage = "The Failure Type field is required.")]
        public int? FailureTypeId { get; set; }

        //[Required(ErrorMessage = "The Repair Description field is required.")]
        public string? RepairDescription { get; set; }
    }
}