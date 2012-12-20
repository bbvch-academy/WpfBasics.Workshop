namespace SbbApi.ApiClasses
{
    using System;

    /// <summary>
    /// Thie class represents a "planned" stop
    /// </summary>
    public class StopBase
    {
        public Station Station { get; set; }
        public string Delay { get; set; }
        public string Platform { get; set; }
        public Prognosis Prognosis { get; set; }
    }

    public class StopArrival : StopBase
    {
        public DateTime? Arrival { get; set; }
    }

    public class StopDeparture : StopBase
    {
        public DateTime? Departure { get; set; }
    }

    public class Stop : StopBase
    {
        public DateTime? Arrival { get; set; }
        public DateTime? Departure { get; set; }
    }
}