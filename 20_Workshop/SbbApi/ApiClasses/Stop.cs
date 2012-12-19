namespace SbbApi.ApiClasses
{
    public class Stop
    {
        public string Category { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public string Operator { get; set; }

        public Location Station { get; set; }

        public string To { get; set; }

        public Checkpoint[] PassList { get; set; }
    }
}