using System.ComponentModel.DataAnnotations;

namespace QBD2.Models
{
    public class SerialNumberRange
    {
        [Required]
        public string StartSerialNumber { get; set; }

        [Required]
        public string EndSerialNumber { get; set; }
    }
}
