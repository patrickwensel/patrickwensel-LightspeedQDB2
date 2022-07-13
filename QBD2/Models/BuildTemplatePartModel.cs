using QBD2.Entities;

namespace QBD2.Models
{
    public class BuildTemplatePartModel
    {
        public int BuildTemplatePartId { get; set; }

        public int BuildTemplateId { get; set; }
        public virtual BuildTemplate BuildTemplate { get; set; }

        public int MasterPartId { get; set; }
        public virtual MasterPart MasterPart { get; set; }

        public int BuildStationId { get; set; }
        public virtual BuildStation BuildStation { get; set; }

        public bool SerialNumberRequired { get; set; }
    }
}