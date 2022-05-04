namespace QBD2.Models
{
    public class Deviation
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Item { get; set; }
        public string Originator { get; set; }
        public string ItemPortNumber { get; set; }
        public string PortDescription { get; set; }
        public string ReasonforManufacturingDeviation { get; set; }
        public bool ECORequired { get; set; }
        public string ECONumber { get; set; }
        public string CommentCorrectiveAction { get; set; }
    }
}