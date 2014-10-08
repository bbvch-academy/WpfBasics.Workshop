namespace SbbApi.ApiClasses
{
    public class Stationboard : Journey
    {
        public string To { get; set; }

        public StopDeparture Stop { get; set; }
        
        public string Subcategory { get; set; }
    }
}