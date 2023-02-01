using System;
using System.Collections.Generic;

namespace QBD2.Entities
{
    public partial class Porcpl
    {
        public decimal Rcphseq { get; set; }

        public decimal Rcplrev { get; set; }

        public decimal Audtdate { get; set; }

        public decimal Audttime { get; set; }

        public string Audtuser { get; set; } = null!;

        public string Audtorg { get; set; } = null!;

        public decimal Rcplseq { get; set; }

        public decimal Rcpcseq { get; set; }

        public string Oeonumber { get; set; } = null!;

        public short Indbtable { get; set; }

        public short Postedtoic { get; set; }

        public short Completion { get; set; }

        public decimal Dtcomplete { get; set; }

        public decimal Porhseq { get; set; }

        public decimal Porlseq { get; set; }

        public short Pocomplete { get; set; }

        public short Itemexists { get; set; }

        public string Itemno { get; set; } = null!;

        public string Location { get; set; } = null!;

        public string Itemdesc { get; set; } = null!;

        public string Venditemno { get; set; } = null!;

        public short Hascomment { get; set; }

        public string Orderunit { get; set; } = null!;

        public decimal Orderconv { get; set; }

        public short Orderdecml { get; set; }

        public string Rcpunit { get; set; } = null!;

        public decimal Rcpconv { get; set; }

        public short Rcpdecml { get; set; }

        public short Stockdecml { get; set; }

        public decimal Oqordered { get; set; }

        public decimal Oqprevrecv { get; set; }

        public decimal Oqoutstpo { get; set; }

        public decimal Rqreceived { get; set; }

        public decimal Rqcanceled { get; set; }

        public decimal Rqoutstand { get; set; }

        public decimal Sqordered { get; set; }

        public decimal Sqprevrecv { get; set; }

        public decimal Sqoutstpo { get; set; }

        public decimal Rqordered { get; set; }

        public decimal Rqprevrecv { get; set; }

        public decimal Rqoutstpo { get; set; }

        public decimal Rqrcpextra { get; set; }

        public decimal Sqreceived { get; set; }

        public decimal Sqcanceled { get; set; }

        public decimal Sqoutstand { get; set; }

        public decimal Sqrcpextra { get; set; }

        public decimal Oqreceived { get; set; }

        public decimal Oqcanceled { get; set; }

        public decimal Oqoutstand { get; set; }

        public decimal Oqrcpextra { get; set; }

        public decimal Rqreturned { get; set; }

        public decimal Sqreturned { get; set; }

        public decimal Oqreturned { get; set; }

        public decimal Rqstocked { get; set; }

        public decimal Sqstocked { get; set; }

        public decimal Oqstocked { get; set; }

        public decimal Rqinadjust { get; set; }

        public decimal Sqinadjust { get; set; }

        public decimal Oqinadjust { get; set; }

        public decimal Rqpofilled { get; set; }

        public decimal Sqpofilled { get; set; }

        public decimal Oqpofilled { get; set; }

        public decimal Rqsettled { get; set; }

        public decimal Sqsettled { get; set; }

        public decimal Oqsettled { get; set; }

        public decimal Rqustocked { get; set; }

        public decimal Squstocked { get; set; }

        public decimal Oqustocked { get; set; }

        public decimal Unitweight { get; set; }

        public decimal Extweight { get; set; }

        public decimal Unitcost { get; set; }

        public decimal Extended { get; set; }

        public decimal Taxbase1 { get; set; }

        public decimal Taxbase2 { get; set; }

        public decimal Taxbase3 { get; set; }

        public decimal Taxbase4 { get; set; }

        public decimal Taxbase5 { get; set; }

        public short Taxclass1 { get; set; }

        public short Taxclass2 { get; set; }

        public short Taxclass3 { get; set; }

        public short Taxclass4 { get; set; }

        public short Taxclass5 { get; set; }

        public decimal Taxrate1 { get; set; }

        public decimal Taxrate2 { get; set; }

        public decimal Taxrate3 { get; set; }

        public decimal Taxrate4 { get; set; }

        public decimal Taxrate5 { get; set; }

        public short Taxinclud1 { get; set; }

        public short Taxinclud2 { get; set; }

        public short Taxinclud3 { get; set; }

        public short Taxinclud4 { get; set; }

