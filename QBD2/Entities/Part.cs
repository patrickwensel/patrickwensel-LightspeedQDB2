﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QBD2.Entities
{
    public class Part
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PartId { get; set; }
        public string SerialNumber { get; set; }

        public virtual List<Deviation> Deviations { get; set; }

        [ForeignKey("MasterPart")]
        public int MasterPartId { get; set; }
        public virtual MasterPart MasterPart { get; set; }

        [ForeignKey("ParentPart")]
        public int? ParentPartId { get; set; }
        public virtual Part ParentPart { get; set; }

        [DefaultValue(1)]
        [ForeignKey("PartStatus")]
        public int PartStatusId { get; set; }
        public virtual PartStatus PartStatus { get; set; }

        public DateTime UpdateDate { get; set; }

        [ForeignKey("BuildStation")]
        public int? BuildStationId { get; set; }
        public virtual BuildStation BuildStation { get; set; }

        public bool SerialNumberRequired { get; set; }
    }
}
