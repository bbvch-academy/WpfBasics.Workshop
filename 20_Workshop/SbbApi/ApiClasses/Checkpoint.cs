namespace SbbApi.ApiClasses
{
    using System;

    public class Checkpoint
    {
        public DateTime? Arrival { get; set; }

        public string Delay { get; set; }

        public DateTime? Departure { get; set; }

        public string Platform { get; set; }

        public Prognosis Prognosis { get; set; }

        public Location Station { get; set; }
    }
}