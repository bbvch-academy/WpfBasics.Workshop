namespace SbbApi.ApiClasses
{
    public class Location
    {
        public Coordinate Coordinate { get; set; }

        public double? Distance { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Score { get; set; }

        public string Type { get; set; }
    }
}