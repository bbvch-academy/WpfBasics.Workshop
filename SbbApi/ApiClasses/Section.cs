namespace SbbApi.ApiClasses
{
    public class Section
    {
        public Journey Journey { get; set; }
        public Walk Walk { get; set; }
        public StopDeparture Departure { get; set; }
        public StopArrival Arrival { get; set; }
    }
}