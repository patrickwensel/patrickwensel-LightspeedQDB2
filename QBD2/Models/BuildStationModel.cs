namespace QBD2.Models
{
    public class BuildStationModel
    {
        public int BuildStationId { get; set; }
        public string Name { get; set; }

        public List<Parts> Parts { get; set; }

    }
}
