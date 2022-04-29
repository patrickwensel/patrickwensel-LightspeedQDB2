using System;
using System.Collections.Generic;

namespace QBD2.Entities
{
    public partial class Icxser
    {
        public string Serialnum { get; set; } = null!;
        public string Itemnum { get; set; } = null!;
        public decimal Audtdate { get; set; }
        public decimal Audttime { get; set; }
        public string Audtuser { get; set; } = null!;
        public string Audtorg { get; set; } = null!;
        public string Location { get; set; } = null!;
        public short Status { get; set; }
        public decimal Stockdate { get; set; }
        public decimal Expirydate { get; set; }
        public string Serialnumf { get; set; } = null!;
        public short Resvforord { get; set; }
        public short Assetstock { get; set; }
        public decimal Assetcost { get; set; }
        public string Contcode { get; set; } = null!;
        public int Values { get; set; }
        public short Inuse1 { get; set; }
        public decimal Date1 { get; set; }
        public decimal Effdate1 { get; set; }
        public short Lifecont1 { get; set; }
        public short Inuse2 { get; set; }
        public decimal Date2 { get; set; }
        public decimal Effdate2 { get; set; }
        public short Lifecont2 { get; set; }
        public short Inuse3 { get; set; }
        public decimal Date3 { get; set; }
        public decimal Effdate3 { get; set; }
        public short Lifecont3 { get; set; }
        public short Inuse4 { get; set; }
        public decimal Date4 { get; set; }
        public decimal Effdate4 { get; set; }
        public short Lifecont4 { get; set; }
        public short Inuse5 { get; set; }
        public decimal Date5 { get; set; }
        public decimal Effdate5 { get; set; }
        public short Lifecont5 { get; set; }
    }
}
