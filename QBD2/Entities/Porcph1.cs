using System;
using System.Collections.Generic;

namespace QBD2.Entities
{
    public partial class Porcph1
    {
        public decimal Rcphseq { get; set; }

        public decimal Audtdate { get; set; }

        public decimal Audttime { get; set; }

        public string Audtuser { get; set; } = null!;

        public string Audtorg { get; set; } = null!;

        public decimal Nextlseq { get; set; }

        public int Lines { get; set; }

        public int Linesprora { get; set; }

        public int Linescmpl { get; set; }

        public int Costs { get; set; }

        public int Costsprora { get; set; }

        public int Costscmpl { get; set; }

        public int Vends { get; set; }

        public int Vendscmpl { get; set; }

        public int Vendsinvc { get; set; }

        public int Taxlines { get; set; }

        public int Extraneous { get; set; }

        public short Taxautocal { get; set; }

        public short Isprinted { get; set; }

        public short Isinvoiced { get; set; }

        public short Iscomplete { get; set; }

        public decimal Dtcomplete { get; set; }

        public decimal Postdate { get; set; }

        public decimal Date { get; set; }

        public string Fiscyear { get; set; } = null!;

        public short Fiscperiod { get; set; }

        public string Rcpnumber { get; set; } = null!;

        public string Template { get; set; } = null!;

        public string Fobpoint { get; set; } = null!;

        public string Vdcode { get; set; } = null!;

        public short Vdexists { get; set; }

        public string Vdname { get; set; } = null!;

        public string Vdaddress1 { get; set; } = null!;

        public string Vdaddress2 { get; set; } = null!;

        public string Vdaddress3 { get; set; } = null!;

        public string Vdaddress4 { get; set; } = null!;

        public string Vdcity { get; set; } = null!;

        public string Vdstate { get; set; } = null!;

        public string Vdzip { get; set; } = null!;

        public string Vdcountry { get; set; } = null!;

        public string Vdphone { get; set; } = null!;

        public string Vdfax { get; set; } = null!;

        public string Vdcontact { get; set; } = null!;

        public string Termscode { get; set; } = null!;

        public decimal Porhseq { get; set; }

        public string Ponumber { get; set; } = null!;

        public string Invnumber { get; set; } = null!;

        public string Descriptio { get; set; } = null!;

        public string Reference { get; set; } = null!;

        public string Comment { get; set; } = null!;

        public string Viacode { get; set; } = null!;

        public string Vianame { get; set; } = null!;

        public string Currency { get; set; } = null!;

        public decimal Rate { get; set; }

        public decimal Spread { get; set; }

        public string Ratetype { get; set; } = null!;

        public short Ratematch { get; set; }

        public decimal Ratedate { get; set; }

        public short Rateoper { get; set; }

        public short Rateover { get; set; }

        public short Scurndecml { get; set; }

        public decimal Extweight { get; set; }

        public decimal Extended { get; set; }

        public decimal Doctotal { get; set; }

        public decimal Amount { get; set; }

        public decimal Rqreceived { get; set; }

        public string Taxgroup { get; set; } = null!;

        public string Taxauth1 { get; set; } = null!;

        public string Taxauth2 { get; set; } = null!;

        public string Taxauth3 { get; set; } = null!;

        public string Taxauth4 { get; set; } = null!;

        public string Taxauth5 { get; set; } = null!;

        public short Taxclass1 { get; set; }

        public short Taxclass2 { get; set; }

        public short Taxclass3 { get; set; }

        public short Taxclass4 { get; set; }

        public short Taxclass5 { get; set; }

        public decimal Taxbase1 { get; set; }

        public decimal Taxbase2 { get; set; }

        public decimal Taxbase3 { get; set; }

        public decimal Taxbase4 { get; set; }

        public decimal Taxbase5 { get; set; }

        public decimal Txinclude1 { get; set; }

        public decimal Txinclude2 { get; set; }

        public decimal Txinclude3 { get; set; }

        public decimal Txinclude4 { get; set; }

        public decimal Txinclude5 { get; set; }

        public decimal Txexclude1 { get; set; }

        public decimal Txexclude2 { get; set; }

        public decimal Txexclude3 { get; set; }

        public decimal Txexclude4 { get; set; }

        public decimal Txexclude5 { get; set; }

        public decimal Taxamount1 { get; set; }

        public decimal Taxamount2 { get; set; }

        public decimal Taxamount3 { get; set; }

        public decimal Taxamount4 { get; set; }

        public decimal Taxamount5 { get; set; }

        public decimal Txrecvamt1 { get; set; }

        public decimal Txrecvamt2 { get; set; }

        public decimal Txrecvamt3 { get; set; }

        public decimal Txrecvamt4 { get; set; }

        public decimal Txrecvamt5 { get; set; }

        public decimal Txexpsamt1 { get; set; }

        public decimal Txexpsamt2 { get; set; }

