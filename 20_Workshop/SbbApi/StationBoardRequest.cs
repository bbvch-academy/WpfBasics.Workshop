namespace SbbApi
{
    using ServiceStack.ServiceHost;

    [Route("stationboard")]
    public class StationBoardRequest : IReturn<StationBoardResponse>
    {
        public int? Id { get; set; }

        public int? Limit { get; set; }

        public string Station { get; set; }

        public string[] Transportations { get; set; }
    }
}