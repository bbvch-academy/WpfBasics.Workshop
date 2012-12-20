namespace SbbApi.ApiClasses
{
    using System;

    public class Connection
    {
        public StopDeparture From { get; set; }
        public StopArrival To { get; set; }
        public TimeSpan? Duration { get; set; }
        public int? Transfers { get; set; }
        public Service Service { get; set; }
        public string[] Products { get; set; }
        public int? Capacity1st { get; set; }
        public int? Capacity2nd { get; set; }
        public Section[] Sections { get; set; }
    }
}