        public short Taxinclud5 { get; set; }

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

        public decimal Tfbaseallo { get; set; }

        public decimal Tfinclude1 { get; set; }

        public decimal Tfinclude2 { get; set; }

        public decimal Tfinclude3 { get; set; }

        public decimal Tfinclude4 { get; set; }

        public decimal Tfinclude5 { get; set; }

        public decimal Tfalloamt1 { get; set; }

        public decimal Tfalloamt2 { get; set; }

        public decimal Tfalloamt3 { get; set; }

        public decimal Tfalloamt4 { get; set; }

        public decimal Tfalloamt5 { get; set; }

        public decimal Tfrecvamt1 { get; set; }

        public decimal Tfrecvamt2 { get; set; }

        public decimal Tfrecvamt3 { get; set; }

        public decimal Tfrecvamt4 { get; set; }

        public decimal Tfrecvamt5 { get; set; }

        public decimal Tfexpsamt1 { get; set; }

        public decimal Tfexpsamt2 { get; set; }

        public decimal Tfexpsamt3 { get; set; }

        public decimal Tfexpsamt4 { get; set; }

        public decimal Tfexpsamt5 { get; set; }

        public string Glacexpens { get; set; } = null!;

        public decimal Dtarrival { get; set; }

        public short Labelcount { get; set; }

        public decimal Mprorated { get; set; }

        public short Hasdropshi { get; set; }

        public short Droptype { get; set; }

        public string Idcust { get; set; } = null!;

        public string Idcustshpt { get; set; } = null!;

        public string Dlocation { get; set; } = null!;

        public string Desc { get; set; } = null!;

        public string Address1 { get; set; } = null!;

        public string Address2 { get; set; } = null!;

        public string Address3 { get; set; } = null!;

        public string Address4 { get; set; } = null!;

        public string City { get; set; } = null!;

        public string State { get; set; } = null!;

        public string Zip { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Fax { get; set; } = null!;

        public string Contact { get; set; } = null!;

        public short Stockitem { get; set; }

        public string Ponumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Phonec { get; set; } = null!;

        public string Faxc { get; set; } = null!;

        public string Emailc { get; set; } = null!;

        public string Glnonstkcr { get; set; } = null!;

        public string Manitemno { get; set; } = null!;

        public decimal Discpct { get; set; }

        public decimal Discount { get; set; }

        public decimal Discountf { get; set; }

        public decimal Xirqrecevd { get; set; }

        public decimal Xiextwght { get; set; }

        public decimal Xinetxtend { get; set; }

        public int Invlines { get; set; }

        public int Values { get; set; }

        public string Contract { get; set; } = null!;

        public string Project { get; set; } = null!;

        public string Ccategory { get; set; } = null!;

        public short Costclass { get; set; }

        public short Billtype { get; set; }

        public decimal Billrate { get; set; }

        public string Billcurr { get; set; } = null!;

        public string Aritemno { get; set; } = null!;

        public string Arunit { get; set; } = null!;

        public decimal Rtgpercent { get; set; }

        public short Rtgdays { get; set; }

        public decimal Rtgamount { get; set; }

        public short Rtgamtover { get; set; }

        public decimal Taramount1 { get; set; }

        public decimal Taramount2 { get; set; }

        public decimal Taramount3 { get; set; }

        public decimal Taramount4 { get; set; }

        public decimal Taramount5 { get; set; }

        public decimal Tralloamt1 { get; set; }

        public decimal Tralloamt2 { get; set; }

        public decimal Tralloamt3 { get; set; }

        public decimal Tralloamt4 { get; set; }

        public decimal Tralloamt5 { get; set; }

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

        public short Ucismanual { get; set; }

        public string Weightunit { get; set; } = null!;

        public decimal Weightconv { get; set; }

        public decimal Defuweight { get; set; }

        public decimal Defextwght { get; set; }

        public decimal Xidefextwt { get; set; }

        public short Fasdetail { get; set; }

        public int Serialqty { get; set; }

        public decimal Lotqty { get; set; }

        public short Slitem { get; set; }

        public short Detailnum { get; set; }

        public short Caxable1 { get; set; }

        public short Caxable2 { get; set; }

        public short Caxable3 { get; set; }

        public short Caxable4 { get; set; }

        public short Caxable5 { get; set; }
    }
}