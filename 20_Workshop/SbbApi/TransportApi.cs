namespace SbbApi
{
    using System.Collections.Generic;
    using SbbApi.ApiClasses;
    using ServiceStack.ServiceClient.Web;

    public class TransportApi
    {
        private readonly JsonServiceClient serviceClient;

        public TransportApi()
        {
            SerializationExtensions.RegisterAdditionalSerializers();

            this.serviceClient = new JsonServiceClient("http://transport.opendata.ch/v1/");
        }

        public List<Connection> GetConnections(string from, string to)
        {
            var connectionResponse = this.serviceClient.Get(new ConnectionRequest { From = @from, To = to, Limit = 2 });
            return connectionResponse.Connections;
        }

        public List<Stationboard> GetStationBoard(string station)
        {
            return this.serviceClient.Get(new StationBoardRequest { Station = station, Limit = 5}).Stationboard;
        }

        public List<Station> GetLocations(string search)
        {
            return this.serviceClient.Get(new LocationRequest { Query = search }).Stations;
        }
    }
}