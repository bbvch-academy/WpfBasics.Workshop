namespace SbbApi.ApiClasses
{
    public class Station
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Score { get; set; }

        public Coordinate Coordinate { get; set; }

        public double? Distance { get; set; }
    }
}