namespace SbbApi.ApiClasses
{
    public class Section
    {
        public Checkpoint Arrival { get; set; }

        public Checkpoint Departure { get; set; }

        public Stop Journey { get; set; }

        public string Walk { get; set; }
    }
}