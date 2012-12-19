namespace SbbApi
{
    using ServiceStack.ServiceHost;

    [Route("locations")]
    public class LocationRequest : IReturn<LocationResponse>
    {
        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public string Query { get; set; }

        public string Type { get; set; }
    }
}