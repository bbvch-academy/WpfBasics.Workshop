// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransportApi.cs" company="bbv Software Services AG">
//   Copyright (c) 2012
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// <summary>
//   Defines the TransportApi type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SbbApi
{
    using System.Collections.Generic;
    using SbbApi.ApiClasses;
    using ServiceStack.ServiceClient.Web;

    public class TransportService : ITransportService
    {
        private readonly JsonServiceClient serviceClient;

        public TransportService()
        {
            SerializationExtensions.RegisterAdditionalSerializers();

            this.serviceClient = new JsonServiceClient("http://transport.opendata.ch/v1/");
        }

        public IEnumerable<Connection> GetConnections(string from, string to)
        {
            var connectionResponse = this.serviceClient.Get(new ConnectionRequest { From = @from, To = to, Limit = 5 });
            return connectionResponse.Connections;
        }

        public IEnumerable<Stationboard> GetStationBoard(string station)
        {
            return this.serviceClient.Get(new StationBoardRequest { Station = station, Limit = 5}).Stationboard;
        }

        public IEnumerable<Station> GetLocations(string search)
        {
            return this.serviceClient.Get(new LocationRequest { Query = search }).Stations;
        }
    }
}