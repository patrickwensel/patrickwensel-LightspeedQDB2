using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QBD2.Entities
{
    public class MRBDisposition
    {
        [Key]
        public int MRBDispositionId { get; set; }

        public string Name { get; set; }
    }
}