        public decimal Txexpsamt3 { get; set; }

        public decimal Txexpsamt4 { get; set; }

        public decimal Txexpsamt5 { get; set; }

        public decimal Txalloamt1 { get; set; }

        public decimal Txalloamt2 { get; set; }

        public decimal Txalloamt3 { get; set; }

        public decimal Txalloamt4 { get; set; }

        public decimal Txalloamt5 { get; set; }

        public decimal Txbaseallo { get; set; }

        public decimal Txincluded { get; set; }

        public decimal Txexcluded { get; set; }

        public decimal Taxamount { get; set; }

        public decimal Txrecvamt { get; set; }

        public decimal Txexpsamt { get; set; }

        public decimal Txalloamt { get; set; }

        public decimal Mprorated { get; set; }

        public decimal Mtoprorate { get; set; }

        public decimal Scamount { get; set; }

        public decimal Fcamount { get; set; }

        public short Multipor { get; set; }

        public int Pors { get; set; }

        public string Vdemail { get; set; } = null!;

        public string Vdphonec { get; set; } = null!;

        public string Vdfaxc { get; set; } = null!;

        public string Vdemailc { get; set; } = null!;

        public decimal Discpct { get; set; }

        public decimal Discount { get; set; }

        public int Values { get; set; }

        public short Verprorate { get; set; }

        public short Hasrtg { get; set; }

        public short Rtgrate { get; set; }

        public string Rtgterms { get; set; } = null!;

        public int Joblines { get; set; }

        public int Jobcosts { get; set; }

        public int Billlines { get; set; }

        public int Costsblpro { get; set; }

        public short Rtgbase { get; set; }

        public decimal Rtgamount { get; set; }

        public string Trcurrency { get; set; } = null!;

        public decimal Raterc { get; set; }

        public decimal Spreadrc { get; set; }

        public string Ratetyperc { get; set; } = null!;

        public short Ratemtchrc { get; set; }

        public decimal Ratedaterc { get; set; }

        public short Rateoperrc { get; set; }

        public short Ratercover { get; set; }

        public short Rcurndecml { get; set; }

        public decimal Taramount1 { get; set; }

        public decimal Taramount2 { get; set; }

        public decimal Taramount3 { get; set; }

        public decimal Taramount4 { get; set; }

        public decimal Taramount5 { get; set; }

        public decimal Trinclude1 { get; set; }

        public decimal Trinclude2 { get; set; }

        public decimal Trinclude3 { get; set; }

        public decimal Trinclude4 { get; set; }

        public decimal Trinclude5 { get; set; }

        public decimal Trexclude1 { get; set; }

        public decimal Trexclude2 { get; set; }

        public decimal Trexclude3 { get; set; }

        public decimal Trexclude4 { get; set; }

        public decimal Trexclude5 { get; set; }

        public decimal Trrecvamt1 { get; set; }

        public decimal Trrecvamt2 { get; set; }

        public decimal Trrecvamt3 { get; set; }

        public decimal Trrecvamt4 { get; set; }

        public decimal Trrecvamt5 { get; set; }

        public decimal Trexpsamt1 { get; set; }

        public decimal Trexpsamt2 { get; set; }

        public decimal Trexpsamt3 { get; set; }

        public decimal Trexpsamt4 { get; set; }

        public decimal Trexpsamt5 { get; set; }

        public decimal Tralloamt1 { get; set; }

        public decimal Tralloamt2 { get; set; }

        public decimal Tralloamt3 { get; set; }

        public decimal Tralloamt4 { get; set; }

        public decimal Tralloamt5 { get; set; }

        public short Rtgtaxrep { get; set; }

        public decimal Raxbase1 { get; set; }

        public decimal Raxbase2 { get; set; }

        public decimal Raxbase3 { get; set; }

        public decimal Raxbase4 { get; set; }

        public decimal Raxbase5 { get; set; }

        public decimal Raxamount1 { get; set; }

        public decimal Raxamount2 { get; set; }

        public decimal Raxamount3 { get; set; }

        public decimal Raxamount4 { get; set; }

        public decimal Raxamount5 { get; set; }

        public decimal Rxrecvamt1 { get; set; }

        public decimal Rxrecvamt2 { get; set; }

        public decimal Rxrecvamt3 { get; set; }

        public decimal Rxrecvamt4 { get; set; }

        public decimal Rxrecvamt5 { get; set; }

        public decimal Rxexpsamt1 { get; set; }

        public decimal Rxexpsamt2 { get; set; }

        public decimal Rxexpsamt3 { get; set; }

        public decimal Rxexpsamt4 { get; set; }

        public decimal Rxexpsamt5 { get; set; }

        public decimal Rxalloamt1 { get; set; }

        public decimal Rxalloamt2 { get; set; }

        public decimal Rxalloamt3 { get; set; }

        public decimal Rxalloamt4 { get; set; }

        public decimal Rxalloamt5 { get; set; }
    }
}
