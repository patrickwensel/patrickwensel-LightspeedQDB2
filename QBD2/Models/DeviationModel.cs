namespace QBD2.Models
{
    public class DeviationModel
    {
        public int DeviationId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Originator { get; set; }
        public string ReasonforManufacturingDeviation { get; set; }
        public bool ECORequired { get; set; }
        public string ECONumber { get; set; }
        public string CommentCorrectiveAction { get; set; }
        public string VendorSVPART { get; set; }
        public string VendorSEVE { get; set; }
        public string Vendor2 { get; set; }
        public string VendorWIP { get; set; }
        public string Vendor3FGI { get; set; }
        public string LSASVPART { get; set; }
        public string LSASEVE { get; set; }
        public string LSA2 { get; set; }
        public string LSAWIP { get; set; }
        public string LSAFGI { get; set; }
    }
}
