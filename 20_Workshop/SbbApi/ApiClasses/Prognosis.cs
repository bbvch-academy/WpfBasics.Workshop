namespace SbbApi.ApiClasses
{
    using System;

    public class Prognosis
    {
        public string Platform { get; set; }

        public DateTime? Arrival { get; set; }

        public DateTime? Departure { get; set; }

        public int? Capacity1st { get; set; }

        public int? Capacity2nd { get; set; }
    }
}