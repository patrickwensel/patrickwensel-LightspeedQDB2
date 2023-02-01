using System;
using System.Collections.Generic;

namespace QBD2.Entities
{
    public partial class Porcpls
    {
        public decimal Rcphseq { get; set; }

        public decimal Rcplrev { get; set; }

        public string Serialnumf { get; set; } = null!;

        public decimal Audtdate { get; set; }

        public decimal Audttime { get; set; }

        public string Audtuser { get; set; } = null!;

        public string Audtorg { get; set; } = null!;

        public decimal Rcplseq { get; set; }
    }
}
