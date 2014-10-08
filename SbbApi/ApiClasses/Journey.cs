namespace SbbApi.ApiClasses
{
    public class Journey
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Number { get; set; }
        public string Operator { get; set; }
        
        public Stop[] PassList { get; set; }
        public int? Capacity1st { get; set; }
        public int? Capacity2nd { get; set; }
    }
}