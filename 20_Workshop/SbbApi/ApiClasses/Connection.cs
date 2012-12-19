namespace SbbApi.ApiClasses
{
    using System;

    public class Connection
    {
        public int? Capacity1St { get; set; }

        public int? Capacity2Nd { get; set; }

        public TimeSpan? Duration { get; set; }

        public Checkpoint From { get; set; }

        public string[] Products { get; set; }

        public Section[] Sections { get; set; }

        public Service Service { get; set; }

        public Checkpoint To { get; set; }

        public int Transfers { get; set; }
    }
}