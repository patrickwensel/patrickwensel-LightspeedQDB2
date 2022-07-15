using QBD2.Entities;

namespace QBD2.Models
{
    public class BuildTemplateModel
    {
        public int BuildTemplateId { get; set; }

        public string Name { get; set; }

        public int MasterPartId { get; set; }
        public virtual MasterPart MasterPart { get; set; }

        public int BuildTemplatePartId { get; set; }
        public virtual BuildTemplatePart BuildTemplatePart { get; set; }
    }
}
