namespace QBD2.Entities
{
    public partial class Icasen
    {
        public int Assmenseq { get; set; }

        public decimal Audtdate { get; set; }

        public decimal Audttime { get; set; }

        public string Audtuser { get; set; } = null!;

        public string Audtorg { get; set; } = null!;

        public decimal Transnum { get; set; }

        public string Docnum { get; set; } = null!;

        public decimal Transdate { get; set; }

        public string Fiscyear { get; set; } = null!;

        public short Fiscperiod { get; set; }

        public string Reference { get; set; } = null!;

        public string Hdrdesc { get; set; } = null!;

        public string Itemno { get; set; } = null!;

        public string Bomno { get; set; } = null!;

        public string Location { get; set; } = null!;

        public decimal Quantity { get; set; }

        public string Unit { get; set; } = null!;

        public short Transtype { get; set; }

        public decimal Docuniq { get; set; }

        public short Status { get; set; }

        public short Deleted { get; set; }

        public string Manitemno { get; set; } = null!;

        public decimal Unitcost { get; set; }

        public string Fromassnum { get; set; } = null!;

        public decimal Fromassqty { get; set; }

        public decimal Disasscost { get; set; }

        public short Printed { get; set; }

        public int Values { get; set; }

        public string Mastassnum { get; set; } = null!;

        public short Compassmtd { get; set; }

        public decimal Usedqty { get; set; }

        public decimal Needqtystk { get; set; }

        public short Multlevel { get; set; }

        public int Multseq { get; set; }

        public int Prnmultseq { get; set; }

        public string Prnassnum { get; set; } = null!;

        public string Cmpmastitm { get; set; } = null!;

        public string Enteredby { get; set; } = null!;

        public decimal Datebus { get; set; }

        public int Sitemcount { get; set; }

        public int Litemcount { get; set; }

        public decimal Remainassd { get; set; }
    }
}
