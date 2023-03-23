namespace QBD2.Entities
{
    public partial class Icasens
    {
        public int Assmenseq { get; set; }

        public int Compid { get; set; }

        public int Prncompid { get; set; }

        public string Serialnumf { get; set; } = null!;

        public decimal Audtdate { get; set; }

        public decimal Audttime { get; set; }

        public string Audtuser { get; set; } = null!;

        public string Audtorg { get; set; } = null!;

        public string Prnsernumf { get; set; } = null!;

        public string Itemno { get; set; } = null!;

        public string Bomno { get; set; } = null!;

        public string Unit { get; set; } = null!;
    }
}
