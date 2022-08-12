using System.ComponentModel.DataAnnotations;

namespace QBD2.Models
{
    public class AddMRBModel
    {
        [Required(ErrorMessage = "The Description field is required.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "The Barcode field is required.")]
        public string BarCode { get; set; }
    }

    public class EditMRBStatusModel
    {
        public int MRBId { get; set; }
        [Required(ErrorMessage = "The Status field is required.")]
        public int? MRBDispositionId { get; set; }
    }
}
